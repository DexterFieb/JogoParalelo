using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatCai : MonoBehaviour
{
    Rigidbody2D rig;
    void Start(){
        rig = GetComponent<Rigidbody2D>();
    }
    IEnumerator cair(){
        yield return new WaitForSeconds(0.3f);
        rig.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D colisao){
        if(colisao.gameObject.tag==("Player")){
            StartCoroutine("cair");
        }
    }
    
}
