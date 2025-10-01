using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement movement;
    private Rigidbody rb;
    public AudioSource source; 

    public void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }


    public void Update()
    {
        animator.SetFloat("CharacterSpeed", rb.linearVelocity.magnitude);
        animator.SetBool("IsGrounded", movement.IsGrounded);
       
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetTrigger("doRoll");
        }
        
        if (Input.GetButtonUp("Fire2"))
        {
            animator.SetTrigger("doPunch");
            
        }

    }
    
    void PlayPunchSound()
    {
        source.Play();
    }
}


