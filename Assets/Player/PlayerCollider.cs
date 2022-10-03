using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameManagerMain gameManagerMain;
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Hazard"){
            Destroy(this.gameObject);
            gameManagerMain.GameOver();
        }
        if(other.gameObject.tag == "Victory"){
            Destroy(this.gameObject);
            gameManagerMain.GameVictory();
        }
    }
}
