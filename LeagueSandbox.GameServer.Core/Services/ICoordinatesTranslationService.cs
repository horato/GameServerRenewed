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
    public interface ICoordinatesTranslationService
    {
        Vector2 TranslateCompressedVectorToMapVector(Vector2 vector, Vector2 mapCenter);
        IEnumerable<Vector2> TranslateCompressedVectorsToMapVectors(IEnumerable<Vector2> vectors, Vector2 mapCenter);
        CompressedWaypoint TranslateMapVectorToCompressedVector(int order, Vector2 vector, Vector2 mapCenter);
        IEnumerable<CompressedWaypoint> TranslateMapVectorsToCompressedVectors(IEnumerable<Vector2> vectors, Vector2 mapCenter);
    }
}
