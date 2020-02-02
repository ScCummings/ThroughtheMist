using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public bool isNetworked;
    // Start is called before the first frame update
    void Start() {
        if (Instance != null) {
            Destroy(Instance.gameObject);
        }
        Instance = this;
        isNetworked = false;
        DontDestroyOnLoad(this);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            QuitGame();
        }
    }

    public void PlayServer() {
        isNetworked = true;
        //TODO: Photon Stuff
        SceneManager.LoadScene("Party");
    }

    public void PlaySplitscreen() {
        SceneManager.LoadScene("Party");
    }

    public void QuitGame() {
        if(SceneManager.GetActiveScene().name == "Menu") {
            Application.Quit();
            Debug.Log("LOL I'M IN THE EDITOR I CAN'T QUIT ;-;");
        }
        SceneManager.LoadScene("Menu");
    }

    //If GameManager.Instance != null && isNetworked, do Photon Stuff, else resume normal play
}
