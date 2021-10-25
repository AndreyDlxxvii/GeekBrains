namespace AsteroidGB
{
    public class ObserverController : IController, IOnStart
    {
        private Observer _observer;
        private IOnHit _player;

        public ObserverController(Observer observer, IOnHit player)
        {
            _observer = observer;
            _player = player;
        }
        public void OnStart()
        {
            _observer.Add(_player);
        }
    }
}