using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInterface : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer;

    private BoxCollider selfCollider;

    Color lerpedColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        selfCollider = GetComponent<BoxCollider>();
    }
    
    /* Collider */

    public void Obstruct()
    {
        selfCollider.enabled = true;
    }

    public void UnObstruct()
    {
        selfCollider.enabled = false;
    }

    /* Sprite */

    public void ChangeSpriteColor()
    {
        lerpedColor = Color.Lerp(Color.white, Color.black, Time.time * 1.5f);
        _spriteRenderer.color = lerpedColor;
    }
}
