namespace AsteroidGB.Chain_of_responsibility
{
    public abstract class BonusHandler
    {
        public BonusHandler Succesor { get; set; }
        public abstract void HandleRequest(int num);
    }
}