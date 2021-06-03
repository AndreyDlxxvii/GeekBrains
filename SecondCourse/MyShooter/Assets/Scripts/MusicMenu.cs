using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicMenu : MonoBehaviour
{
    private AudioSource _menuMusic;
    private Control1 _player;
    

    private void Awake()
    {
        _menuMusic = GetComponent<AudioSource>();
        
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _menuMusic.pitch = 0.5f;
        _menuMusic.pitch = 0.5f;
    }

    private void Update()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Control1>();
        ChangePitchMainMusic();
    }

    private void ChangePitchMainMusic()
    {
        if (_player.HealthPlayer == 100)
        {
            _menuMusic.pitch = 1f;
        }
        else if (_player.HealthPlayer > 50 && _player.HealthPlayer < 100)
        {
            _menuMusic.pitch = 1.2f;
        }
        else if (_player.HealthPlayer > 20)
        {
            _menuMusic.pitch = 1.5f;
        }
    }
}
