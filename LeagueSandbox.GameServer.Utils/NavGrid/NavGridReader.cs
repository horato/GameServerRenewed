using System;
using System.IO;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Utils.NavGrid
{
    public class NavGridReader
    {
        public static NavGrid ReadBinary(MapType mapId)
        {
            var filePath = $"Data/Maps/{MapIdHelper.TranslateMapId(mapId)}/AIPath.aimesh_ngrid";
            using (var file = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var b = new NavBinaryReader(file))
                return ReadData(b);
        }

        private static NavGrid ReadData(NavBinaryReader b)
        {
            var majorVersion = b.GetBinaryReader().ReadByte();

            var minorVersion = (short)0;
            if (majorVersion != 2)
            {
                minorVersion = b.GetBinaryReader().ReadInt16();
            }

            var minGridPos = b.ReadVector3();
            var maxGridPos = b.ReadVector3();

            var cellSize = b.GetBinaryReader().ReadSingle();
            var xCellCount = b.GetBinaryReader().ReadUInt32();
            var yCellCount = b.GetBinaryReader().ReadUInt32();
            var cells = new NavGridCell[xCellCount * yCellCount];
            var cellFlags = new NavigationGridCellFlags[xCellCount * yCellCount];

            var xSampledHeightCount = 0;
            var ySampledHeightCount = 0;

            var directionX = 0f;
            var directionY = 0f;
            if (majorVersion == 0x02 || majorVersion == 0x03 || majorVersion == 0x05)
            {
                // Read cells, total size: 0x38 * XCellCount * YCellCount bytes

                for (var i = 0; i < cells.Length; i++)
                {
                    cells[i] = b.ReadGridCell_Version5(i, out cellFlags[i]);
                }

                xSampledHeightCount = b.GetBinaryReader().ReadInt32();
                ySampledHeightCount = b.GetBinaryReader().ReadInt32();

                //should be mXSampledHeightDist
                directionX = b.GetBinaryReader().ReadSingle();
                //should be mYSampledHeightDist
                directionY = b.GetBinaryReader().ReadSingle();
            }
            else if (majorVersion == 0x07)
            {
                // Read cells, total size: 0x30 * XCellCount * YCellCount bytes

                for (var i = 0; i < cells.Length; i++)
                {
                    cells[i] = b.ReadGridCell_Version7(i);
                }

                for (var i = 0; i < cells.Length; i++)
                {
                    cellFlags[i] = (NavigationGridCellFlags)b.GetBinaryReader().ReadUInt16();
                    cells[i].UpdateFlags(cellFlags[i]);
                }
            }
            else
            {
                throw new Exception($"Magic number at the start is unsupported! Value: {majorVersion:X}");
            }

            var mapWidth = maxGridPos.X + minGridPos.X;
            var mapHeight = maxGridPos.Z + minGridPos.Z;
            var middleOfMap = new Vector2(mapWidth / 2, mapHeight / 2);


            return new NavGrid
            (
                majorVersion,
                minorVersion,
                minGridPos,
                maxGridPos,
                cellSize,
                xCellCount,
                yCellCount,
                cells,
                cellFlags,
                xSampledHeightCount,
                ySampledHeightCount,
                directionX,
                directionY,
                0,
                0,
                mapWidth,
                mapHeight,
                middleOfMap
            );
        }
    }
}