using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AsteroidGB
{
    public class MyObjectPool
    {
        private List<GameObject> _listGO = new List<GameObject>();
        private GameObject _prefab;
        private Transform _pointOfRespawn;
        private Transform _root;

        public MyObjectPool(GameObject prefab)
        {
            _prefab = prefab;
        }

        public GameObject Create()
        {
            GameObject temp = null;
            if (_listGO.Count == 0 )
            {
                temp = Object.Instantiate(_prefab);
                _listGO.Add(temp);
            }
            else
            {
                for (int i = 0; i < _listGO.Count; i++)
                {
                    if (!_listGO[i].activeInHierarchy)
                    {
                        _listGO[i].SetActive(true);
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

        public void Hide(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}