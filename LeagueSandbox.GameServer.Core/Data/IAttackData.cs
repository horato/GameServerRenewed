namespace LeagueSandbox.GameServer.Core.Data
{
    public interface IAttackData
    {
        string Name { get; }
        float Probability { get; }
        float DelayOffsetPercent { get; }
        float DelayCastOffsetPercent { get; }
        float DelayCastOffsetPercentAttackSpeedRatio { get; }

        /// <summary> Calculates the delay between each AA </summary>
        float Delay(float attackSpeedMod = 1.0f, float? minAttackSpeedOverride = null, float? maxAttackSpeedOverride = null);

        /// <summary> Calculates the delay between AA start and projectile spawn (ie. AA start animation) </summary>
        float CastDelay(float attackSpeedMod = 1.0f, float? minAttackSpeedOverride = null, float? maxAttackSpeedOverride = null);
    }
}