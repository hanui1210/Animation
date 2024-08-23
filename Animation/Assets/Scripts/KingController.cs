using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KingController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2D;
    public float moveSpeed = 1;
    private float time;
    private float attackSpeed = 0.3f;
    private bool istime;

    

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        

        if (h == 0f)
        {
            // ∏ÿ√Á¿÷¿Ω
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

        Check();
    }
    // ∏ÿ√Á = ¥ﬁ∑¡ / ∏ÿ√Áº≠ ∂ß∑¡
    // ¥ﬁ∑¡ = ∏ÿ√Á / ¥ﬁ∏Æ¥Ÿ ∏ÿ√Áº≠ ∂ß∑¡
    // ∂ß∑¡ = ∏ÿ√Á / ∏ÿ√ﬂ∞Ì ¥ﬁ∑¡

    public void KingAttack()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.rb2D.velocity = new Vector2(0, 0);
            animator.SetInteger("state", 2);
            Debug.Log("∞¯∞›¿Ã ≥°≥µΩ¿¥œ¥Ÿ");
            Debug.Log(this.rb2D.velocity);

        }
    }

   

}
