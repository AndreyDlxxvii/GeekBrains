using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcesLvl1 : MonoBehaviour
{
    public float i = 2f;
    private AutoExposure _autoExposure = null;
    private PostProcessVolume _volume;
    void Start()
    {
        _volume = GetComponent<PostProcessVolume>();

        _volume.profile.TryGetSettings(out _autoExposure);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EyeAdaptation());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _autoExposure.minLuminance.value = 1.5f;
        }
    }

    IEnumerator EyeAdaptation()
    {
        yield return new WaitForSeconds(5f);
        _autoExposure.minLuminance.value = 0f;
    }
}
