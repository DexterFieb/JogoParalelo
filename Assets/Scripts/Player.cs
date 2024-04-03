using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour{
    Rigidbody2D rig;
    public int Vidas = 3;
    SpriteRenderer SR;
    public int speed = 5;
    bool chao, puloDuplo;
    public int jump = 4;
    public Animator animator;
    void Start(){
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();

    }
    void Update(){
        
        Mover(); 
        Pulo();
        Morte();

    }

    void Mover(){
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);
         if(Input.GetAxis("Horizontal") != 0){ //está correndo
            animator.SetBool("taCorrendo", true);
        }
        else{
            animator.SetBool("taCorrendo", false);
        }

        if(Input.GetAxis("Horizontal") > 0){
            SR.flipX = false;
        }
        if(Input.GetAxis("Horizontal") < 0 )
            SR.flipX = true;

        }
    

    void Pulo(){
        if(Input.GetButtonDown("Jump")){
            if(chao){
                rig.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                chao = false;
                puloDuplo = true;
            }else if(puloDuplo){
                rig.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                chao = false;
                puloDuplo = false;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D colisao){
        if(colisao.gameObject.CompareTag("Plataforma")){
            chao = true; puloDuplo = false;
        }
        if(colisao.gameObject.CompareTag("Morte")){
            Vidas = 0;
        }
    }
    void Morte(){
        if(Vidas == 0){
            Debug.Log("Morreu Otario");
            animator.SetBool("Morte", true);
            StartCoroutine("Trocar");

        }
    }
    IEnumerator Trocar()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Morte");
    }
}
