using System;
using JoostenProductions;
using UnityEngine;
using UnityEngine.UI;

namespace MyRaces
{
    internal class BtnControlView : BaseInputView
    {
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;
        
        public override void Init(SubscribeProperty <float> leftMove, SubscribeProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        public void Move()
        {
            _leftButton.onClick.AddListener(Test);
            _rightButton.onClick.AddListener(Test);
        }

        private void Test()
        {
            Debug.Log("move");
        }
    }
}