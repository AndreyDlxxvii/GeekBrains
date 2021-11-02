using System.Collections;
using System.Collections.Generic;
using AsteroidGB.Iterator;
using UnityEngine;

namespace AsteroidGB
{
    public class UFO : IEnemy
    {
        private GameObject _gameObject;
        private List<IAbility> _listAbility = new List<IAbility>();
        public UFO(GameObject prefab, List<IAbility> listAbility)
        {
            _gameObject = prefab;
            _listAbility = listAbility;
        }

        //TODO сделать рандомный спавн
        public UFOView Create()
        {
            return Object.Instantiate(_gameObject, Vector3.right, Quaternion.identity).GetComponent<UFOView>();
        }

        // public IEnumerable<IAbility> GetAbility()
        // {
        //     while(true)
        //     {
        //         yield return _listAbility[Random.Range(0, _listAbility.Count)];
        //     }
        // }
        //
        // public IEnumerable<IAbility> GetAbilities(string index)
        // {
        //     foreach (var ell in _listAbility)
        //     {
        //         if (ell.Name == index)
        //         {
        //             yield return ell;
        //         }
        //     }
        // }
        //
        // public IEnumerator GetEnumerator()
        // {
        //     for (int i = 0; i < _listAbility.Count; i++)
        //     {
        //         yield return _listAbility[i];
        //     }
        // }
        //
        // public IAbility this[int i] => _listAbility[i];
    }
}