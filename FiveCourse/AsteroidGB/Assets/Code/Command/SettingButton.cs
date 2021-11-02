using UnityEngine;
using UnityEngine.UI;

namespace AsteroidGB
{
    public class SettingButton : UIInterface
    {
        [SerializeField] private Text _text;
        public override void Execute()
        {
            gameObject.SetActive(true);
        }

        public override void Cancel()
        {
            gameObject.SetActive(false);
        }
    }
}


