using UnityEngine;

namespace GBPlatformer
{
    public class QuestObjectView : LevelObjectView
    {
        [SerializeField] private int _id;

        [SerializeField] private Color _completedColor;
        [SerializeField] private Color _defaultColor;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        private void Start()
        {
            _defaultColor = SpriteRenderer.color;
        }

        public void ProcessComplete()
        {
            SpriteRenderer.color = _completedColor;
        }

        public void ProcecssActivate()
        {
            SpriteRenderer.color = _defaultColor;
        }
    }
}