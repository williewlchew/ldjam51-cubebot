using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector3 normalizedInputs; 
    private float verticalInputProcessed; 
    
    public void Update()
    {
        MoveWithInput();
    }

    private void MoveWithInput()
    {
        normalizedInputs = (transform.right * Input.GetAxis("Horizontal")) +
            (transform.forward * Input.GetAxis("Vertical"));
        normalizedInputs = Vector3.Normalize(normalizedInputs);
        GetComponent<Rigidbody>().velocity = normalizedInputs * speed;
    }
}
