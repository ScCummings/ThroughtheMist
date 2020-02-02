using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendRaycast : MonoBehaviour
{

    bool keepGoing;
    Collider2D raycastCollider; 
    // Start is called before the first frame update
    void Start()
    {
        keepGoing = true;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("OnCollisionStay");
        if (keepGoing && collision.gameObject.tag == "OlderBrother")
        {
            Debug.Log("Makes it into if statement");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, collision.gameObject.transform.position - transform.position);
            Debug.Log("RayastSent");
            if (hit.collider.gameObject.tag != "OlderBrother")
            {
                keepGoing = false;
                collision.gameObject.GetComponent<OlderBrotherMovement>().setCanMove(true);
            } else {

                //TODO: Paralye the older brother here OR unparalye him above
                collision.gameObject.GetComponent<OlderBrotherMovement>().setCanMove(false);

            }
        }
    }
}
