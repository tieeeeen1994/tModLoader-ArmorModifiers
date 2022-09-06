namespace ArmorModifiers.Modifiers
{
    public abstract class NegativePrefix : BasePrefix
    {
        public override void ModifyValue(ref float valueMult) => valueMult *= .8f;
    }
}
