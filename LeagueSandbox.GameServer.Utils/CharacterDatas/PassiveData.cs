using LeagueSandbox.GameServer.Core.Data;

namespace LeagueSandbox.GameServer.Utils.CharacterDatas
{
    public sealed class PassiveData : IPassiveData
    {
        public string LuaName { get; }
        public float Range { get; }

        public PassiveData(string luaName, float range)
        {
            LuaName = luaName;
            Range = range;
        }
    }
}
