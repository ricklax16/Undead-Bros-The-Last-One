using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : Physics
{
    public Text LifeText;
    public GameObject bullet;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public AudioSource sLose;
   // public AudioSource j;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public int count = 3;
    
    public GameObject player;

    // Use this for initialization
    private void Start()
    {

       //sLose = GetComponent<AudioSource>();

        SetLifeText();
    }
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();


    }

    

    protected override void ComputeVelocity()
    {

        if (Input.GetMouseButtonDown(0))

        { //...setting shoot direction

            
            Vector3 shootDirection;
            shootDirection = Input.mousePosition;
            print(shootDirection.x + " " + shootDirection.y);
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            //shootDirection = shootDirection - transform.position;
            print(shootDirection.x + " " + shootDirection.y);
            shootDirection.x = (shootDirection.x - transform.position.x);
            shootDirection.y =  shootDirection.y-transform.position.y;
            print(shootDirection.x + " " + shootDirection.y);
            //...instantiating the rocket

            Vector3 temp = new Vector3();
            temp.y = transform.position.y;
            temp.z = 0.0f;
            if (transform.position.x > shootDirection.x)
            {
                temp.x = transform.position.x - .5f;
                 }
            else
            {
                temp.x = transform.position.x + .5f;
            }
            GameObject b = (GameObject)(Instantiate(bullet, temp, Quaternion.Euler(new Vector3(0, 0, 0))));
            
            b.GetComponent<Rigidbody2D>().AddForce(new Vector2(shootDirection.x * 1.5f, shootDirection.y * 1.5f));
        }

    
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
           // j.Play();
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

       
       
        
        animator.SetFloat("speed", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
       
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
           
                    //sLose.Play();
                    count = count - 1;
                    SetLifeText();

                
            
        }
        if (other.gameObject.CompareTag("Saw"))
        {
            //sLose.Play();
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
       LifeText.text = "count: " + count.ToString();


    }


}