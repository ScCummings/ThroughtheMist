using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoungerBrotherMovement : MonoBehaviour {
    Rigidbody2D body;
    float horizontal;
    float vertical;

    public float runSpeed = 5.0f;
    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.Instance != null && GameManager.Instance.isNetworked) {
            //TODO: Implement Photon Code Here
            body.velocity = Vector2.zero;
        } else {
            float horizontal = Input.GetAxisRaw("P2Horizontal");
            float vertical = Input.GetAxisRaw("P2Vertical");
            body.velocity = new Vector2(horizontal, vertical) * runSpeed;
        }
    }
}
