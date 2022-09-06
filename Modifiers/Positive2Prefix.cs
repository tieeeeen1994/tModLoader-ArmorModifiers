namespace ArmorModifiers.Modifiers
{
    public abstract class Positive2Prefix : BasePrefix
    {
        public override void ModifyValue(ref float valueMult) => valueMult *= 1.1f;
    }
}
