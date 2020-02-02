using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFog : MonoBehaviour
{
    public bool FogHasBeenCleared = false;
    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.tag == "YoungerBrother" && Input.GetKeyDown(KeyCode.Space)) {
            FogHasBeenCleared = true;
            if(GameManager.Instance != null && GameManager.Instance.isNetworked) {
                GetComponent<PhotonView>().RequestOwnership();
                PhotonView photonView = PhotonView.Get(GetComponent<PhotonView>());
                photonView.RPC("DestroyFog", RpcTarget.All);
            } else {
                Destroy(gameObject);
            }

        }
    }

    [PunRPC] public void DestroyFog() {
        Destroy(gameObject);
    }
}
