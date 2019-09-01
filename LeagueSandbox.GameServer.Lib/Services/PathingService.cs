using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Utils.NavGrid;

namespace LeagueSandbox.GameServer.Lib.Services
{
    public class PathingService : IPathingService
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
    }
}
