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
            SceneManager.LoadScene("Downtown");
        }
    }
}
