using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DowntownSceneGoal : MonoBehaviour
{
    public Image logo;
    public Image black;
    public void Start() {
        logo.CrossFadeAlpha(0, 0.01f, false);
        black.CrossFadeAlpha(0, 0.01f, false);
        logo.enabled = true;
        black.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame() {
        logo.CrossFadeAlpha(1, 4f, false);
        yield return new WaitForSeconds(6f);
        black.CrossFadeAlpha(1, 4f, false);
        yield return new WaitForSeconds(6f);
        Application.Quit();
    }
}
