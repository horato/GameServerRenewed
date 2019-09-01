using System;
using System.IO;
using System.Numerics;

namespace LeagueSandbox.GameServer.Utils.NavGrid
{
    internal class NavBinaryReader : IDisposable
    {
        private readonly BinaryReader _reader;

        public NavBinaryReader(Stream stream)
        {
            _reader = new BinaryReader(stream);
        }

        public BinaryReader GetBinaryReader()
        {
            return _reader;
        }

        public long GetReaderPosition()
        {
            return _reader.BaseStream.Position;
        }

        public Vector2 ReadVector2()
        {
            var vector = new Vector2
            (
                _reader.ReadSingle(),
                _reader.ReadSingle()
            );

            return vector;
        }

        public Vector3 ReadVector3()
        {
            var vector = new Vector3
            (
                _reader.ReadSingle(),
                _reader.ReadSingle(),
                _reader.ReadSingle()
            );

            return vector;
        }

        public NavGridCell ReadGridCell_Version5(int id, out NavigationGridCellFlags flag)
        {
            var result = new NavGridCell
            (
                centerHeight: _reader.ReadSingle(),
                sessionId: _reader.ReadUInt32(),
                arrivalCost: _reader.ReadSingle(),
                isOpen: _reader.ReadUInt32() == 1,
                heuristic: _reader.ReadSingle(),
                actorList: _reader.ReadUInt32(),
                x: _reader.ReadInt16(),
                y: _reader.ReadInt16(),
                additionalCost: _reader.ReadSingle(),
                hintAsGoodCell: _reader.ReadSingle(),
                additionalCostRefCount: _reader.ReadUInt32(),
                goodCellSessionId: _reader.ReadUInt32(),
                refHintWeight: _reader.ReadSingle(),
                arrivalDirection: _reader.ReadInt16(),
                flags: (NavigationGridCellFlags)_reader.ReadUInt16(),
                refHintNode: new[] { _reader.ReadInt16(), _reader.ReadInt16() },
                id: id
            );

            flag = result.Flags;

            return result;
        }

        public NavGridCell ReadGridCell_Version7(int id)
        {
            var centerHeight = _reader.ReadSingle();
            var sessionId = _reader.ReadUInt32();
            var arrivalCost = _reader.ReadSingle();
            var isOpen = _reader.ReadUInt32() == 1;
            var heuristic = _reader.ReadSingle();
            var x = _reader.ReadInt16();
            var y = _reader.ReadInt16();
            var actorList = _reader.ReadUInt32();

            _reader.ReadUInt32();
            var goodCellSessionId = _reader.ReadUInt32();
            var refHintWeight = _reader.ReadSingle();
            _reader.ReadUInt16();
            var arrivalDirection = _reader.ReadInt16();
            var refHintNode = new[] { _reader.ReadInt16(), _reader.ReadInt16() };


            return new NavGridCell(id, centerHeight, sessionId, arrivalCost, isOpen, heuristic, actorList, x, y, 0, 0, 0, goodCellSessionId, refHintWeight, arrivalDirection, refHintNode, 0);
        }

        public void Dispose()
        {
            _reader?.Dispose();
        }
    }
}