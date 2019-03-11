﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    //Animation
    public Animator anim;
    public bool dead = false;

    //Movement
    public float speed = 10;
    public float jumpForce = 10;
    protected float horizontal = 0;

    //Shoot
    public GameObject projectile;
    public float projectileForce = 50;
    public Transform spawnPoint;

    //GroundCheck
    protected bool isMoving;
    protected bool isGrounded;
    protected Rigidbody2D rb;

    //Death
    public bool Dead = false;

    //Enemy
    public int enemyLayer;

    //Audio
    public AudioSource src;
    public AudioClip jumpAudio;
    public AudioClip shootAudio;



    // Use this for initialization
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        src = GetComponent<AudioSource>();
            
    }



    public virtual void Move()
    {
       
        transform.position += speed * horizontal * Vector3.right * Time.deltaTime;
        if (horizontal > 0.5f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontal < -0.5f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (horizontal == 0f)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

    }




    public virtual void Jump()
    {
        
        isGrounded = false;
        rb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
        if(jumpAudio != null && src != null)
        {
            src.volume = 0.3f;
            src.PlayOneShot(jumpAudio);
        }
    }

    public float GetHorizontalSpeed()
    {
        return speed * horizontal;
    }

    public float GetVerticalSpeed()
    {
        return rb.velocity.y;
    }

    public virtual void Shoot()
    {
        GameObject spawnedProjectile = Instantiate(projectile, spawnPoint.position, Quaternion.identity);
        spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(projectileForce * transform.right, ForceMode2D.Impulse);
        if (shootAudio != null && src != null)
        {
            src. volume = 1;
            src.PlayOneShot(shootAudio);

        }
    }

    public virtual void OnGroundHit()
    {
       isGrounded = true;
    }

    public virtual void OnEnemyHit(GameObject enemy)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            OnGroundHit();
        }
        if (collision.gameObject.layer == enemyLayer)
        {
            OnEnemyHit(collision.gameObject);
        }
    }







    public virtual void Death()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);

    }

}
