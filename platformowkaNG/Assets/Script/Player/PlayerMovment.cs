using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{
    float horizontalMove = 0f;
    public float runSpeed = 10f;
    public float jumpForce = 10f;
    private int extraJump;
    private bool jump= false;
    public int jumpAmount;
    private bool facingRight = true;


    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    public Animator animator;
    public Joystick joystick;

    public Button shootbtn;
    public Button  jumpBtn;

    public AudioSource bieg;
    public AudioSource skok;
    public AudioSource skok2;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {


        if (joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;


        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -runSpeed;


        }
        else
        {
            horizontalMove = 0f;
        }
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


      


     
        //Shoot
        shootbtn.onClick.AddListener(OnShooting);
        jumpBtn.onClick.AddListener(OnJumping);

       
        //sound
        if (Mathf.Abs(horizontalMove) > 0f && bieg.isPlaying == false && isGrounded == true)
        {
            bieg.Play();
        }
        else if(Mathf.Abs(horizontalMove) <= 0f)
        {
            bieg.Stop();
        }

        if (jump == true)
        {
            skok.Play();
            bieg.Stop();
        }
    }


    public void OnShooting()
    {

        animator.SetBool("IsShooting", true);
       
    }
    public void OnJumping()
    {
        if (isGrounded == true)
        {
            extraJump = jumpAmount;
        }
        if (extraJump > 0)
        {      
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
            animator.SetBool("IsJumping", true);
            jump = true;
        }
    }


    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        if(animator.GetBool("IsAttack")== true)
        {
            FindObjectOfType<AudioManager>().Play("sword");
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        jump = false;

        if (isGrounded == true)
        {
            animator.SetBool("IsJumping", false);
        }

        rb.velocity = new Vector2(horizontalMove * runSpeed, rb.velocity.y);
        animator.SetBool("IsShooting", false);


        if(facingRight == false && horizontalMove > 0)
        {
            Flip();
        }
        else if(facingRight == true && horizontalMove < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }



    public IEnumerator Knockback(float knockDuration, float knockPowerw, Vector3 knockDirection)
    {
        float timer = 0;

        while(knockDuration > timer)
        {
            timer += Time.deltaTime;

            rb.AddForce(new Vector3(knockDirection.x * -1, knockDirection.y * knockPowerw, transform.position.z));
        }

        yield return 0;
    }


    public void ZeroVelocity()
    {
        rb.velocity = Vector2.zero;
        horizontalMove = 0f;
    }

}
