using System;
using System.Collections.Generic;
using UnityEngine;

namespace GBPlatformer
{
    public class CoinController : IOnController, IDisposable, IOnUpdate
    {
        private SpriteAnimController _spriteAnimController;
        private List<LevelObjectView> _coinObjectViews;
        private LevelObjectView _playerView;

        public CoinController(SpriteAnimController spriteAnimController, List<LevelObjectView> coinObjectViews, LevelObjectView playerView)
        {
            _spriteAnimController = spriteAnimController;
            _coinObjectViews = coinObjectViews;
            _playerView = playerView;

            _playerView.OnLevelObject += OnLevelObjectContact;
            foreach (var ell in _coinObjectViews)
            {
                if (ell is CoinObjectView coin)
                {
                    _spriteAnimController.StartAnimation(coin.SpriteRenderer, AnimState.Run, true);
                }
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinObjectViews.Contains(contactView))
            {
                _spriteAnimController.StopAnimation(contactView.SpriteRenderer);
                if (contactView is CoinObjectView coin)
                {
                    GameObject.Destroy(coin.gameObject);
                }
                
            }
        }
        public void OnUpdate(float deltaTime)
        {
            _spriteAnimController.Update();
        }
        
        public void Dispose()
        {
            _playerView.OnLevelObject -= OnLevelObjectContact;
        }

        
    }
}