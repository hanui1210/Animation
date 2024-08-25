using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigContorller : MonoBehaviour
{
    public Animator animator;
    public Collider2D Collider2D;
  
    public int pigHp;
    public int pigMaxHp;
    public GameObject kingGo;
    public KingController kingController;
    public PigContorller pigContorller;
    public bool isPigDead;
   

    void Start()
    {
        kingController = kingGo.GetComponent<KingController>();
        animator = pigContorller.GetComponent<Animator>();
        this.pigHp = 100;
        this.pigMaxHp = 100;
        Debug.Log($"PigÀÇ Ã¼·Â : {this.pigHp}/{this.pigMaxHp}");      
    }

    void Update()
    {      
        PigDead();
    }

    public void PigDead()
    {
        if( isPigDead ) return;
        float pigH = Input.GetAxisRaw("Horizontal");
        if(this.kingController.pigHp > 0)
        {
            animator.SetInteger("pigstate", 0);
        }
        else if(this.kingController.pigHp >= 0)
        {
            animator.SetInteger("pigstate", 1);
        }
        else if (this.kingController.pigHp < 0)
        {
            animator.SetInteger("pigstate", 2);
            isPigDead = true;
            Debug.Log("Pig Dead");
        }
    }
    
}
