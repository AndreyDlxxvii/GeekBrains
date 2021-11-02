using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AsteroidGB
{
    public class MyObjectPool
    {
        private List<Rigidbody> _listGO = new List<Rigidbody>();
        private Rigidbody _prefab;
        private Transform _pointOfRespawn;
        private Transform _root;

        public MyObjectPool(Rigidbody prefab)
        {
            _prefab = prefab;
        }

        public Rigidbody Create()
        {
            Rigidbody temp = null;
            if (_listGO.Count == 0 )
            {
                temp = Object.Instantiate(_prefab);
                _listGO.Add(temp);
            }
            else
            {
                for (int i = 0; i < _listGO.Count; i++)
                {
                    if (!_listGO[i].gameObject.activeInHierarchy)
                    {
                        _listGO[i].gameObject.SetActive(true);
                        temp = _listGO[i];
                        break;
                    }
                    else if (i == _listGO.Count-1)
                    {
                        temp = Object.Instantiate(_prefab);
                        _listGO.Add(temp);
                        break;
                    }
                }
            }
            
            return temp;
        }

        public void Hide(Rigidbody _rigidbody)
        {
            _rigidbody.gameObject.SetActive(false);
            _rigidbody.velocity = Vector3.zero;
        }
    }
}