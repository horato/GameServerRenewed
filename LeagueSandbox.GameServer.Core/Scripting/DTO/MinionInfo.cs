namespace LeagueSandbox.GameServer.Core.Scripting.DTO
{
    public class MinionInfo
    {
        public int DefaultNumPerWave { get; }
        public float Armor { get; }
        public float ArmorUpgrade { get; }
        public float MagicResistance { get; }
        public float MagicResistanceUpgrade { get; }
        public float HPBonus { get; }
        public float HPUpgrade { get; }
        public float HPInhibitor { get; }
        public float DamageBonus { get; }
        public float DamageUpgrade { get; }
        public float DamageInhibitor { get; }
        public float ExpGiven { get; }
        public float ExpBonus { get; }
        public float ExpUpgrade { get; }
        public float ExpInhibitor { get; }
        public float GoldGiven { get; }
        public float GoldBonus { get; }
        public float GoldUpgrade { get; }
        public float GoldInhibitor { get; }
        public float GoldShared { get; }
        public float GoldShareUpgrade { get; }
        public float GoldMaximumBonus { get; }
        public float LocalGoldGiven { get; }
        public float LocalGoldBonus { get; }

        public MinionInfo(int defaultNumPerWave, float armor, float armorUpgrade, float magicResistance, float magicResistanceUpgrade, float hpBonus, float hpUpgrade, float hpInhibitor, float damageBonus, float damageUpgrade, float damageInhibitor, float expGiven, float expBonus, float expUpgrade, float expInhibitor, float goldGiven, float goldBonus, float goldUpgrade, float goldInhibitor, float goldShared, float goldShareUpgrade, float goldMaximumBonus, float localGoldGiven, float localGoldBonus)
        {
            DefaultNumPerWave = defaultNumPerWave;
            Armor = armor;
            ArmorUpgrade = armorUpgrade;
            MagicResistance = magicResistance;
            MagicResistanceUpgrade = magicResistanceUpgrade;
            HPBonus = hpBonus;
            HPUpgrade = hpUpgrade;
            HPInhibitor = hpInhibitor;
            DamageBonus = damageBonus;
            DamageUpgrade = damageUpgrade;
            DamageInhibitor = damageInhibitor;
            ExpGiven = expGiven;
            ExpBonus = expBonus;
            ExpUpgrade = expUpgrade;
            ExpInhibitor = expInhibitor;
            GoldGiven = goldGiven;
            GoldBonus = goldBonus;
            GoldUpgrade = goldUpgrade;
            GoldInhibitor = goldInhibitor;
            GoldShared = goldShared;
            GoldShareUpgrade = goldShareUpgrade;
            GoldMaximumBonus = goldMaximumBonus;
            LocalGoldGiven = localGoldGiven;
            LocalGoldBonus = localGoldBonus;
        }
    }
}