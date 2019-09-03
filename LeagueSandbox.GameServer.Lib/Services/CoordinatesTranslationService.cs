using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class CoordinatesTranslationService : ICoordinatesTranslationService
    {
        private readonly IPathingService _pathingService;

        public CoordinatesTranslationService(IPathingService pathingService)
        {
            _pathingService = pathingService;
        }

        public Vector2 TranslateCompressedVector(Vector2 vector)
        {
            var center = _pathingService.GetMapCenter();
            return TranslateCompressedVector(vector, center);
        }

        public IEnumerable<Vector2> TranslateCompressedVectors(IEnumerable<Vector2> vectors)
        {
            var center = _pathingService.GetMapCenter();
            return vectors.Select(x => TranslateCompressedVector(x, center));
        }

        private Vector2 TranslateCompressedVector(Vector2 vector, Vector2 mapCenter)
        {
            return new Vector2(2 * vector.X + mapCenter.X, 2 * vector.Y + mapCenter.Y);
        }
    }
}