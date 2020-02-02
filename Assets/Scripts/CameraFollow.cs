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

    public float maxSize = 10.0f;
    public float minSize = 4.0f;

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
                Debug.Log("DISTANCE FROM A TO B: " + Vector2.Distance(targets[0].transform.position, targets[1].transform.position));
                float targetSize = Mathf.Pow(Vector2.Distance(targets[0].transform.position, targets[1].transform.position), 0.7f);
                if(targetSize < minSize) {
                    targetSize = minSize;
                } else if(targetSize > maxSize) {
                    targetSize = maxSize;
                }
                GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, targetSize, 0.05f);
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
