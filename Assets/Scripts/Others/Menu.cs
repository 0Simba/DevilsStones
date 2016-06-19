using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

    public Button play;
    public Button quit;

    public string playScene;


    void Start () {
        play.onClick.AddListener(Launch);
        quit.onClick.AddListener(QuitGame);
    }


    public void Launch () {
        SceneManager.LoadScene(playScene);
    }


    public void QuitGame () {
        Application.Quit();
    }

}