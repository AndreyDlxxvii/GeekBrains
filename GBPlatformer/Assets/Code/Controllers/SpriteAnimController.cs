using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBPlatformer
{
    public class SpriteAnimController : IDisposable
    {
        
        private SpriteAnimConfig _spriteAnimConfig;
        private Dictionary<SpriteRenderer, Animation> _activeAnimation = new Dictionary<SpriteRenderer, Animation>();
        private LevelObjectView _playerView;

        public SpriteAnimController(SpriteAnimConfig spriteAnimConfig)
        {
            _spriteAnimConfig = spriteAnimConfig;
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, AnimState animState, bool loop)
        {
            var temp = _spriteAnimConfig.Sequences.Find(sequence => sequence.Track == animState);
            if (_activeAnimation.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Sleep = false;
                animation.Loop = loop;
                animation.Speed = temp.Speed;
                if (animation.Track != animState)
                {
                    animation.Track = animState;
                    animation.Sprites = temp.SPrites;
                    animation.Counter = 0;
                }
            }
            else
            {
               
                _activeAnimation.Add(spriteRenderer, new Animation()
                 {
                     Loop = loop,
                     Speed = temp.Speed,
                     Track = animState,
                     Sprites = temp.SPrites
                 });
            }
        }

        public void StopAnimation(SpriteRenderer spriteRenderer)
        {
            if (_activeAnimation.ContainsKey(spriteRenderer))
            {
                _activeAnimation.Remove(spriteRenderer);
            }
        }
        public void Update()
        {
            foreach (var ell in _activeAnimation)
            {
                ell.Value.Update();
                if (ell.Value.Counter < ell.Value.Sprites.Count)
                {
                    ell.Key.sprite = ell.Value.Sprites[(int) ell.Value.Counter];
                }
            }
        }

        public void Dispose()
        {
            _activeAnimation.Clear();
        }
    }
}