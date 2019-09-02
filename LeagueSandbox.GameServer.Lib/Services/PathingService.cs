using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Utils.NavGrid;
using Priority_Queue;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class PathingService : IPathingService
    {
        private NavGrid _navGrid;
        private NavGridCell[,] _cells;

        public PathingService()
        {
        }

        public void Initialize(MapType mapId)
        {
            var file = $"Data/Maps/{TranslateMapId(mapId)}/AIPath.aimesh_ngrid";
            _navGrid = NavGridReader.ReadBinary(file);

            _cells = new NavGridCell[_navGrid.XCellCount, _navGrid.YCellCount];
            foreach (var cell in _navGrid.Cells)
            {
                _cells[cell.X, cell.Y] = cell;
            }
        }

        private int TranslateMapId(MapType mapId)
        {
            switch (mapId)
            {
                case MapType.SummonersRift:
                    return 1;
                case MapType.CrystalScar:
                    return 8;
                case MapType.NewTwistedTreeline:
                    return 10;
                case MapType.NewSummonersRift:
                    return 11;
                case MapType.HowlingAbyss:
                    return 12;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mapId), mapId, null);
            }
        }

        /// <summary> Finds path between start and destination from map coordinates </summary>
        public IEnumerable<Vector2> FindPath(Vector2 start, Vector2 destination)
        {
            var fromNode = GetCellFromMapCoordinates(start.X, start.Y);
            var startNode = new PathfindingNode(fromNode);

            var nearestExit = GetClosestTerrainExit(destination);
            var toNode = GetCellFromMapCoordinates(nearestExit.X, nearestExit.Y);
            var endNode = new PathfindingNode(toNode);

            var path = new Stack<PathfindingNode>();
            var openList = new SimplePriorityQueue<PathfindingNode>();
            var closedList = new Dictionary<Vector2, PathfindingNode>();
            var current = startNode;

            // add start node to Open List
            openList.Enqueue(startNode, Math.Abs(startNode.Cell.X - endNode.Cell.X) + Math.Abs(startNode.Cell.Y - endNode.Cell.Y));

            while (openList.Count != 0 && !closedList.ContainsKey(endNode.Position))
            {
                current = openList.Dequeue();
                closedList.Add(current.Position, current);

                var adjacencies = GetAdjacentNodes(current);
                foreach (var n in adjacencies)
                {
                    if (closedList.ContainsKey(n.Position) || !n.Walkable)
                        continue;
                    if (openList.Contains(n))
                        continue;

                    var distanceToTarget = Math.Abs(n.Cell.X - endNode.Cell.X) + Math.Abs(n.Cell.Y - endNode.Cell.Y);
                    var cost = n.Parent == null ? 1 : 1 + n.Parent.Cost;
                    n.Update(current, distanceToTarget, cost);
                    openList.Enqueue(n, n.F);
                }
            }

            // construct path, if end was not closed return null
            if (!closedList.ContainsKey(endNode.Position))
            {
                return null;
            }

            // if all good, return path
            var temp = current;
            while (temp.Parent != startNode && temp != null)
            {
                path.Push(temp);
                temp = temp.Parent;
            }
            return path.Select(x => new Vector2(x.Cell.X * _navGrid.CellSize, x.Cell.Y * _navGrid.CellSize));
        }

        private IEnumerable<PathfindingNode> GetAdjacentNodes(PathfindingNode n)
        {
            var temp = new List<NavGridCell>();

            var y = (int)n.Cell.Y;
            var x = (int)n.Cell.X;

            if (y + 1 < _navGrid.YCellCount)
            {
                temp.Add(_cells[x, y + 1]);
            }
            if (y - 1 >= 0)
            {
                temp.Add(_cells[x, y - 1]);
            }
            if (x - 1 >= 0)
            {
                temp.Add(_cells[x - 1, y]);
            }
            if (x + 1 < _navGrid.XCellCount)
            {
                temp.Add(_cells[x + 1, y]);
            }

            if (x - 1 >= 0 && y + 1 < _navGrid.YCellCount)
            {
                temp.Add(_cells[x - 1, y + 1]);
            }
            if (x + 1 < _navGrid.XCellCount && y + 1 < _navGrid.YCellCount)
            {
                temp.Add(_cells[x + 1, y + 1]);
            }
            if (x - 1 >= 0 && y - 1 >= 0)
            {
                temp.Add(_cells[x - 1, y - 1]);
            }
            if (x + 1 < _navGrid.XCellCount && y - 1 >= 0)
            {
                temp.Add(_cells[x + 1, y - 1]);
            }

            return temp.Select(c => new PathfindingNode(c));
        }

        /// <summary> Finds closest passable terrain. Input and output are map coordinates. </summary>
        private Vector2 GetClosestTerrainExit(Vector2 location)
        {
            if (IsWalkable(location.X, location.Y))
            {
                return location;
            }

            var trueX = (double)location.X;
            var trueY = (double)location.Y;
            var angle = Math.PI / 4;
            var rr = (location.X - trueX) * (location.X - trueX) + (location.Y - trueY) * (location.Y - trueY);
            var r = Math.Sqrt(rr);

            // x = r * cos(angle)
            // y = r * sin(angle)
            // r = distance from center
            // Draws spirals until it finds a walkable spot
            while (!IsWalkable((float)trueX, (float)trueY))
            {
                trueX = location.X + r * Math.Cos(angle);
                trueY = location.Y + r * Math.Sin(angle);
                angle += Math.PI / 4;
                r += 1;
            }

            return new Vector2((float)trueX, (float)trueY);
        }

        /// <summary> Determines whether cell on map coordinates <param name="x">x</param> and <param name="y" >y</param> is passable. </summary>
        private bool IsWalkable(float x, float y)
        {
            var cell = GetCellFromMapCoordinates(x, y);
            if (cell == null)
                return false;

            return !cell.Flags.HasFlag(NavigationGridCellFlags.NotPassable);
        }

        /// <summary> Finds cell on map coordinates <param name="x">x</param> and <param name="y" >y</param> if exists, or null. </summary>
        private NavGridCell GetCellFromMapCoordinates(float x, float y)
        {
            var cellX = (int)Math.Round(x / _navGrid.CellSize);
            var cellY = (int)Math.Round(y / _navGrid.CellSize);
            if (cellX >= _cells.GetLength(0) || cellY >= _cells.GetLength(1))
                return null;

            return _cells[cellX, cellY];
        }
    }
}