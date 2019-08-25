using System;
using System.Collections.Generic;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    //internal class Dash : BasePacket
    //{
    //    public Dash(INavGrid navGrid,
    //        IAttackableUnit u,
    //        ITarget t,
    //        float dashSpeed,
    //        bool keepFacingLastDirection,
    //        float leapHeight = 0.0f,
    //        float followTargetMaxDistance = 0.0f,
    //        float backDistance = 0.0f,
    //        float travelTime = 0.0f
    //    ) : base(PacketCmd.PKT_S2C_DASH)
    //    {
    //        Write(Environment.TickCount); // syncID
    //        Write((short)1); // Number of dashes
    //        Write((byte)4); // Waypoints size * 2
    //        WriteNetId(u);
    //        Write(dashSpeed);
    //        Write(leapHeight);
    //        Write(u.X);
    //        Write(u.Y);
    //        Write((byte)(keepFacingLastDirection ? 0x01 : 0x00));
    //        if (t.IsSimpleTarget)
    //        {
    //            Write((uint)0);
    //        }
    //        else
    //        {
    //            WriteNetId(t as IGameObject);
    //        }

    //        Write(followTargetMaxDistance);
    //        Write(backDistance);
    //        Write(travelTime);

    //        var waypoints = new List<Vector2>
    //        {
    //            new Vector2(u.X, u.Y),
    //            new Vector2(t.X, t.Y)
    //        };

    //        Write(Movement.EncodeWaypoints(navGrid, waypoints));
    //    }
    //}
}