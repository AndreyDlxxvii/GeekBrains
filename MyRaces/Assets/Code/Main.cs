using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

namespace MyRaces
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUI;
        
        private MainMenuController _menuController;
        
        private CursorController _cursorController;
        private BtnCtrlController _btnCtrlController;

        private void Awake()
        {
            //Instantiate(_go, Vector3.zero, quaternion.identity);
            var profilePlayer = new ProfilePlayer(15f);
            profilePlayer.CurrentState.value = GameState.Start;
            _menuController = new MainMenuController(_placeForUI, profilePlayer);
            _cursorController = new CursorController();
            _btnCtrlController = new BtnCtrlController(_placeForUI);
        }

        private void Update()
        {
            _cursorController.OnUpdate();
        }

        private void OnDestroy()
        {
            _menuController?.Dispose();
        }
    }
}