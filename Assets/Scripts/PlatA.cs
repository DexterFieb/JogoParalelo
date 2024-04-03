using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatA : MonoBehaviour{
    public Transform posA,posB;
    public int speed;
    Vector2 targetPos;
    void Start(){
        transform.position = posB.position;
        targetPos = posA.position;
    }
    void Update(){
        if(Vector2.Distance(transform.position,posA.position)<0.1f){
        targetPos = posB.position;
        }
        if(Vector2.Distance(transform.position,posB.position)<0.1f){
        targetPos = posA.position;        
        }
        transform.position = Vector2.MoveTowards(transform.position,targetPos,speed *Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D colisao){
        if(colisao.gameObject.CompareTag("Player")){
            colisao.transform.SetParent(this.transform);
        }
    }
    void OnCollisionExit2D(Collision2D colisao){
        if(colisao.gameObject.CompareTag("Player")){
            colisao.transform.SetParent(null);
        }
    }

}


