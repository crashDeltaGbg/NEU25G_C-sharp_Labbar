namespace Lab002
{
    internal class Dice
    {
        private int _numberOfDice = 0;
        private int _sidesPerDie = 0;
        private int _modifier = 0;
        public Dice(int numberOfDice, int sidesPerDie, int modifier)
        {
            this._numberOfDice = numberOfDice;
            this._sidesPerDie = sidesPerDie;
            this._modifier = modifier;
        }

        public int Throw()
        {
            Random die = new();

            int score = 0;

            for (int i = 0; i < _numberOfDice; i++)
            {
                score += die.Next(_sidesPerDie) + 1;
            }

            return score + _modifier;
        }

        public override string ToString()
        {
            return $"{_numberOfDice}d{_sidesPerDie}+{_modifier}";
        }
    }
}
