namespace MyRaces
{
    public class GameController : BaseController
    {
        public GameController()
        {
            var carController = new CarController();
            AddControler(carController);
        }
    }
}