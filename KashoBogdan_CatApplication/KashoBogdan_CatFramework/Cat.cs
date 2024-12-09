namespace KashoBogdan_CatFramework
{
    public abstract class Cat
    {
        public abstract int Fluffiness { get; }
        public abstract string FluffinessCheck();

        public override string ToString()
        {
            return $"A cat with fluffiness: {Fluffiness}";
        }
    }
}
