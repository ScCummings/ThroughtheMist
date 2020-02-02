using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFog : MonoBehaviour
{
    public bool FogHasBeenCleared = false;
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FogHasBeenCleared = true;
            Destroy(gameObject);
        }
    }
}
