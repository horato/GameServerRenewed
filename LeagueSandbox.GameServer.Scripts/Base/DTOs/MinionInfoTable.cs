namespace LeagueSandbox.GameServer.Scripts.Base.DTOs
{
    internal class MinionInfoTable
    {
        public NamedMinionInfo Melee { get; }
        public NamedMinionInfo Caster { get; }
        public NamedMinionInfo Cannon { get; }
        public NamedMinionInfo Super { get; }

        public MinionInfoTable(NamedMinionInfo melee, NamedMinionInfo caster, NamedMinionInfo cannon, NamedMinionInfo super)
        {
            Melee = melee;
            Caster = caster;
            Cannon = cannon;
            Super = super;
        }
    }
}