using UnityEngine.UI;

namespace Code
{
    public sealed class ShowTextGame
    {
        private Text _showTextGame;
        
        public ShowTextGame(Text showTextGame)
        {
            _showTextGame = showTextGame;
        }

        public void ShowWinText(string myText)
        {
            _showTextGame.text = myText;
        }
    }
}