namespace AsteroidGB
{
    public interface IMovement
    {
        float Speed { get; }
        void Movement(float HorizontalMovement, float VerticalMovement);
    }
}