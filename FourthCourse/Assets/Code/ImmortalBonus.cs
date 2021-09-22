using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using GeekBrainsHW;
using UnityEngine;

public class ImmortalBonus : MonoBehaviour, IDisposable
{
    public string TimeOfLiveBonus;
    
    public delegate void OnTriggered(bool n, int timer);
    public event OnTriggered OnTrigger;

    private void OnTriggerEnter(Collider other)
    {
        int value;
        try
        {
            if (!int.TryParse(TimeOfLiveBonus, out value))
            {
                throw new FormatException($"Время жизни бонуса должно быть исключительно положительным числом");
            }
            value = int.Parse(TimeOfLiveBonus);
            if (int.Parse(TimeOfLiveBonus) < 0)
            {
                throw new NewException($"Время жизни бонуса должно быть исключительно положительным числом", value);
            }
            OnTrigger?.Invoke(true, int.Parse(TimeOfLiveBonus));
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
