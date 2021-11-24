using System;
using System.Collections.Generic;
using UnityEngine;

namespace GBPlatformer
{
    public class CoinController : IOnController, IDisposable, IOnUpdate
    {
        private SpriteAnimController _spriteAnimController;
        private List<CoinObjectView> _coinObjectViews;
        private LevelObjectView _playerView;

        public CoinController(SpriteAnimController spriteAnimController, List<CoinObjectView> coinObjectViews, LevelObjectView playerView)
        {
            _spriteAnimController = spriteAnimController;
            _coinObjectViews = coinObjectViews;
            _playerView = playerView;

            _playerView.OnLevelObject += OnLevelObjectContact;
            foreach (var ell in _coinObjectViews)
            {
                _spriteAnimController.StartAnimation(ell.SpriteRenderer, AnimState.Run, true);
            }
        }

        private void OnLevelObjectContact(CoinObjectView contactView)
        {
            if (_coinObjectViews.Contains(contactView))
            {
                _spriteAnimController.StopAnimation(contactView.SpriteRenderer);
                GameObject.Destroy(contactView.gameObject);
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