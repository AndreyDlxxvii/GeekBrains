using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public Camera MyCam;
    public GameObject MyPlayer;
    public Text GameOver;
    public Button RestartButton;
    
    // Start is called before the first frame update

    public void EndOfGame()
    {
        //Destroy(MyPlayer.transform.GetChild(0).gameObject);
        MyPlayer.transform.GetChild(0).gameObject.SetActive(false);
        MyPlayer.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled=false;
        MyPlayer.transform.GetChild(0).gameObject.transform.position = new Vector3(0, 0, 0);
        GameOver.gameObject.SetActive(true);
        GameOver.text = "Game Over";
        RestartButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

    }
    
    public void RestartGameButton()
    {
        SceneManager.LoadScene(0);
    }

}
