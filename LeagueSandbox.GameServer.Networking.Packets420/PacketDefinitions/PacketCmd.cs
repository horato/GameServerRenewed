﻿namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions
{
    internal enum PacketCmd : short
    {
        KeyCheck = 0x00, // 3 bytes (partial key?), last 4 bytes
        C2SQueryStatusReq = 0x14,
        S2CQueryStatusAns = 0x88,
        S2CPingLoadInfo = 0x95,
        C2SSynchVersion = 0xBD,
        S2CSynchVersion = 0x54, // player bitfield, order players by ClientId
        C2SRequestJoinTeam = 0x64,
        S2CTeamRosterUpdate = 0x67,
        S2CReskinResponse = 0x65,
        S2CRenameResponse = 0x66,
        C2SCharSelected = 0xBE,
        S2CStartSpawn = 0x62,
        S2CCreateHero = 0x4C, // bitfield unknowns, spawn while dead (reconnect), NetNodeId, botRank, spawnPositionIndex
        S2CAvatarInfo = 0x2A, // summoner spells uint/ulong?, items
        S2CEndSpawn = 0x11,
        S2CStartGame = 0x5C,
        S2CCreateTurret = 0x9D,
        S2CAddRegion = 0x23,
        S2CSpawnLevelProp = 0xD0,
        S2COnEnterVisibilityClient = 0xBA,
        S2COnEnterLocalVisibilityClient = 0xAE,
        S2CSynchSimTime = 0xC1,
        S2CSyncMissionStartTime = 0xC2,
        C2SWorldSendCamera = 0x2E,


        // --------------- NOT DONE
        S2CRestrictCameraMovement = 0x06,
        C2SHeartBeat = 0x08,
        C2SSellItem = 0x09,
        UnpauseGame = 0x0A,
        S2CRemoveItem = 0x0B,
        S2CNextAutoAttack = 0x0C,
        S2CEditMessageBoxTop = 0x0D,
        S2CUnlockCamera = 0x0E,
        S2CAddXp = 0x10,
        S2CGameSpeed = 0x12,
        S2CSkillUp = 0x15,
        C2SPingLoadInfo = 0x16,
        S2CChangeSpell = 0x17,
        S2CFloatingText = 0x18,
        S2CFloatingTextWithValue = 0x19,
        C2SSwapItems = 0x20,
        S2CBeginAutoAttack = 0x1A,
        S2CChampionDie2 = 0x1B,
        S2CEditBuff = 0x1C,
        S2CAddGold = 0x22,
        S2CMoveCamera = 0x25,
        S2CSoundSettings = 0x27,
        S2CInhibitorState = 0x2B,
        S2CViewAns = 0x2C,
        S2CChampionRespawn = 0x2F,
        S2CAddUnitFow = 0x33,
        S2CStopAutoAttack = 0x34,
        S2CDeleteObject = 0x35, // not sure what this is, happens when turret leaves vision
        S2CMessageBoxTop = 0x36,
        S2CDestroyObject = 0x38,
        C2SSkillUp = 0x39,
        C2SUseObject = 0x3A,
        S2CSpawnProjectile = 0x3B,
        S2CSwapItems = 0x3E,
        S2CLevelUp = 0x3F,
        S2CAttentionPing = 0x40,
        S2CEmotion = 0x42,
        S2CPlaySound = 0x43,
        S2CAnnounce = 0x45,
        S2CPlayerStats = 0x46,
        C2SAutoAttackOption = 0x47,
        C2SEmotion = 0x48,
        S2CFaceDirection = 0x50,
        S2CLeaveVision = 0x51,
        C2SClientReady = 0x52,
        S2CHandleTipUpdate = 0x55,
        C2SScoreboard = 0x56,
        C2SAttentionPing = 0x57,
        S2CHighlightUnit = 0x59,
        S2CDestroyProjectile = 0x5A,
        S2CChampionDie = 0x5E,
        S2CMoveAns = 0x61,
        S2CDash = 0x64,
        S2CDamageDone = 0x65,
        S2CModifyShield = 0x66,
        ChatBoxMessage = 0x68,
        S2CSetTarget = 0x6A,
        S2CSetAnimation = 0x6B,
        C2SBlueTipClicked = 0x6D,
        S2CShowProjectile = 0x6E,
        S2CBuyItemAns = 0x6F,
        S2CFreezeUnitAnimation = 0x71,
        C2SMoveReq = 0x72,
        S2CSetCameraPosition = 0x73,
        C2SMoveConfirm = 0x77,
        S2CRemoveBuff = 0x7B,
        C2SLockCamera = 0x81,
        C2SBuyItemReq = 0x82,
        S2CToggleInputLockingFlag = 0x84,
        S2CSetCooldown = 0x85,
        S2CSpawnParticle = 0x87,
        S2CExplodeNexus = 0x89,            // <-- Building_Die?
        S2CInhibitorDeathAnimation = 0x89, // <--
        S2CQuest = 0x8C,
        C2SExit = 0x8F,
        C2SWorldSendGameNumber = 0x92, // <-- At least one of these is probably wrong
        S2CWorldSendGameNumber = 0x92, // <--
        S2CChangeCharacterVoice = 0x96,
        S2CUpdateModel = 0x97,
        S2CDisconnectedAnnouncement = 0x98,
        C2SCastSpell = 0x9A,
        S2CNpcHide = 0x9E, // (4.18) not sure what this became
        S2CSetItemStacks = 0x9F,
        S2CMessageBoxRight = 0xA0,
        PauseGame = 0xA1,
        S2CRemoveMessageBoxTop = 0xA2,
        S2CAnnounce2 = 0xA3, // ? idk
        C2SSurrender = 0xA4,
        S2CSurrenderResult = 0xA5,
        S2CRemoveMessageBoxRight = 0xA7,
        C2SStatsConfirm = 0xA8,
        S2CEnableFow = 0xAB,
        C2SClick = 0xAF,
        S2CSpellAnimation = 0xB0,
        S2CEditMessageBoxRight = 0xB1,
        S2CSetModelTransparency = 0xB2,
        S2CBasicTutorialMessageWindow = 0xB3,
        S2CRemoveHighlightUnit = 0xB4,
        S2CCastSpellAns = 0xB5,
        S2CAddBuff = 0xB7,
        S2CAfkWarningWindow = 0xB8,
        S2CHideUi = 0xBC,
        S2CSetTarget2 = 0xC0,
        // Packet 0xC0 format is [Net ID 1] [Net ID 2], purpose still unknown
        S2CCharStats = 0xC4,
        S2CGameEnd = 0xC6,
        S2CSurrender = 0xC9,
        C2SQuestClicked = 0xCD,
        S2CShowHpAndName = 0xCE,
        S2CLevelPropAnimation = 0xD1,
        S2CSetCapturePoint = 0xD3,
        S2CChangeCrystalScarNexusHp = 0xD4,
        S2CSetTeam = 0xD7,
        S2CAttachMinimapIcon = 0xD8,
        S2CDominionPoints = 0xD9,
        S2CSetScreenTint = 0xDB,
        S2CCloseGame = 0xE5,
        C2SCursorPositionOnWorld = 0xE6,
        S2CSpectatorMetaData = 0xEB,
        S2CDebugMessage = 0xF7,
        S2CMessagesAvailable = 0xF9,
        S2CSetItemStacks2 = 0xFD,
        S2CExtended = 0xFE,
        S2CBatch = 0xFF,

        S2CSurrenderState = 0x10E,
        S2COnAttack = 0x10F,
        S2CChampionDeathTimer = 0x117,
        S2CSetSpellActiveState = 0x118,
        S2CResourceType = 0x119,
        S2CReplaceStoreItem = 0x11C,
        S2CCreateMonsterCamp = 0x122,
        S2CSpellEmpower = 0x125,
        S2CNpcDie = 0x126,
        S2CFloatingText2 = 0x128,
        S2CForceTargetSpell = 0x129,
        S2CMoveChampionCameraCenter = 0x12B
    }
}
