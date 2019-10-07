using System.Collections.Generic;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Networking.Core
{
    public interface IPacketWriter
    {
        byte[] WriteKeyCheckResponse(ulong summonerId, int clientId, uint versionNo, ulong checkId);
        byte[] WriteNotifyQueryStatus();
        byte[] WriteSynchVersion(bool versionMatches, MapType mapId, IEnumerable<IPlayer> players, string version);
        byte[] WritePingLoadInfo(uint netId, int clientId, ulong summonerId, float loadedPercent, float eta, ushort count, ushort ping, bool isReady);
        byte[] WriteTeamRosterUpdate(IEnumerable<IPlayer> players);
        byte[] WriteRename(ulong playerId, int skinId, string playerName);
        byte[] WriteReskin(ulong summonerId, int skinId, string skinName);
        byte[] WriteStartSpawn(byte blueBotsCount, byte redBotsCount);
        byte[] WriteCreateHero(IPlayer player);
        byte[] WriteAvatarInfo(IPlayer player);
        byte[] WriteEndSpawn();
        byte[] WriteStartGame(bool enablePause);
        byte[] WriteCreateTurret(IObjAiTurret turret);
        byte[] WriteAddRegion(IAttackableUnit unit, uint regionNetId);
        byte[] WriteSpawnLevelProp(ILevelPropAI levelProp);
        byte[] WriteOnEnterVisibilityClient(IAttackableUnit unit);
        byte[] WriteOnEnterLocalVisibilityClient(IAttackableUnit unit);
        byte[] WriteSynchSimTime(float simTimeMilliseconds);
        byte[] WriteSyncMissionTime(float missionTimeMilliseconds);
        byte[] WriteHandleTipUpdate(string tipHeader, string tipText, string tipImagePath, TipCommand tipCommand, uint tipId, uint targetNetId);
        byte[] WriteMapPing(Vector2 position, uint targetNetId, uint sourceNetId, PingCategory pingCategory, bool playAudio, bool showChat, bool pingThrottled, bool playVo);
        byte[] WriteWaypointGroup(IEnumerable<IGameObject> gameObjects, Vector2 mapCenter);
        byte[] WriteReplication(IEnumerable<IAttackableUnit> gameObjects);
        byte[] WriteSetCooldown(IObjAiBase owner, ISpellInstance spell);
        byte[] WriteSkillUp(IObjAiBase owner, ISpell spell);
        byte[] WriteCastSpellAns(IObjAiBase caster, ISpellInstance spell);
        byte[] WriteMissileReplication(IMissile missile);
        byte[] WriteDestroyMissile(IMissile missile);
        byte[] WriteLevelUp(IObjAiHero hero);
        byte[] WriteMinionSpawn(IObjAiMinion minion);
        byte[] WriteSynchSimTimeFinal(uint netId, float timeLastClientMilliseconds, float timeRttLastOverheadMilliseconds, float timeConvergenceMilliseconds);
        byte[] WriteChatMessage(int clientId, uint netId, bool localized, ChatType chatType, string @params, string message);
    }
}
