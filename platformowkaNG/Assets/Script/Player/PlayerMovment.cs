using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;
    float verticalMove;
    public float runSpeed = 10f;
    bool jump = false;
    bool crouch = false;
    public Animator animator;
    public Joystick joystick;
    public Button shootbtn;
    private void Start()
    {
  
    }
    // Update is called once per frame
    void Update()
    {
      

        if(joystick.Horizontal >= .2f)
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


        verticalMove = joystick.Vertical;
        //Crouch
        if (verticalMove <= -.5f)
        {
            crouch = true;
            animator.SetBool("IsCrouching", true);
        }
        else
        {
            crouch = false;
        }


        //jump
         if(verticalMove >= .5f)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        


        //Shoot
        shootbtn.onClick.AddListener(OnShooting);



    }

    public void OnShooting()
    {
        animator.SetBool("IsShooting", true);
       
    }


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        animator.SetBool("IsShooting", false);
    }


}
