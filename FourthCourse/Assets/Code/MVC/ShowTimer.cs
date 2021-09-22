using UnityEngine.UI;

namespace Code.MVC
{
    public sealed class ShowTimer
    {
        private Text _timerText;

        public ShowTimer(Text textTimer, int timer)
        {
            _timerText = textTimer;
            _timerText.text = $"Timer: {timer}";
        }

        public void Show(int timer)
        {
            _timerText.text = $"Timer: {timer}";
        }
    }
}
