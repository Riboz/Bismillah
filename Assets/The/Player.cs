using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer playerSprite;
    [SerializeField]private int jumpForce, rateCount;
    [SerializeField]private ParticleSystem hararet, boombastic;
    [SerializeField]private float runSpeed;
    [SerializeField]private bool canJump, runEffect;
    IEnumerator Changer()
    {
     var hararets = hararet.GetComponent<ParticleSystem>().emission;
     
     yield return new WaitForSeconds(3f); 

     hararet.Play();

     for(int i = 0; i < 10; i++)
     {
        rateCount += 2;

       

       hararets.rateOverTime = rateCount;

      yield return new WaitForSeconds(1f);

     }
     float runSpeedn = runSpeed;


     boombastic.Play();
     
     rateCount = 1;

     hararets.rateOverTime = 1;
     
     playerSprite.color = Color.blue;

     playerSprite.transform.DOScale(0,0.1f);
     
      yield return new WaitForSeconds(0.1f);
     
     playerSprite.transform.DOScale(1,0.1f);
     
     Dampinger.shake.ShakeCamera(4,0.2f);
     // stat değişir durum değişir resim değişir vesaire vesaire
    

     StartCoroutine(Changer());
    }
    
    void Start()
    {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

        playerSprite = GetComponent<SpriteRenderer>();
        StartCoroutine(Changer());

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            JumpMethod();
        }
    }
    void FixedUpdate()
    {
        Movement();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        float run = horizontal * Mathf.Lerp(0, runSpeed, 7f);

        Debug.Log(run);

        Vector2 RunVector = new Vector2(run,rb.velocity.y);

        rb.velocity = RunVector;

        if(horizontal > 0)
        {
            playerSprite.flipX = false;

             
        }
        else if(horizontal < 0)
        {
            playerSprite.flipX = true;

           
            
        }
        
        
           
        
        

    }
    void JumpMethod()
    {
        canJump = false;

        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        // sonradan velocity.zeroya yavaşlatılır

    }
}
