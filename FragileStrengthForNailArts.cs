using System;
using Modding;
using System.Reflection;
using HutongGames.PlayMaker;

namespace FragileStrengthForNailArts
{
	public class FragileStrengthForNailArts : Mod
	{
		internal static FragileStrengthForNailArts instance;

		public override string GetVersion() => Assembly.GetExecutingAssembly().GetName().Version.ToString();

		public override void Initialize()
		{
			instance = this;
			Log("Initializing.");
			ModHooks.HitInstanceHook += HitInstanceHook;
		}

		private HitInstance HitInstanceHook(Fsm owner, HitInstance hit)
		{
			int  damageDealt1 = hit.DamageDealt;
			bool flag         = hit.Source.name.Contains("Great Slash") || hit.Source.name.Contains("Dash Slash") || hit.Source.name.Contains("Hit L") || hit.Source.name.Contains("Hit R");
			bool furyAlwaysOn = ModHooks.GetMod("FuryAlwaysOn") is Mod mod;
			if (hit.AttackType.ToString().Contains("Nail") & flag && PlayerData.instance.equippedCharm_25)
			{
				int damageDealt2 = hit.DamageDealt;
				hit.DamageDealt = (int)(damageDealt2 * 1.5);
				if (furyAlwaysOn && PlayerData.instance.equippedCharm_6)
				{
					int damageDealt3 = hit.DamageDealt;
					hit.DamageDealt = (int)(damageDealt3 * 1.75);
				}
			}
			else if (furyAlwaysOn && hit.AttackType.ToString().Contains("Nail") && PlayerData.instance.equippedCharm_6 && flag)
			{
				int damageDealt4 = hit.DamageDealt;
				hit.DamageDealt = (int)(damageDealt4 * 1.75);
			}
			return hit;
		}
	}
}