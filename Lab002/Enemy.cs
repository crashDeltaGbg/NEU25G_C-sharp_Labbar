namespace Lab002
{
    internal abstract class Enemy : LevelElement
    {
        public string Name { get; set; }

        public int HP { get; set; }

        public Dice Attack { get; set; }

        public Dice Defence { get; set; }

        public Combat Combat { get; } = new();

        public abstract void Update(LevelData level);
    }
}
