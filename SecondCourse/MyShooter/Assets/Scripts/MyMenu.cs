using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyMenu : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private GameObject PanelSetting;
    
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnPause;
    [SerializeField] private Button btnClose;
    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnMute;
    [SerializeField] private Button btnBack;
    private Control1 _player;
   

    private bool _flag;
    private float _time;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        btnStart.onClick.AddListener(StartGame);
        btnClose.onClick.AddListener(HideMenu);
        btnSetting.onClick.AddListener(ShowPanelSetting);
        btnPause.onClick.AddListener(GamePause);
        btnMute.onClick.AddListener(MuteMyGame);
        btnBack.onClick.AddListener(BackMenu);
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
        if (PanelSetting.activeSelf)
        {
            PanelSetting.SetActive(false);
        }

        GameResume();
    }
    private void ShowPanelSetting()
    {
        PanelSetting.SetActive(true);
    }

    private void GamePause()
    {
        Time.timeScale = 0;
        _player.enabled = false;
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
        
    }
}
