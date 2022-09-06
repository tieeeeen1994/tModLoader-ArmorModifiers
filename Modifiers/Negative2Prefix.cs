namespace ArmorModifiers.Modifiers
{
    public abstract class Negative2Prefix : BasePrefix
    {
        public override void ModifyValue(ref float valueMult) => valueMult *= .9f;
    }
}
