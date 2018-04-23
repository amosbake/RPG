using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    
    [SerializeField]
    private Transform[] exitPoints;
    
    [SerializeField] private Status manaStatus;
    [SerializeField] private StatusView manaStatusView;

    private int exitIndex = 2;

    public Transform Target
    {
        get;
        set;
    }

    [SerializeField]
    private Block[] blocks;

    private SpellBook spellBook;

    protected override void Start()
    {
        spellBook = GetComponent<SpellBook>();
        manaStatusView._status = manaStatus;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update () {
        GetInput();
        base.Update();
	}


    void ChangePlayerHealth(float change)
    {
       TakeDamage(change);
    }

    void ChangePlayerMana(float change)
    {
       
    }
    
    void GetInput()
    {
        MoveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.I))
        {
            ChangePlayerHealth(-10);
        }
        if (Input.GetKey(KeyCode.O))
        {
            ChangePlayerHealth(10);
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveDirection += Vector2.up;
            exitIndex = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveDirection += Vector2.left;
            exitIndex = 3;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveDirection += Vector2.down;
            exitIndex = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveDirection += Vector2.right;
            exitIndex = 1;
        }
        Block();
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
          
        }
        MoveDirection.Normalize();
    }

    public IEnumerator Attack(int spellIndex)
    {
        if(!isAttacking && !IsMoving && InLineOfSight())
        {
            Transform currentTarget = Target;
            Spell newSpell = spellBook.CastSpell(spellIndex);
            isAttacking = true;
            animator.SetBool("attack", isAttacking);
            yield return new WaitForSeconds(newSpell.CastTime);
            //CastSpell();
            if (currentTarget && InLineOfSight())
            {
                GameObject spellObj = Instantiate(newSpell.SpellPrefab, exitPoints[exitIndex].position, Quaternion.identity);
                SpellScript spellController = spellObj.GetComponent<SpellScript>();
                spellController.Fire(Target,newSpell);
            }
            StopAttack();
        }
       
    }


    public void CastSpell(int spellIndex)
    {
        if (Target != null)
        {
            attackCorotine = StartCoroutine(Attack(spellIndex));
        }
    }

    public override void StopAttack()
    {
        base.StopAttack();
        spellBook.StopCasting();
    }

    private bool InLineOfSight()
    {
        if (Target)
        {
            Vector3 targetDirec = (Target.position - transform.position).normalized;
            Debug.DrawRay(transform.position, targetDirec,Color.red);
            //探测射线是否接触到block,如果有接触 就判定为不在视线范围以内
            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirec,Vector2.Distance(transform.position,Target.position),256);
            if(hit.collider == null)
            {
                return true;
            }
        }
        return false;
    }

    private void Block()
    {
        for(int i = 0; i< blocks.Length; i++)
        {
            blocks[i].Deactive();
        }
        blocks[exitIndex].Active();
    }


}
