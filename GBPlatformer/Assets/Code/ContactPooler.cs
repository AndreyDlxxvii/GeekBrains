using UnityEngine;

namespace GBPlatformer
{
    public class ContactPooler
    {
        private ContactPoint2D[] _contactFilter2Ds = new ContactPoint2D[10];

        private const float _treshhold = 0.7f;
        private int _countOfContact;
        private Collider2D _collider2D;

        public bool IsGrounded { get; private set; }
        public bool LeftContact { get; private set; }
        public bool RightContact { get; private set; }

        public ContactPooler(Collider2D collider2D)
        {
            _collider2D = collider2D;
        }

        public void Update()
        {
            IsGrounded = false;
            LeftContact = false;
            RightContact = false;
            _countOfContact = _collider2D.GetContacts(_contactFilter2Ds);
            if (_countOfContact > 0)
            {
                foreach (var ell in _contactFilter2Ds)
                {
                    if (ell.normal.y > _treshhold)
                    {
                        IsGrounded = true;
                    }

                    if (ell.normal.x > _treshhold)
                    {
                        LeftContact = true;
                    }

                    if (ell.normal.y > -_treshhold)
                    {
                        RightContact = true;
                    }
                }
            }
        }
    }
}