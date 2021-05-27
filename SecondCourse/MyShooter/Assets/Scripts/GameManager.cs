using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public Camera MyCam;
    public GameObject MyPlayer;
    public Text GameOver;
    public Button RestartButton;
    public Animator Road;
    public Animator SecondDoor;
    
    public bool CheckFinish;
    private int _count = 0;


    public void EndOfGame(bool _checkEndGame)
    {
        //Destroy(MyPlayer.transform.GetChild(0).gameObject);
        MyPlayer.transform.GetChild(0).gameObject.SetActive(false);
        MyPlayer.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled=false;
        MyPlayer.transform.GetChild(0).gameObject.transform.position = new Vector3(0, 0, 0);
        GameOver.gameObject.SetActive(true);
        if (!_checkEndGame)
        {
            GameOver.text = "Game Over";
        }
        else GameOver.text = "Winner";
        RestartButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

    }
    
    public void RestartGameButton()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaceScore()
    {
        _count++;
        CheckCount();
    }

    private void CheckCount()
    {
        switch (_count)
        {
            case 1:
                Road.SetBool("Road", true);
                break;
            case 5:
                SecondDoor.SetBool("DoorOpen", true);
                break;
        }
    }
}
