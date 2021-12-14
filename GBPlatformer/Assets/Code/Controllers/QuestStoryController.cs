using System;
using System.Collections.Generic;
using System.Linq;

namespace GBPlatformer
{
    public class QuestStoryController : IQuestStory
    {
        private DoorController _doorController;
        private List<IQuest> _questCollection = new List<IQuest>();
        public bool IsDone => _questCollection.All(value => value.IsCompleted);
        
        public QuestStoryController(List<IQuest> questCollection, DoorController doorController)
        {
            _questCollection = questCollection;
            Subscribe();
            ResetQuest(0);
            _doorController = doorController;
        }

        private void Subscribe()
        {
            foreach (var ell in _questCollection)
            {
                ell.Completed += OnQuestCompleted;
            }
        }

        private void UnSubscribe()
        {
            foreach (var ell in _questCollection)
            {
                ell.Completed -= OnQuestCompleted;
            }
        }

        private void OnQuestCompleted(object sender, IQuest quest)
        {
            int index = _questCollection.IndexOf(quest);
            if (IsDone)
            {
               _doorController.MoveDoors();
            }
            else
            {
                ResetQuest(++index);
            }
        }

        public void ResetQuest(int index)
        {
            if (index < 0 || index>=_questCollection.Count)
            {
               return; 
            }

            var next = _questCollection[index];
            if (next.IsCompleted)
            {
                OnQuestCompleted(this, next);
            }
            else
            {
                _questCollection[index].Reset();
            }
        }
        public void Dispose()
        {
            UnSubscribe();
            foreach (var ell in _questCollection)
            {
                ell.Dispose();
            }
        }
    }
}