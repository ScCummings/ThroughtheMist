using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public bool isNetworked;
    // Start is called before the first frame update
    void Start() {
        if(Instance != null) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
        isNetworked = false;
    }

    //If GameManager.Instance != null && isNetworked, do Photon Stuff, else resume normal play

    // Update is called once per frame
    void Update() {
        
    }
}
