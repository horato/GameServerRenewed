using System.Numerics;
using LeagueSandbox.GameServer.Utils.NavGrid;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class PathfindingNode
    {
        public NavGridCell Cell { get; }
        public PathfindingNode Parent { get; private set; }
        public float DistanceToTarget { get; private set; }
        public float Cost { get; private set; }
        public Vector2 Position { get; }
        public bool Walkable => !Cell.Flags.HasFlag(NavigationGridCellFlags.NotPassable) && !Cell.Flags.HasFlag(NavigationGridCellFlags.SeeThrough);
        public float F => DistanceToTarget != -1 && Cost != -1 ? DistanceToTarget + Cost : -1;

        public PathfindingNode(NavGridCell cell)
        {
            Cell = cell;
            Position = new Vector2(cell.X, cell.Y);
        }

        public void Update(PathfindingNode parent, float distanceToTarget, float cost)
        {
            Parent = parent;
            DistanceToTarget = distanceToTarget;
            Cost = cost;
        }

        protected bool Equals(PathfindingNode other)
        {
            return Equals(Cell, other.Cell);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            return Equals((PathfindingNode)obj);
        }

        public override int GetHashCode()
        {
            return (Cell != null ? Cell.GetHashCode() : 0);
        }

        public static bool operator ==(PathfindingNode left, PathfindingNode right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PathfindingNode left, PathfindingNode right)
        {
            return !Equals(left, right);
        }
    }
}