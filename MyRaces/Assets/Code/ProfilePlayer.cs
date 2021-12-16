namespace MyRaces
{
    public class ProfilePlayer
    { 
        public SubscribeProperty<GameState> CurrentState { get; }
        public CarModel CurrentCar { get; }
        
        public ProfilePlayer(float speed)
        {
            CurrentState = new SubscribeProperty<GameState>();
            CurrentCar = new CarModel(speed);
        }
    }
}