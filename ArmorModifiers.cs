using ArmorModifiers.Configs;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

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
            armorPrefixes = new() { };
        }

        public override void Unload()
        {
            armorPrefixes = null;
        }
    }
}