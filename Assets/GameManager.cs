using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks {
    public GameObject youngerBrother;
    public GameObject olderBrother;
    public static GameManager Instance;
    public bool isNetworked;
    public Launcher launcher;
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
        //TODO: Photon Stuff
        launcher.Connect();
        isNetworked = true;
    }

    public void PlaySplitscreen() {
        SceneManager.LoadScene("Party");
    }

    public void QuitGame() {
        if (isNetworked) {
            PhotonNetwork.Disconnect();
            isNetworked = false;
            SceneManager.LoadScene("Menu");
        } else {
            if (SceneManager.GetActiveScene().name == "Menu") {
                Application.Quit();
                Debug.Log("LOL I'M IN THE EDITOR I CAN'T QUIT ;-;");
            }
            SceneManager.LoadScene("Menu");
        }
        
    }

    //If GameManager.Instance != null && isNetworked, do Photon Stuff, else resume normal play

    public override void OnPlayerEnteredRoom(Player other) {
        base.OnPlayerEnteredRoom(other);
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2) {
            Debug.Log("When there's two players, load the first scene");
            // #Critical
            // Load the First level, only when there's two players
            if (PhotonNetwork.IsMasterClient) {
                PhotonNetwork.LoadLevel("Party");
            }
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {
        base.OnPlayerLeftRoom(otherPlayer);
        Debug.Log("You're the last one standing");
        PhotonNetwork.Disconnect();
    }
}
