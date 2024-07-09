using ArmorModifiers.Configs;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ArmorModifiers
{
	public class ArmorModifiers : Mod
	{
        public static List<int> armorPrefixes;

        public static bool IsArmorPiece(Item item) => item.headSlot != -1 || item.bodySlot != -1 || item.legSlot != -1;

		public static ModArmorPlayer ModArmorPlayer(Player player) => player.GetModPlayer<ModArmorPlayer>();

        public static ServerConfig ServerConfig => ModContent.GetInstance<ServerConfig>();

		public override void Load()
		{
            armorPrefixes = [];
            On_Item.CanHavePrefixes += Item_CanHavePrefixes;
        }

        public override void Unload()
        {
            armorPrefixes = null;
            On_Item.CanHavePrefixes -= Item_CanHavePrefixes;
        }

        private bool Item_CanHavePrefixes(On_Item.orig_CanHavePrefixes orig, Item self)
        {
            return orig(self) || (self.type != ItemID.None && self.maxStack == 1 && IsArmorPiece(self));
        }
    }
}