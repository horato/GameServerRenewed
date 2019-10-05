using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Core.Scripting.DTO;
using LeagueSandbox.GameServer.Utils.Map.ExpCurve;
using LeagueSandbox.GameServer.Utils.Providers;

namespace LeagueSandbox.GameServer.Scripts.Base
{
    public abstract class MapScriptBase : IMapScript
    {
        private readonly IMapDataProvider _mapDataProvider;

        public abstract MapType MapType { get; }

        protected MapScriptBase(IMapDataProvider mapDataProvider)
        {
            _mapDataProvider = mapDataProvider;
        }
        
        public virtual MapInitializationData Initialize()
        {
            var expCurve = _mapDataProvider.ProvideExpCurve(MapType);
            var expCurveDictionary = CreateExpCurveDictionary(expCurve);

            return new MapInitializationData(expCurveDictionary);
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
