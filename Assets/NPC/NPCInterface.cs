using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInterface : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer;

    public void ChangeColor(int phase)
    {
        switch(phase)
        {
            case(1):
                StartCoroutine(ChangeColorRoutine(Color.blue, Color.yellow));
                break;
            case(2):
                StartCoroutine(ChangeColorRoutine(Color.yellow, Color.red));
                break;
            case(3):
                StartCoroutine(ChangeColorRoutine(Color.red, Color.blue));
                break;
            default:
                break;
        }
    }

    IEnumerator ChangeColorRoutine(Color c1, Color c2){
        float ElapsedTime = 0.0f;
        float TotalTime = 0.5f;
        while (ElapsedTime < TotalTime) {
            ElapsedTime += Time.deltaTime;
            _spriteRenderer.color = Color.Lerp(c1, c2, (ElapsedTime / TotalTime));
            yield return null;
        }
    }
}
