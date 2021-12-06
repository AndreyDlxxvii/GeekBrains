

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GBPlatformer
{
    public class QuestCofiguratorController : IOnController, IOnStart
    {
        private QuestObjectView _questObjectView;
        private QuestController _singleQuest;
        private CoinQuestModel _coinQuestModel;
        private DoorController _doorController;

        private QuestStoryConfig[] _questStoryConfigs;
        private QuestObjectView[] _questObjectViews;
        
        private List<IQuestStory> _questsStories = new List<IQuestStory>();
        
        private Dictionary<QuestType, Func<IQuestModel>> _questFactories = 
            new Dictionary<QuestType, Func<IQuestModel>>(1);
        private Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>  _questStoryFactories = 
            new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>(2);

        public QuestCofiguratorController(QuestView questView, DoorController doorController)
        {
            _questObjectView = questView.SingleQuest;
            _coinQuestModel = new CoinQuestModel();
            _doorController = doorController;

            _questStoryConfigs = questView.QuestStoryConfigs;
            _questObjectViews = questView.QuestObjectViews;
        }
        public void OnStart()
        {
            _singleQuest = new QuestController(_questObjectView, _coinQuestModel);
            _singleQuest.Reset();
            
            _questStoryFactories.Add(QuestStoryType.Common, questCollection => new QuestStoryController(questCollection, _doorController));
            _questStoryFactories.Add(QuestStoryType.Resetable, questCollection => new ResetableQuestStoryController(questCollection));
            
            _questFactories.Add(QuestType.GetCoins, ()=> new CoinQuestModel());
            
            _questsStories = new List<IQuestStory>();
            foreach (var ell in _questStoryConfigs)
            {
                _questsStories.Add(CreateQuestStory(ell));
            }
        }

        private IQuestStory CreateQuestStory(QuestStoryConfig cfg)
        {
            List<IQuest> quests = new List<IQuest>();
            foreach (var ell in cfg.quests)
            {
                IQuest quest = CreateQuest(ell);
                if (quest == null) continue;
                quests.Add(quest);
                Debug.Log("AddQuests");
            }

            return _questStoryFactories[cfg.questStoryType].Invoke(quests);
        }

        private IQuest CreateQuest(QuestConfig config)
        {
            int questID = config.id;
            QuestObjectView questObjectView = _questObjectViews.FirstOrDefault(value => value.Id == config.id);
            if (questObjectView == null)
            {
                Debug.Log("Not found");
                return null;
            }

            if (_questFactories.TryGetValue(config.questType, out var factory))
            {
                IQuestModel questModel = factory.Invoke();
                return new QuestController(questObjectView, questModel);
            }
            Debug.Log("No model");
            return null;
        }
        
    }
}