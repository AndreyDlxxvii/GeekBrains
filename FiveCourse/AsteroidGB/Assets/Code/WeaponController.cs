using UnityEngine;

namespace AsteroidGB
{
    public class WeaponController
    {
        private RefResources _refResources;
        private IFire _fire;

        public WeaponController(RefResources refResources)
        {
            _refResources = refResources;
           _fire = new BulletFire(_refResources.BulletPrefab);
        }

        public void Atack(Transform gunPosition)
        {
            _fire.Fire(gunPosition);
        }

        // Изменене видя оружия
        public void ChangeWeapon()
        {
            _fire = new LaserFire();
        }
    }
}