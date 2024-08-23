using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KingController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2D;
    public float moveSpeed = 1;
    private float waitTime = 0.3f;
    private float attackSpeed = 0.0f;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        waitTime += Time.deltaTime;
        
        if (attackSpeed < waitTime)
        {

            if (h == 0f)
            {
                // ¸ØÃçÀÖÀ½
                animator.SetInteger("state", 0);
                KingAttack();
             
            }

            else

            {
                this.rb2D.velocity = new Vector2(h * moveSpeed, 0);
                this.transform.localScale = new Vector3(h, 1, 1);
                animator.SetInteger("state", 1);
                KingAttack();
                Debug.Log(this.rb2D.velocity);
            }
            

        }
    }
        // ¸ØÃç = ´Þ·Á / ¸ØÃç¼­ ¶§·Á
        // ´Þ·Á = ¸ØÃç / ´Þ¸®´Ù ¸ØÃç¼­ ¶§·Á
        // ¶§·Á = ¸ØÃç / ¸ØÃß°í ´Þ·Á

    public void KingAttack()
    {
        bool isAttack = Input.GetKeyDown(KeyCode.Return);
        
        if (isAttack)
        {
            this.rb2D.velocity = new Vector2(0, 0);
            animator.SetInteger("state", 2);
            Debug.Log("°ø°ÝÀÌ ³¡³µ½À´Ï´Ù");
            Debug.Log(this.rb2D.velocity);
            attackSpeed = 0.3f;
            

        }
        


    }
   
    
}
