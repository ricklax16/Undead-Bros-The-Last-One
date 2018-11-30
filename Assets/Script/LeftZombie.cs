using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftZombie : Physics {
    public int way=0;//0 is for right 1 is for left;
    public int life=2;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    public int count = 0;
    // Use this for initialization
    private void Start()
    {
        if (way == 0)
        {
            targetVelocity = Vector2.right;
        }
       else if (way == 1)
        {
            targetVelocity = Vector2.left;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }



    void OnTriggerEnter2D(Collider2D other)
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
            this.gameObject.SetActive(false);

        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            count++;
            other.gameObject.SetActive(false);
            if (count == life)
            {
                this.gameObject.SetActive(false);

                door.points += 1;
            }


        }
    }
}
