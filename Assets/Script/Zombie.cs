using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smartfoe : Physics
{
    private Vector2 vel;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    private void Start()
    {
        targetVelocity = Vector2.right;
        vel = Vector2.right;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    

   
    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Edge"))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            targetVelocity.x *= -1;

        }

        if (other.gameObject.CompareTag("Saw"))
        {
            other.gameObject.SetActive(false);

        }
    }


}