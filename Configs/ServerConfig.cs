using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ArmorModifiers.Configs
{
    public class ServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Basic")]
        [DefaultValue(10)]
        [Range(1, 100)]
        [Increment(1)]
        public int reforgeCostMultiplier;

        [Header("PrefixAdjustments")]
        [DefaultValue(.5f)]
        [Range(.1f, 10f)]
        [Increment(.1f)]
        public float minionIncrease;

        [DefaultValue(20)]
        [Range(1, 100)]
        [Increment(1)]
        public int healthIncrease;

        [DefaultValue(.2f)]
        [Range(.01f, 1f)]
        [Increment(.01f)]
        public float critIncrease;

        [DefaultValue(.5f)]
        [Range(.1f, 10f)]
        [Increment(.1f)]
        public float regenIncrease;

        [DefaultValue(.05f)]
        [Range(.01f, 1f)]
        [Increment(.01f)]
        public float attackSpeedIncrease;

        [DefaultValue(.05f)]
        [Range(.01f, 1f)]
        [Increment(.01f)]
        public float whipRangeIncrease;

        [Header("PrefixToggle")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool minionToggle;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool healthToggle;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool critToggle;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool regenToggle;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool attackSpeedToggle;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool whipRangeToggle;
    }
}
