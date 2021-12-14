using System;
using UnityEngine;

namespace GBPlatformer
{
    public class EnemysController : IOnController, IOnUpdate
    {
        private EnemyObjectView _enemyObjectViews;
        private Transform _targetTransform;
        private Transform _transformPlayer;

        private Transform[] _wayPoints;
        private bool _flag;

        public EnemysController(EnemyObjectView enemyObjectViews, LevelObjectView playerView)
        {
            if (enemyObjectViews != null)
            {
                _enemyObjectViews = enemyObjectViews;
                _transformPlayer = playerView.Transform;
                _targetTransform = NextWayPoint.NextPoint(_enemyObjectViews.EnemyConfig.WayPoints);
                _wayPoints = enemyObjectViews.EnemyConfig.WayPoints;
            }
            
        }


        public void OnUpdate(float deltaTime)
        {
            var t = Vector2.SqrMagnitude(_transformPlayer.position - _enemyObjectViews.Transform.position);
            if ( t < 20f)
            {
                _targetTransform = _transformPlayer;
                _flag = true;
            }
            else
            {
                if (_flag)
                {
                    _targetTransform = NextWayPoint.NextPoint(_enemyObjectViews.EnemyConfig.WayPoints);
                    _flag = false;
                }
                
                var sqrMagnitude =
                    Vector2.SqrMagnitude(_targetTransform.position - _enemyObjectViews.Transform.position);
                if (sqrMagnitude <= _enemyObjectViews.EnemyConfig.MinTargetDist)
                {
                    _targetTransform = NextWayPoint.NextPoint(_enemyObjectViews.EnemyConfig.WayPoints);
                }
            }
            var direction = (_targetTransform.position - _enemyObjectViews.Transform.position).normalized;
            _enemyObjectViews.Rigidbody2D.velocity = direction * _enemyObjectViews.EnemyConfig.Speed;
        }
    }
}