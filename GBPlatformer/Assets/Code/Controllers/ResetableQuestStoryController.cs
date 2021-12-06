using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GBPlatformer
{
    public class ResetableQuestStoryController : IQuestStory
    {
        private List<IQuest> _questCollection = new List<IQuest>();
        public bool IsDone => _questCollection.All(value => value.IsCompleted);
        private int _currentIndex;

        public ResetableQuestStoryController(List<IQuest> questCollection)
        {
            _questCollection = questCollection;
            Subscribe();
            ResetQuest();
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
            if (_currentIndex == index)
            {
                _currentIndex++;
                if (IsDone)
                {
                    Debug.Log("store end");
                }
            }
            else
            {
                ResetQuest();
            }
        }

        public void ResetQuest()
        {
            _currentIndex = 0;
            foreach (var ell in _questCollection)
            {
                ell.Reset();
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