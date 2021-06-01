using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeachGM : MonoBehaviour
{
    public Text MyText;
    public Text Hello;
    public GameObject[] GameObjects;
    public Text Health;
    public Text Ammo;
    
    private Control1 _player;
    private bool _flag;
    
    private List<string> _nameTexts = new List<string>
    {
        "Аптечка восстанавливает 10 хп",
        "Боеприпасы +5 патронов",
        "Бессмертие на 30 секунд и воспонение здоровья до максимума",
        "Бесконечные патроны на 30 секунд и воспалнение патронов до максимума",
        "Ключ для открытия ворот",
        "Враги патрулируют зоны и атакуют",
        "Туррель атакует при приблежении",
        "Мина",
        "Бомбы приследуют и наносят урон",
        "Босс"
    };
    
    void Start()
    {
        MyText.text = "Добро пожаловать в обучение.";
        Hello.text = "Для старта нажмите Е";
        _player = GameObject.FindWithTag("Player").GetComponent<Control1>();
    }

    // Update is called once per frame
    void Update()
    {
        StartTeach();
        SetHealthAndAmmo();
    }
    
    private void SetHealthAndAmmo()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            Health.text = GameObject.FindWithTag("Player").GetComponent<Control1>().HealthPlayer.ToString();
            Ammo.text = GameObject.FindWithTag("Player").GetComponent<Control1>().AmmoPlayer.ToString();
        }

    }

    private void StartTeach()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_flag)
        {
            _player.enabled = true;
            Hello.enabled = false;
            MyText.text = "Управление WASD, прыжки Space, долгое зажатие более высокий прыжок";
            _flag = true;
            StartCoroutine(TeachToPlay());
        }
    }

    IEnumerator TeachToPlay()
    {
        yield return new WaitForSeconds(5f);
        MyText.text = "Для того чтобы стрелять нажмите mouse left";
        yield return new WaitForSeconds(5f);
        MyText.text = "Для того чтобы кинуть мину нажмите Mouse right";
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < GameObjects.Length; i++)
        {
            GameObjects[i].gameObject.SetActive(true);
            MyText.text = _nameTexts[i];
            yield return new WaitForSeconds(5f);
            GameObjects[i].gameObject.SetActive(false);
        }
        MyText.enabled = false;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
