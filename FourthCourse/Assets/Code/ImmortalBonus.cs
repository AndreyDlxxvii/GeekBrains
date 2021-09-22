using System;
using GeekBrainsHW;
using UnityEngine;

namespace Code
{
    public class ImmortalBonus : MonoBehaviour, IDisposable
    {
        public string TimeOfLiveBonus;
    
        public event Action<bool, int> GetUpBonus = delegate(bool s, int timer) { };

        private void OnTriggerEnter(Collider other)
        {
            int value;
            try
            {
                if (!int.TryParse(TimeOfLiveBonus, out value))
                {
                    throw new FormatException($"Время жизни бонуса должно быть исключительно числом");
                }
                value = int.Parse(TimeOfLiveBonus);
                if (int.Parse(TimeOfLiveBonus) < 0)
                {
                    throw new NewException($"Время жизни бонуса должно быть исключительно положительным числом", value);
                }
                GetUpBonus?.Invoke(true, int.Parse(TimeOfLiveBonus));
            }
            catch (NewException e)
            {
                print($"{e.Message} {e.Value}");
            }
        
            finally
            {
                Dispose();
            }
        
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
