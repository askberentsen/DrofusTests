namespace Task1
{
    internal class Ware
    {
        public string Name { get; }
        public uint DefaultPrice { get; } = 10;

        public Ware(string name)
        {
            this.Name = name;
        }

        public Ware(string name, uint defaultPrice)
        {
            Name = name;
            DefaultPrice = defaultPrice;
        }
    }
}