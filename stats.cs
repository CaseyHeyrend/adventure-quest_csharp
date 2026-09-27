namespace MiniRPG
{
    public struct Stats
    {
        public int Health;
        public int Mana;
        public int Attack;
        public int Defense;

        public Stats(int health, int mana, int attack, int defense)
        {
            Health = health;
            Mana = mana;
            Attack = attack;
            Defense = defense;
        }
    }
}