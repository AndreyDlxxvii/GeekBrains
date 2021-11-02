using UnityEngine;

namespace AsteroidGB
{
    public class UserInterface : IController, IOnStart, IOnUpdate
    {
        private SettingButton _settingButton;
        private RestartButton _restartButton;
        private UIInterface[] uiInterfaces;
        public void OnStart()
        {
            uiInterfaces = Object.FindObjectsOfType<UIInterface>();
            foreach (var ell in uiInterfaces)
            {
                ell.Cancel();
                if (ell is SettingButton)
                {
                    _settingButton = (SettingButton) ell;
                }

                if (ell is RestartButton)
                {
                    _restartButton = (RestartButton) ell;
                }
            }
        }

        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!_restartButton.isActiveAndEnabled)
                {
                    _restartButton.Execute();
                }
                else
                {
                    _restartButton.Cancel();
                }
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                if (!_settingButton.isActiveAndEnabled)
                {
                    _settingButton.Execute();
                }
                else
                {
                    _settingButton.Cancel();
                }
                
            }
        }
    }
}