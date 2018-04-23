using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour {
    private Rigidbody2D rigidbody;
    private bool isAlive;

    private Transform Target
    {
        set;
        get;
    }

    private Spell Spell;
    
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (Target)
        {
            Vector2 direction = Target.transform.position - transform.position;
            rigidbody.velocity = direction.normalized * Spell.Speed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "HitBox" && collision.transform == Target)
        {
            collision.GetComponentInParent<Enemy>().TakeDamage(Spell.Damage);
            GetComponent<Animator>().SetTrigger("Impact");
            rigidbody.velocity = Vector2.zero;
            Target = null;
        }
    }

    public void Fire(Transform transform,Spell spell)
    {
        this.Spell = spell;
        Target = transform;
    }
}
