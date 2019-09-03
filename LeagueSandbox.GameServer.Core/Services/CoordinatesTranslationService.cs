using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using LeagueSandbox.GameServer.Core.RequestProcessing.DTOs;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class CoordinatesTranslationService : ICoordinatesTranslationService
    {
        public Vector2 TranslateCompressedVectorToMapVector(Vector2 vector, Vector2 mapCenter)
        {
            return new Vector2(2 * (vector.X + mapCenter.X), 2 * (vector.Y + mapCenter.Y));
        }

        public IEnumerable<Vector2> TranslateCompressedVectorsToMapVectors(IEnumerable<Vector2> vectors, Vector2 mapCenter)
        {
            return vectors.Select(x => TranslateCompressedVectorToMapVector(x, mapCenter));
        }

        public CompressedWaypoint TranslateMapVectorToCompressedVector(int order, Vector2 vector, Vector2 mapCenter)
        {
            var x = (vector.X - mapCenter.X) / 2;
            var y = (vector.Y - mapCenter.Y) / 2;

            return new CompressedWaypoint(order, new Vector2(x, y));
        }

        public IEnumerable<CompressedWaypoint> TranslateMapVectorsToCompressedVectors(IEnumerable<Vector2> vectors, Vector2 mapCenter)
        {
            var idx = 0;
            return vectors.Select(x => TranslateMapVectorToCompressedVector(idx++, x, mapCenter));
        }
    }
}