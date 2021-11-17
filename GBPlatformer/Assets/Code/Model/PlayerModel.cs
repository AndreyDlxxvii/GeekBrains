namespace GBPlatformer.Model
{
    public class PlayerModel
    {
        public float Live { get; }
        
        public float Speed { get; }
        
        public float JumpSpeed { get; }

        public PlayerModel(float live, float speed, float jumpSpeed)
        {
            Live = live;
            Speed = speed;
            JumpSpeed = jumpSpeed;
        }
    }
}