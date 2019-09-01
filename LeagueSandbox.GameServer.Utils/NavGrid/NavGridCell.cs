namespace LeagueSandbox.GameServer.Utils.NavGrid
{
    public class NavGridCell
    {
        public int Id { get; }
        public float CenterHeight { get; }
        public uint SessionId { get; }
        public float ArrivalCost { get; }
        public bool IsOpen { get; }
        public float Heuristic { get; }
        public uint ActorList { get; }
        public short X { get; }
        public short Y { get; }
        public float AdditionalCost { get; }
        public float HintAsGoodCell { get; }
        public uint AdditionalCostRefCount { get; }
        public uint GoodCellSessionId { get; }
        public float RefHintWeight { get; }
        public short ArrivalDirection { get; }
        public short[] RefHintNode { get; }
        public NavigationGridCellFlags Flags { get; private set; }

        public NavGridCell(int id, float centerHeight, uint sessionId, float arrivalCost, bool isOpen, float heuristic, uint actorList, short x, short y, float additionalCost, float hintAsGoodCell, uint additionalCostRefCount, uint goodCellSessionId, float refHintWeight, short arrivalDirection, short[] refHintNode, NavigationGridCellFlags flags)
        {
            Id = id;
            CenterHeight = centerHeight;
            SessionId = sessionId;
            ArrivalCost = arrivalCost;
            IsOpen = isOpen;
            Heuristic = heuristic;
            ActorList = actorList;
            X = x;
            Y = y;
            AdditionalCost = additionalCost;
            HintAsGoodCell = hintAsGoodCell;
            AdditionalCostRefCount = additionalCostRefCount;
            GoodCellSessionId = goodCellSessionId;
            RefHintWeight = refHintWeight;
            ArrivalDirection = arrivalDirection;
            RefHintNode = refHintNode;
            Flags = flags;
        }

        public void UpdateFlags(NavigationGridCellFlags flags)
        {
            Flags = flags;
        }
    }
}