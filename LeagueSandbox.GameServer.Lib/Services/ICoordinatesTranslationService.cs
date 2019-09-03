using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.RequestProcessing.DTOs;

namespace LeagueSandbox.GameServer.Lib.Services
{
    /// <summary>
    /// Some coordinates are translated to have 0,0 at the center of the map probably becuase of packet size.
    /// This service translates these coordinates into the ones that are actually used (with 0,0 in the bottom left)
    /// </summary>
    internal interface ICoordinatesTranslationService
    {
        Vector2 TranslateCompressedVector(Vector2 vector);
        IEnumerable<Vector2> TranslateCompressedVectors(IEnumerable<Vector2> vectors);
    }
}
