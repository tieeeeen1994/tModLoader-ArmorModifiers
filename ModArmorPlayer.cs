using System;
using Terraria;
using Terraria.ModLoader;

namespace ArmorModifiers
{
    public class ModArmorPlayer : ModPlayer
    {
        public float extraMinions = 0f;
        public int extraLife = 0;
        public float extraCritDamage = 0f;
        public float extraRegen = 0f;
        public float extraAttackSpeed = 0f;
        public float extraWhipRange = 0f;

        public override void ResetEffects()
        {
            Player.statLifeMax2 += extraLife;
            extraMinions = 0;
            extraLife = 0;
            extraCritDamage = 0f;
            extraRegen = 0;
            extraAttackSpeed = 0f;
            extraWhipRange = 0f;
        }

        public override void UpdateEquips()
        {
            Player.maxMinions += RoundOff(extraMinions);
            Player.maxMinions = Math.Max(0, Player.maxMinions);
            Player.GetAttackSpeed(DamageClass.Generic) += extraAttackSpeed;
            Player.GetAttackSpeed(DamageClass.Generic) = MathF.Max(.01f, Player.GetAttackSpeed(DamageClass.Generic));
            Player.whipRangeMultiplier += extraWhipRange;
        }

        public override void UpdateLifeRegen()
        {
            if (extraRegen > 0)
            {
                Player.lifeRegen += RoundOff(extraRegen);
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (extraRegen < 0)
            {
                Player.lifeRegen += RoundOff(extraRegen);
            }
        }

        public override void ModifyHitNPCWithItem(Item item, NPC target, ref NPC.HitModifiers modifiers)
        {
            ExtraCritComputation(ref modifiers);
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)
        {
            ExtraCritComputation(ref modifiers);
        }

        private void ExtraCritComputation(ref NPC.HitModifiers modifiers)
        {
            modifiers.CritDamage += extraCritDamage;
        }

        private int RoundOff(float value) => (int)MathF.Round(value, 0, MidpointRounding.ToEven);
    }
}
