using System;

namespace GBPlatformer
{
    public class QuestController : IQuest
    {
        private QuestObjectView _questObjectView;
        private bool _active;
        private IQuestModel _questModel;
        
        public event EventHandler<IQuest> Completed;
        public bool IsCompleted { get; private set; }

        public QuestController(QuestObjectView questObjectView, IQuestModel questModel)
        {
            _questObjectView = questObjectView;
            _questModel = questModel;
            
        }

        private void OnContact(LevelObjectView levelObjectView)
        {
            bool complete = _questModel.TryComplete(levelObjectView.gameObject);
            if (complete)
            {
                Complete();
            }
        }
        private void Complete()
        {
            if (!_active)
                return;
            _active = false;
            IsCompleted = true;
            _questObjectView.OnLevelObject -= OnContact;
            _questObjectView.ProcessComplete();
            OnCompleted();
        }
        private void OnCompleted()
        {
            Completed?.Invoke(this, this);
        }
        
        public void Reset()
        {
            if (_active) return;
            _active = true;
            _questObjectView.OnLevelObject += OnContact;
            _questObjectView.ProcecssActivate();
        }
        
        public void Dispose()
        {
            _questObjectView.OnLevelObject -= OnContact;
        }
    }
}