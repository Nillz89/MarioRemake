using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    public Transform raycast;
    public float allowedFallDistance = 1;
    public LayerMask growndLayer;

    // Use this for initialization
   protected override void Start ()
    {
        base.Start();
        horizontal = -1;
    }
	
	// Update is called once per frame
	protected virtual void Update ()
    {
       
        if (!dead)
        {
            Move();
        }
    }

    public override void Move()
    {

        RaycastHit2D hit = Physics2D.Raycast(raycast.position, Vector2.down, allowedFallDistance, growndLayer);
        if (!(hit && hit.collider != null))
        {
            horizontal = -horizontal;
        }
        base.Move();
    }

    public override void Death()
    {
        base.Death();
        GetComponent<BoxCollider2D>().enabled = false;
        dead = true;
        anim.SetBool("Dead", true);

    }

}
