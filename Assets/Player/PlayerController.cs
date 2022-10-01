using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    
    private Vector3 normalizedInputs; 
    private Rigidbody selfRigedbody;

    public void Start()
    {
        selfRigedbody = GetComponent<Rigidbody>();
    }

    
    public void Update()
    {
        ProcessInputs();
    }

    public void FixedUpdate()
    {
        MoveWithInput();
        AnimateWithInput();
    }

    /* PHYSICS */

    private void ProcessInputs()
    {
        normalizedInputs = (transform.right * Input.GetAxis("Horizontal")) +
            (transform.forward * Input.GetAxis("Vertical"));
        normalizedInputs = Vector3.Normalize(normalizedInputs);
    }

    /* PHYSICS */

    private void MoveWithInput()
    {
        selfRigedbody.velocity = normalizedInputs * speed;
    }

    /* ANIMATIONS */

    private void AnimateWithInput()
    {
        Debug.Log(animator.GetInteger("WalkDirection"));
        if (normalizedInputs.z > 0.5){
            animator.SetInteger("WalkDirection", 1);
        }
        if (normalizedInputs.z < -0.5){
            animator.SetInteger("WalkDirection", 2);
        }
        if (normalizedInputs.x > 0.5){
            animator.SetInteger("WalkDirection", 3);
        }
        if (normalizedInputs.x < -0.5){
            animator.SetInteger("WalkDirection", 4);
        }
        if (normalizedInputs.x > -0.5 && normalizedInputs.x < 0.5 && normalizedInputs.z < 0.5 && normalizedInputs.z > -0.5 ){
            animator.SetInteger("WalkDirection", 0);
        }
    }
}
