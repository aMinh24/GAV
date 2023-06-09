﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]                    //buộc có component đó
[RequireComponent(typeof(BoxCollider2D))]


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpHeight;
    private float dirX;
    private float dirY;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private Animator animator;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private ParticleSystem moveEffect;
    [SerializeField] private ParticleSystem jumpEffect;
    private enum MovementState { Idle, Running, Jumping, Falling }
    private MovementState movementState;
    private bool isNotDoubleJump;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private int occurAfterVelocity;
    [Range(0, 10)]
    [SerializeField] private float dustFormationPeriod;
    private float counter;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        trailRenderer= GetComponent<TrailRenderer>();
    }
    private void Start()
    {
        trailRenderer.emitting= false;
    }
    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        counter+= Time.deltaTime;
        if(IsGround() && Math.Abs(rigidBody.velocity.x)>occurAfterVelocity)
        {
            if (counter > dustFormationPeriod)
            {
                moveEffect.Play();
                counter = 0;
            }    
        }    


        dirX = Input.GetAxisRaw("Horizontal");
        Jumping();
        UpdateAnimation();
        if (Input.GetKeyDown(KeyCode.LeftShift)&&canDash)
        {
            StartCoroutine(Dash());
            if (AudioManager.HasInstance)
            {
                Debug.Log("musicDash");
                AudioManager.Instance.PlaySE(AUDIO.SE_DASH);
            }
        }
    }
    private void FixedUpdate()
    {
        if (isDashing) return;
        Moving();
    }
    private void Moving()
    {
        if (rigidBody.bodyType != RigidbodyType2D.Static)
        rigidBody.velocity = new Vector2(dirX * playerSpeed, rigidBody.velocity.y);
    }
    private void Jumping()
    {
        if(IsGround() && !Input.GetButton("Jump"))
        {
            isNotDoubleJump = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGround() || isNotDoubleJump)
            {
                if (AudioManager.HasInstance)
                {
                    AudioManager.Instance.PlaySE(AUDIO.SE_JUMP);
                }
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
                isNotDoubleJump = !isNotDoubleJump;
                animator.SetBool("doubleJump", !isNotDoubleJump);
                if(!isNotDoubleJump)
                {
                    jumpEffect.Play();
                }    
            }
        }
    }
    private void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            spriteRenderer.flipX = false;
            movementState = MovementState.Running;
        }
        else if (dirX < 0f)
        {
            spriteRenderer.flipX = true;
            movementState = MovementState.Running;
        }
        else movementState = MovementState.Idle;

        if (rigidBody.velocity.y > 0.1f)
        {
            movementState = MovementState.Jumping;
        }
        else if (rigidBody.velocity.y < -0.1f)
        {
            movementState = MovementState.Falling;
        }

        animator.SetInteger("State", (int)movementState);
    }

    private bool IsGround()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
     
    private IEnumerator Dash()
    {
        Debug.Log("haahah");
        canDash = false;
        isDashing = true;
        float originalGravity = rigidBody.gravityScale;
        rigidBody.gravityScale = 0f;
        rigidBody.velocity = new Vector2(dirX * dashingPower, 0f);
        trailRenderer.emitting= true;
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rigidBody.gravityScale = originalGravity;
        isDashing= false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
