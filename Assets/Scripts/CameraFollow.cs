using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float minDistance;
    public float cameraVelocity;
    public Vector3 offset; 
    public GameObject target;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start() {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (target) {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;
            Vector3 targetDirection = (target.transform.position - posNoZ);
            cameraVelocity = targetDirection.magnitude * 5f;
            targetPos = transform.position + (targetDirection.normalized * cameraVelocity * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
    }
}
