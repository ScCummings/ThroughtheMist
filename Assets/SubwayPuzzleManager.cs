using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubwayPuzzleManager : MonoBehaviour
{

    public SubwayPuzzle[] puzzles;

    // Update is called once per frame
    void Update() {
        bool solved = true;
        foreach (SubwayPuzzle sp in puzzles) {
            if (!sp.isComplete) {
                solved = false;
            }
        }
        if(solved) {
            if (GameManager.Instance != null && GameManager.Instance.isNetworked) {
                if (PhotonNetwork.IsMasterClient) {
                    PhotonNetwork.LoadLevel("Downtown");
                }
            } else {
                SceneManager.LoadScene("Downtown");
            }
        }
    }
}
