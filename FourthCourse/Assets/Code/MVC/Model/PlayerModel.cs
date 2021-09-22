namespace Code.MVC.Model
{
    public readonly struct PlayerModel
    {
        public float Speed { get; }
        public float JumpForce { get; }

        public PlayerModel(float speed, float jumpForce)
        {
            Speed = speed;
            JumpForce = jumpForce;
        }
    }
}