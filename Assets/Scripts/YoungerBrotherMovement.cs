using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoungerBrotherMovement : MonoBehaviourPunCallbacks {
    Rigidbody2D body;
    float horizontal;
    float vertical;

    public float runSpeed = 5.0f;
    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        if(GameManager.Instance != null && GameManager.Instance.isNetworked) {
            if (PhotonNetwork.IsMasterClient) {
                GetComponent<PhotonView>().RequestOwnership();
            }
            else {
                GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.PlayerListOthers[0]);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.Instance != null && GameManager.Instance.isNetworked) {
            //TODO: Implement Photon Code Here
            if(PhotonNetwork.IsMasterClient) {
                float horizontal = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");
                body.velocity = new Vector2(horizontal, vertical) * runSpeed;
                Debug.Log("BODY VELOCITY: " + body.velocity);
            }
        } else {
            float horizontal = Input.GetAxisRaw("P2Horizontal");
            float vertical = Input.GetAxisRaw("P2Vertical");
            body.velocity = new Vector2(horizontal, vertical) * runSpeed;
        }
    }
}
