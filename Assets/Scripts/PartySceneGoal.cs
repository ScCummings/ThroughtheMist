using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartySceneGoal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "YoungerBrother") {
            //TODO: Add fog clear
            SceneManager.LoadScene("Subway");
        }
    }
}
