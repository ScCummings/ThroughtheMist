using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayPuzzle : MonoBehaviour
{
    public bool isComplete;
    // Start is called before the first frame update
    void Start()
    {
        isComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isComplete = true;
    }
}
