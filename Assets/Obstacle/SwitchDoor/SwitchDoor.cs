using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    public GameObject doorObject;
    public SpriteRenderer _spriteRenderer;
    private bool switchActive = false;

    void OnTriggerEnter(Collider other)
    {
        switchActive = !(switchActive);
        doorObject.SetActive(!switchActive);
        _spriteRenderer.flipX = switchActive;
    }

}
