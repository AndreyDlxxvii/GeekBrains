using System;

namespace AsteroidGB
{
    public interface IOnHit
    {
        event Action OnHit;
    }
}