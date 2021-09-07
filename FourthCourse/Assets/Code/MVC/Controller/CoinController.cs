namespace CodeGeek
{
    public class CoinController : IMyUpdates
    {
        private CoinModel _coinModel;
        private CoinView _coinView;

        public CoinController(CoinModel coinModel, CoinView CoinView)
        {
            _coinModel = coinModel;
            _coinView = CoinView;
        }

 
        public void OnUpdate()
        {
            if (_coinView!=null)
            {
                _coinView.FlayPingPong(_coinModel.FlayPingPong);
            }
        }

        public void OnFixedUpdate()
        {
        }
    }
}