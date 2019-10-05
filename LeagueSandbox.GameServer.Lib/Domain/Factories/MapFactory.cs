using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Entities;
using LeagueSandbox.GameServer.Lib.Providers;
using LeagueSandbox.GameServer.Utils.Map.ExpCurve;
using MoreLinq.Extensions;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories
{
    internal class MapFactory : EntityFactoryBase<Map>, IMapFactory
    {
        private readonly IMapDataProvider _mapDataProvider;

        public MapFactory(IUnityContainer unityContainer, IMapDataProvider mapDataProvider) : base(unityContainer)
        {
            _mapDataProvider = mapDataProvider;
        }

        public Map CreateNew(MapType mapId)
        {
            var expCurve = _mapDataProvider.ProvideExpCurve(mapId);
            var expCurveDictionary = CreateExpCurveDictionary(expCurve);
            var instance = new Map(mapId, expCurveDictionary);

            return SetupDependencies(instance);
        }

        private IDictionary<int, float> CreateExpCurveDictionary(ExpCurve expCurve)
        {
            var result = new Dictionary<int, float>
            {
                { 2, expCurve.Level2 },
                { 3, expCurve.Level3 },
                { 4, expCurve.Level4 },
                { 5, expCurve.Level5 },
                { 6, expCurve.Level6 },
                { 7, expCurve.Level7 },
                { 8, expCurve.Level8 },
                { 9, expCurve.Level9 },
                { 10, expCurve.Level10 },
                { 11, expCurve.Level11 },
                { 12, expCurve.Level12 },
                { 13, expCurve.Level13 },
                { 14, expCurve.Level14 },
                { 15, expCurve.Level15 },
                { 16, expCurve.Level16 },
                { 17, expCurve.Level17 },
                { 18, expCurve.Level18 },
                { 19, expCurve.Level19 },
                { 20, expCurve.Level20 },
                { 21, expCurve.Level21 },
                { 22, expCurve.Level22 },
                { 23, expCurve.Level23 },
                { 24, expCurve.Level24 },
                { 25, expCurve.Level25 },
                { 26, expCurve.Level26 },
                { 27, expCurve.Level27 },
                { 28, expCurve.Level28 },
                { 29, expCurve.Level29 },
                { 30, expCurve.Level30 },
            };

            result.Where(x => Math.Abs(x.Value) < float.Epsilon).ToList().ForEach(x => result.Remove(x.Key));
            result.Add(1, 0);

            return result;
        }
    }
}