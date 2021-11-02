using System;

namespace AsteroidGB.HW5.Parse
{
    [Serializable]
    public class Unit
    {
        public string type;
        public string health;
        
        public Unit(string type, string health)
        {
            this.type = type;
            this.health = health;
        }
    }
}