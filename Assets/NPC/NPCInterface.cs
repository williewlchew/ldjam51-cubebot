using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInterface : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer;

    public void ChangeColor(int phase)
    {
        StartCoroutine(ChangeColorRoutine());
    }

    IEnumerator ChangeColorRoutine(){
        Debug.Log("Starting color!");
        float ElapsedTime = 0.0f;
        float TotalTime = 1.0f;
        while (ElapsedTime < TotalTime) {
            ElapsedTime += Time.deltaTime;
            _spriteRenderer.color = Color.Lerp(Color.green, Color.red, (ElapsedTime / TotalTime));
            yield return null;
        }
        Debug.Log("Ending color!");
    }
}
