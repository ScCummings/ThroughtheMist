using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DowntownSceneGoal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (GameManager.Instance != null && GameManager.Instance.isNetworked) {
            PhotonNetwork.Disconnect();
            GameManager.Instance.isNetworked = false;
            SceneManager.LoadScene("Menu");
        } else {
            SceneManager.LoadScene("Menu");
        }
    }
}
