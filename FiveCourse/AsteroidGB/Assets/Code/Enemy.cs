namespace AsteroidGB
{
    internal abstract class Enemy
    {
        public float Speed { get; set; }

        public abstract void Move(float speed);
        
    }
}