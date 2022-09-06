using System;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers
{
    public class ModArmorPlayer : ModPlayer
    {
        public int extraMinions = 0;
        public int extraLife = 0;
        public float extraCritDamage = 0f;
        public int extraRegen = 0;
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
            Player.maxMinions += extraMinions;
            Player.maxMinions = Math.Max(0, Player.maxMinions);
            Player.statLifeMax += extraLife;
            Player.lifeRegen += extraRegen;
            Player.GetAttackSpeed(DamageClass.Generic) += extraAttackSpeed;
            Player.GetAttackSpeed(DamageClass.Generic) = MathF.Max(.01f, Player.GetAttackSpeed(DamageClass.Generic));
        }

        public override void PostUpdate()
        {
            if (CheckArmorValidity(Main.HoverItem)) Main.HoverItem.accessory = Main.InReforgeMenu;
            if (CheckArmorValidity(Main.mouseItem)) Main.mouseItem.accessory = Main.InReforgeMenu;
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit) => ExtraCritComputation(crit, ref damage, ref knockback);

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) => ExtraCritComputation(crit, ref damage, ref knockback);

        private void ExtraCritComputation(bool crit, ref int damage, ref float knockback)
        {
            if (extraCritDamage > 0 && crit)
            {
                float computedDamage = (damage / 2) * (2 + extraCritDamage);
                damage = (int)MathF.Round(computedDamage, 0, MidpointRounding.ToEven);
                damage = Math.Max(0, damage);
                knockback = (knockback / 1.4f) * (1.4f + extraCritDamage);
                knockback = Math.Max(0f, knockback);
            }
        }

        private bool CheckArmorValidity(Item item) => !item.IsAir && IsArmorPiece(item);
    }
}
