using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float minDistance;
    public float cameraVelocity;
    public Vector3 offset; 
    public GameObject[] targets;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start() {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (targets != null && targets.Length > 0) {
            Vector3 posNoZ = transform.position;
            posNoZ.z = targets[0].transform.position.z * -1;
            Vector3 targetDirection;
            if(targets.Length > 1) {
                targetDirection = ((targets[0].transform.position + targets[1].transform.position) / 2 - posNoZ);
            }
            else {
                targetDirection = targets[0].transform.position - posNoZ;
            }
            cameraVelocity = targetDirection.magnitude * 5f;
            targetPos = transform.position + (targetDirection.normalized * cameraVelocity * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
    }
}
