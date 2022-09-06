namespace ArmorModifiers.Modifiers
{
    public abstract class PositivePrefix : BasePrefix
    {
        public override void ModifyValue(ref float valueMult) => valueMult *= 1.2f;
    }
}
