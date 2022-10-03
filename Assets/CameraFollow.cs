using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 newPosition;

    void Start()
    {
        newPosition = new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        newPosition.x = target.position.x;
        newPosition.z = target.position.z;
        transform.position = newPosition;
    }
}
