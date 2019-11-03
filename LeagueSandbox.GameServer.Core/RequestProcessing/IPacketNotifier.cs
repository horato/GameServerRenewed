using System.Collections.Generic;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;

namespace LeagueSandbox.GameServer.Core.RequestProcessing
{
    public interface IPacketNotifier
    {
        void NotifyKeyCheck(ulong senderSummonerId, ulong userSummonerId, int userClientId, uint versionNo, ulong checkId);
        void NotifyQueryStatus(ulong targetSummonerId);
        void NotifySynchVersion(ulong targetSummonerId, bool versionMatches, MapType mapId, IEnumerable<IPlayer> players, string version);
        void NotifyPingLoadInfo(uint senderNetId, int senderClientId, ulong senderSummonerId, PingLoadInfoRequest request);
        void NotifyTeamRosterUpdate(ulong targetSummonerId, IEnumerable<IPlayer> players);
        void NotifyRename(ulong targetSummonerId, ulong summonerId, int skinId, string playerName);
        void NotifyReskin(ulong targetSummonerId, ulong summonerId, int skinId, string skinName);
        void NotifyStartSpawn(ulong targetSummonerId, int blueBotsCount, int redBotsCount);
        void NotifyCreateHero(ulong targetSummonerId, IPlayer player);
        void NotifyAvatarInfo(ulong targetSummonerId, IPlayer player);
        void NotifyEndSpawn(ulong targetSummonerId);
        void NotifyGameStart(ulong targetSummonerId, bool enablePause, bool broadcast);
        void NotifyCreateTurret(ulong targetSummonerId, IObjAiTurret turret);
        void NotifyAddRegion(ulong targetSummonerId, IAttackableUnit unit, uint regionNetId);
        void NotifySpawnLevelProp(ulong targetSummonerId, ILevelPropAI prop);
        void NotifyEnterVisibilityClient(IEnumerable<ulong> targetSummonerIds, IAttackableUnit unit);
        void NotifyEnterLocalVisibilityClient(IEnumerable<ulong> targetSummonerIds, IAttackableUnit unit);
        void NotifySynchSimTime(ulong targetSummonerId, float simTimeMilliseconds);
        void NotifySyncMissionTime(ulong targetSummonerId, float missionTimeMilliseconds);
        void NotifyTipUpdate(ulong targetSummonerId, string tipHeader, string tipText, string tipImagePath, TipCommand tipCommand, uint targetNetId, uint tipId);
        void NotifyMapPing(IEnumerable<ulong> targetSummonerIds, Vector2 position, uint targetNetId, uint sourceNetId, PingCategory pingCategory, bool playAudio, bool showChat, bool pingThrottled, bool playVo);
        void NotifyWaypointGroup(IEnumerable<ulong> targetSummonerIds, IEnumerable<IGameObject> gameObjects, Vector2 mapCenter);
        void NotifyReplication(IEnumerable<ulong> targetSummonerIds, IEnumerable<IAttackableUnit> gameObjects);
        void NotifySetCooldown(ulong targetSummonerId, IObjAiBase owner, ISpellInstance spell);
        void NotifySkillUp(ulong targetSummonerId, IObjAiBase owner, ISpell spell);
        void NotifyCastSpellAns(IEnumerable<ulong> targetSummonerIds, IObjAiBase caster, ISpellInstance spell);
        void NotifyMissileReplication(IEnumerable<ulong> targetSummonerIds, IMissile missile);
        void NotifyDestroyMissile(IEnumerable<ulong> targetSummonerIds, IMissile missile);
        void NotifyLevelUp(IEnumerable<ulong> targetSummonerIds, IObjAiHero hero);
        void NotifyMinionSpawn(IEnumerable<ulong> targetSummonerIds, IObjAiMinion minion);
        void NotifySynchSimTimeFinal(ulong targetSummonerId, uint netId, float timeLastClientMilliseconds, float timeRttLastOverheadMilliseconds, float timeConvergenceMilliseconds);
        void NotifyChatMessage(IEnumerable<ulong> targetSummonerIds, int clientId, uint netId, bool localized, ChatType chatType, string @params, string message);
        void NotifyAutoAttackStart(IEnumerable<ulong> targetSummonerIds, IObjAiBase gameObject, uint projectileNetId);
        void NotifyAutoAttack(IEnumerable<ulong> targetSummonerIds, IObjAiBase gameObject, uint projectileNetId);
        void NotifyUnitSetLookAt(IEnumerable<ulong> targetSummonerIds, IObjAiBase unit, IAttackableUnit target);
        void NotifyUnitApplyDamage(IEnumerable<ulong> targetSummonerIds, DamageResultType damageResultType, DamageType damageType, uint targetNetId, uint sourceNetId, float damage);
        void NotifyShowHealthBar(IEnumerable<ulong> targetSummonerIds, IGameObject obj, bool show);
    }
}
