#region

using System;

#endregion

namespace LeagueSandbox.GameServer.ENetCS
{
    public class ENetException : Exception
    {
        public ENetException(int code, string message)
            : base(message)
        {
            Code = code;
        }

        public int Code { get; private set; }
    }
}