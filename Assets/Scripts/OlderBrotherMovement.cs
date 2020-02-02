using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlderBrotherMovement : MonoBehaviourPunCallbacks {
    Rigidbody2D body;

    float horizontal;
    float vertical;
    [SerializeField] bool m_canMove = true;

    public float runSpeed = 5.0f;
    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        if (GameManager.Instance != null && GameManager.Instance.isNetworked) {
            if (!PhotonNetwork.IsMasterClient) {
                GetComponent<PhotonView>().RequestOwnership();
            }
            else {
                GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.PlayerListOthers[0]);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.Instance != null && GameManager.Instance.isNetworked) {
            //TODO: Implement Photon Stuff
            if (!PhotonNetwork.IsMasterClient) {
                if (m_canMove) {
                    float horizontal = Input.GetAxisRaw("Horizontal");
                    float vertical = Input.GetAxisRaw("Vertical");
                    body.velocity = new Vector2(horizontal, vertical) * runSpeed;
                } else {
                    body.velocity = Vector2.zero;
                }
            }
        } else {
            if (m_canMove) {
                float horizontal = Input.GetAxisRaw("P1Horizontal");
                float vertical = Input.GetAxisRaw("P1Vertical");
                body.velocity = new Vector2(horizontal, vertical) * runSpeed;
            } else {
                body.velocity = Vector2.zero;
            }
        }
    }
    public void setCanMove(bool canMove)
    {
        m_canMove = canMove;
    } 
}
