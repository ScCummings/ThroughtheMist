using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendRaycast : MonoBehaviour
{

    bool keepGoing;
    bool playerLooking;
    LineRenderer lr;
    GameObject playerRef;
    // Start is called before the first frame update
    void Start() {
        keepGoing = true;
        lr = GetComponent<LineRenderer>();
    }

    private void Update() {
        if(playerLooking) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, playerRef.transform.position - transform.position);
            if (hit.collider.gameObject.tag != "OlderBrother") {
                keepGoing = false;
                playerRef.GetComponent<OlderBrotherMovement>().setCanMove(true);
                lr.enabled = false;
                Destroy(this.gameObject);
            } else {
                playerRef.GetComponent<OlderBrotherMovement>().setCanMove(false);
                Vector3[] positions = new Vector3[2];
                positions[0] = transform.position;
                positions[1] = playerRef.transform.position;
                lr.SetPositions(positions);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (keepGoing && col.gameObject.tag == "OlderBrother") {
            playerLooking = true;
            playerRef = col.gameObject;
        }
    }
}
