using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : Physics
{

    public GameObject bullet;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public AudioSource sLose;
    public AudioSource j;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public int count = 3;
    
    public GameObject player;

    // Use this for initialization
    private void Start()
    {

        sLose = GetComponent<AudioSource>();

        SetLifeText();
    }
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();


    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))

        {

            GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.up * 1.5f, Quaternion.identity));

            b.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);

        }
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
            j.Play();
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("speed", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
       
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
           
                    sLose.Play();
                    count = count - 1;
                    SetLifeText();

                
            
        }
    }

    void SetLifeText()
    {
        if (count == 0)
        {
            sLose.Play();

          //  loseText.text = "You Lose";
            player.SetActive(false);


        }
       // LifeText.text = "count: " + count.ToString();


    }


}