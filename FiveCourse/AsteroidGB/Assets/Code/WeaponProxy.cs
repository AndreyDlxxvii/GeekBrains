using System;
using UnityEngine;

namespace AsteroidGB
{
    public class WeaponProxy : IFire
    {
        private readonly IFire _fire;
        private readonly UnlockWeapon _unlockWeapon;

        public WeaponProxy(IFire fire, UnlockWeapon unlockWeapon)
        {
            _fire = fire;
            _unlockWeapon = unlockWeapon;
        }

        public void Fire(Transform gunPosition)
        {
            if (_unlockWeapon.IsUnlock)
            {
                _fire.Fire(gunPosition);
            }
            else
            {
                Debug.Log("Weapon lock");
            }
        }
    }
}