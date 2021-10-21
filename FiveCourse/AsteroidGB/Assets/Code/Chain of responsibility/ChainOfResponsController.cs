
using AsteroidGB.Chain_of_responsibility;
using UnityEngine;
using UnityEngine.Rendering;

namespace AsteroidGB
{
    public class ChainOfResponsController : IOnStart, IController
    {
        private BonusHandler _firstBonusHandler;
        private BonusHandler _secondBonusHandler;


        public ChainOfResponsController(BonusHandler firstBonusHandler, BonusHandler secondBonusHandler)
        {
            _firstBonusHandler = firstBonusHandler;
            _secondBonusHandler = secondBonusHandler;
        }

        public void OnStart()
        {
            //TODO костыли
            var badBonus = Object.FindObjectOfType<BadBonus>();
            var goodBonus = Object.FindObjectOfType<GoodBonus>();
            badBonus.GETBonus += CallCahin;
            goodBonus.GETBonus += CallCahin;

        }

        private void CallCahin(int i)
        {
            _firstBonusHandler.Succesor = _secondBonusHandler;
            _firstBonusHandler.HandleRequest(i);
        }
    }
}