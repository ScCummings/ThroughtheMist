using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartySceneGoal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "YoungerBrother") {
            //TODO: Add fog clear
            if(GameManager.Instance != null && GameManager.Instance.isNetworked) {
                if(PhotonNetwork.IsMasterClient) {
                    PhotonNetwork.LoadLevel("Subway");
                }
            } else {
                SceneManager.LoadScene("Subway");
            }
        }
    }
}
