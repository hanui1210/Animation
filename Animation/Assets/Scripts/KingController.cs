using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KingController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2D;
    public float move;
    public float time;
    public float attacktime = 5f;
    public State state;

    public enum State
    {
        Move,Stop
    }

    // Update is called once per frame
    public void Update()
    {
    float h = Input.GetAxisRaw("Horizontal");
        // π´¡∂∞« -1, 0, 1
        // 0¿Ã æ∆¥œ∏È ¿Ãµø«œ∞Ì¿÷¿Ω
        //switch (h)
        //{
        //    case 0:
        //        animator.SetInteger("state", 0);


        //    case 1:
        //        this.transform.localScale = new Vector3(h, 1, 1);
        //        animator.SetInteger("state", 1);
        //        Vector2 velocity = new Vector2(h * 1, 0);
        //        Debug.Log(velocity);
        //        KingAttack();
        //        break;
        //}
        

        if (h == 0f)
        {
            // ∏ÿ√Á¿÷¿Ω
            Vector2 direction = new Vector2(-0.1f, 0);
            this.transform.Translate(h * direction, 0);
            animator.SetInteger("state", 0);
            KingAttack();
        }
        else

        {
            Vector2 direction = new Vector2(0.1f, 0);
            this.transform.Translate(h * direction, 0);
            this.transform.localScale = new Vector3(h, 1, 1);
            animator.SetInteger("state", 1);
            Vector2 velocity = new Vector2(h * 1, 0);
            Debug.Log(velocity);
            KingAttack();

        }
       

        // ∏ÿ√Á = ¥ﬁ∑¡ / ∏ÿ√Áº≠ ∂ß∑¡
        // ¥ﬁ∑¡ = ∏ÿ√Á / ¥ﬁ∏Æ¥Ÿ ∏ÿ√Áº≠ ∂ß∑¡
        // ∂ß∑¡ = ∏ÿ√Á / ∏ÿ√ﬂ∞Ì ¥ﬁ∑¡



    }
    public void KingAttack()
    {
        
         bool isAttack = Input.GetKeyDown(KeyCode.Return);
        
                
        if (isAttack) 
        {
            
            animator.SetInteger("state", 2);
            Debug.Log("∞¯∞›¿Ã ≥°≥µΩ¿¥œ¥Ÿ");
            Action();

            
        }

    }
    public void Action()
    {
        if (state == State.Move)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
            float xPos = Mathf.Clamp(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
            //this.transform.position = new Vector3(xPos, this.transform.position.y, this.transform.position.z);
            state = State.Stop;
        }
    }
    
}
