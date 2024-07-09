using System;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers
{
    public class ModArmorPlayer : ModPlayer
    {
        public float extraMinions = 0f;
        public int extraLife = 0;
        public float extraCritDamage = 0f;
        public float extraRegen = 0f;
        public float extraAttackSpeed = 0f;

        public override void ResetEffects()
        {
            extraMinions = 0;
            Player.statLifeMax -= extraLife;
            extraLife = 0;
            extraCritDamage = 0f;
            extraRegen = 0;
            extraAttackSpeed = 0f;
        }

        public override void UpdateEquips()
        {
            Player.maxMinions += RoundOff(extraMinions);
            Player.maxMinions = Math.Max(0, Player.maxMinions);
            Player.statLifeMax += extraLife;
            Player.lifeRegen += RoundOff(extraRegen);
            Player.GetAttackSpeed(DamageClass.Generic) += extraAttackSpeed;
            Player.GetAttackSpeed(DamageClass.Generic) = MathF.Max(.01f, Player.GetAttackSpeed(DamageClass.Generic));
        }

        public override void PostUpdate()
        {
            if (CheckArmorValidity(Main.HoverItem)) Main.HoverItem.accessory = Main.InReforgeMenu;
            if (CheckArmorValidity(Main.mouseItem)) Main.mouseItem.accessory = Main.InReforgeMenu;
        }

        public override void ModifyHitNPCWithItem(Item item, NPC target, ref NPC.HitModifiers modifiers) => ExtraCritComputation(ref modifiers);

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers) => ExtraCritComputation(ref modifiers);

        private void ExtraCritComputation(ref NPC.HitModifiers modifiers)
        {
            modifiers.CritDamage += extraCritDamage;
            modifiers.Knockback = (modifiers.Knockback / 1.4f) * (1.4f + extraCritDamage);
        }

        private bool CheckArmorValidity(Item item) => !item.IsAir && IsArmorPiece(item);

        private int RoundOff(float value)
        {
            return (int)MathF.Round(value, 0, MidpointRounding.ToEven);
        }
    }
}
