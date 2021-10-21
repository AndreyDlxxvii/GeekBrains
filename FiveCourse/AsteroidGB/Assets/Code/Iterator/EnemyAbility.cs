namespace AsteroidGB.Iterator
{
    public class EnemyAbility : IAbility
    {
        public string Name { get; }
        public int Value { get; }

        public EnemyAbility(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}