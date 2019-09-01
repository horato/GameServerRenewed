using System.Numerics;

namespace LeagueSandbox.GameServer.Utils.NavGrid
{
    // 0,0 is bottom left -ish
    public class NavGrid
    {
        public byte MajorVersion { get; }
        public short MinorVersion { get; }
        public Vector3 MinGridPos { get; }
        public Vector3 MaxGridPos { get; }
        public float CellSize { get; }
        public uint XCellCount { get; }
        public uint YCellCount { get; }
        public NavGridCell[] Cells { get; }
        public NavigationGridCellFlags[] CellFlags { get; }
        public int XSampledHeightCount { get; }
        public int YSampledHeightCount { get; }
        public float DirectionX { get; }
        public float DirectionY { get; }
        public float OffsetX { get; }
        public float OffsetZ { get; }
        public float MapWidth { get; }
        public float MapHeight { get; }
        public Vector2 MiddleOfMap { get; }

        public NavGrid(byte majorVersion, short minorVersion, Vector3 minGridPos, Vector3 maxGridPos, float cellSize, uint xCellCount, uint yCellCount, NavGridCell[] cells, NavigationGridCellFlags[] cellFlags, int xSampledHeightCount, int ySampledHeightCount, float directionX, float directionY, float offsetX, float offsetZ, float mapWidth, float mapHeight, Vector2 middleOfMap)
        {
            MajorVersion = majorVersion;
            MinorVersion = minorVersion;
            MinGridPos = minGridPos;
            MaxGridPos = maxGridPos;
            CellSize = cellSize;
            XCellCount = xCellCount;
            YCellCount = yCellCount;
            Cells = cells;
            CellFlags = cellFlags;
            XSampledHeightCount = xSampledHeightCount;
            YSampledHeightCount = ySampledHeightCount;
            DirectionX = directionX;
            DirectionY = directionY;
            OffsetX = offsetX;
            OffsetZ = offsetZ;
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            MiddleOfMap = middleOfMap;
        }
    }
}