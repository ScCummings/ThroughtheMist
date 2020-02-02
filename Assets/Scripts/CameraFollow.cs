using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float minDistance;
    public float cameraVelocity;
    public GameObject target;
    Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            Vector2 pos = transform.position;
            Vector2 targetDirection = (target.transform.position - transform.position);
            cameraVelocity = targetDirection.magnitude * 5f;
            //targetPos = transform.position + (targetDirection.normalized * cameraVelocity * Time.deltaTime);
            transform.position = Vector2.Lerp(transform.position, targetPos, 0.25f);
    }
}
