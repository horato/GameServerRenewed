using System.IO;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
	public class SkillUpRequest : RequestDefinition
	{
		public uint NetId { get; }
		public SpellSlot Skill { get; }

        public SkillUpRequest(uint netId, SpellSlot skill)
        {
            NetId = netId;
            Skill = skill;
        }
    }
}