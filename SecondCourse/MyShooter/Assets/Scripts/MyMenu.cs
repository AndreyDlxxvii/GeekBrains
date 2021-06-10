using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyMenu : MonoBehaviour
{
    public AudioMixer MasterMixer;
    [SerializeField] private GameObject PanelSetting;
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnPause;
    [SerializeField] private Button btnClose;
    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnMute;
    [SerializeField] private Button btnBack;
    [SerializeField] private Slider sldVolume;
    
    private Control1 _player;


    private float _volume;
    private bool _flag;
    private float _time;
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        btnStart.onClick.AddListener(StartGame);
        btnClose.onClick.AddListener(HideMenu);
        btnSetting.onClick.AddListener(ShowPanelSetting);
        btnPause.onClick.AddListener(GamePause);
        btnMute.onClick.AddListener(MuteMyGame);
        btnBack.onClick.AddListener(BackMenu);
        sldVolume.onValueChanged.AddListener(SetVolume);
        _player = GameObject.FindWithTag("Player").GetComponent<Control1>();
    }

    void Update()
    {
        CallMenu();
    }

    private void CallMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _animator.SetBool("CallMenu", true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void GameResume()
    {
        Time.timeScale = 1;
        _player.enabled = true;
    }
    private void HideMenu()
    {
        _animator.SetBool("CallMenu", false);
        Cursor.lockState = CursorLockMode.Locked;
        GameResume();
    }
    private void ShowPanelSetting()
    {
        _animator.SetBool("CallMenu", false);
        _animator.SetBool("CallSettings",true);
    }

    private void SetVolume(float value)
    {
        _volume = value;
        MasterMixer.SetFloat("MasterVolume", Mathf.Lerp(-20, 0, _volume));
    }

    private void GamePause()
    {
        if (_flag)
        {
            Time.timeScale = 1;
            _player.enabled = true;
            _flag = false;
        }
        else
        {
            Time.timeScale = 0;
            _player.enabled = false;
            _flag = true;
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void MuteMyGame()
    {
        AudioListener.volume = 0;
    }

    private void BackMenu()
    {
        _animator.SetBool("CallSettings",false);
        _animator.SetBool("CallMenu", true);
    }
}
