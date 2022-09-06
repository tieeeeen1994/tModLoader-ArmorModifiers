using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ArmorModifiers.Configs
{
    public class ServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Base Cost Armor Reforging Multiplier")]
        [Tooltip("The reforge cost to be multiplied for Armor.")]
        [DefaultValue(10f)]
        [Range(1f, 100f)]
        [Increment(1)]
        public float reforgeCostMultiplier;
    }
}
