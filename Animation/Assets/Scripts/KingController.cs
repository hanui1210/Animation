using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class KingController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2D;
    public float moveSpeed;
    private bool isMoveStop;
    private bool isAttacktime;
    private float curAttackTime = 0f; // ∞£∞› ≈∏¿Ã∏”
    private float attackTime = 0.6f; // ∞£∞› Ω√∞£
    private bool isAttack;

    public GameObject kingGo;
    public GameObject pigGo;
    public KingController kingController;
    public PigContorller pigContorller;

    public int kingDamage;
    public int pigHp;
    private int pigMaxHp;
    private Transform pigTrans;

    private Vector3 kingPos;

    private void Start()
    {
        kingController = kingGo.GetComponent<KingController>();
        pigContorller = pigGo.GetComponent<PigContorller>();
        animator = kingController.GetComponent<Animator>();
        this.pigTrans = GameObject.Find("Pig").transform;
        Debug.Log($"≈∑ ∞¯∞›∑¬: {kingDamage}");  
    }

    // Update is called once per frame
    public void Update()
    {
        KingMove();            
       
    }
    // ∏ÿ√Á = ¥ﬁ∑¡ / ∏ÿ√Áº≠ ∂ß∑¡
    // ¥ﬁ∑¡ = ∏ÿ√Á / ¥ﬁ∏Æ¥Ÿ ∏ÿ√Áº≠ ∂ß∑¡
    // ∂ß∑¡ = ∏ÿ√Á / ∏ÿ√ﬂ∞Ì ¥ﬁ∑¡
    public void KingMove()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h == 0f)
        {
            // ∏ÿ√Á¿÷¿Ω
            animator.SetInteger("state", 0);
            KingAttack();
        }

        else if (h != 0)
        {
            animator.SetInteger("state", 1);
            this.rb2D.velocity = new Vector2(h * moveSpeed, 0);
            this.transform.localScale = new Vector3(h, 1, 1);
            KingAttack();
        }
    }

    public void KingAttack()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.curAttackTime += Time.deltaTime;
            this.isAttacktime = true;
         }
        if (curAttackTime > 0 && curAttackTime < 0.6f && Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetInteger("state", 2);
            curAttackTime = attackTime;
            this.isAttacktime = false;
            this.rb2D.velocity = Vector2.zero;
            CheckAndAttack();
            Debug.Log("King Attack");
        }
        else if(curAttackTime >=0.6f && Input.GetKeyDown(KeyCode.Return))
        {
            this.curAttackTime += Time.deltaTime;
            this.rb2D.velocity = Vector2.zero;
            animator.SetInteger("state", 2);
            CheckAndAttack();
            Debug.Log("King Attack");
        }
    }

    public void KingDamage(int pigHp, int pigMaxHp, int kingDamage)
    {

        pigContorller.PigDead();
        this.pigHp = this.pigContorller.pigMaxHp;
        this.pigMaxHp = this.pigContorller.pigMaxHp;
        this.pigContorller.pigHp -= this.kingDamage;
        Debug.Log($"Pig¿« √º∑¬: {this.pigContorller.pigHp}/{this.pigContorller.pigMaxHp}");
    }
  
    public void CheckAndAttack()
    {
        this.kingPos = this.transform.position;
        Debug.Log($"kingPos: {kingPos}");
        float dirX = pigTrans.transform.position.x - this.kingGo.transform.position.x;
        
        if(dirX > 1.30f && dirX > -7.80f)
        {
            Debug.Log($"dirX: {dirX}");
            Debug.Log("∆»¿Ã¬™æ∆");
        }
        else
        {
            KingDamage(pigHp,pigMaxHp,kingDamage);
        }
    }


}
