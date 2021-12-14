using System.Collections.Generic;
using UnityEngine;

namespace GBPlatformer
{
    public class BulletPool
    {
        private List<Rigidbody2D> _listGO = new List<Rigidbody2D>();
        private Rigidbody2D _prefab;
        private int count;

        public BulletPool(Rigidbody2D prefab)
        {
            _prefab = prefab;
        }

        public Rigidbody2D Create(Transform spawnPos)
        {
            Rigidbody2D temp = null;
            if (_listGO.Count == 0 )
            {
                temp = Object.Instantiate(_prefab, spawnPos.position, Quaternion.identity);
                _listGO.Add(temp);
            }
            else
            {
                for (int i = 0; i < _listGO.Count; i++)
                {
                    if (!_listGO[i].gameObject.activeInHierarchy)
                    {
                        _listGO[i].gameObject.SetActive(true);
                        _listGO[i].position = spawnPos.position;
                        temp = _listGO[i];
                        break;
                    }
                    else if (i == _listGO.Count-1)
                    {
                        temp = Object.Instantiate(_prefab, spawnPos.position, Quaternion.identity);
                        _listGO.Add(temp);
                        break;
                    }
                }
            }
            
            return temp;
        }

        public void Hide(Rigidbody2D _rigidbody)
        {
            _rigidbody.gameObject.SetActive(false);
            _rigidbody.velocity = Vector3.zero;
        }
    }
}