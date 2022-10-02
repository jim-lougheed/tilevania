using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] Rigidbody2D lacocoRigidBody;
    [SerializeField] CapsuleCollider2D lacocoBodyCollider;
    [SerializeField] BoxCollider2D lacocoFeetCollider;
    [SerializeField] float runSpeed = 7f;
    [SerializeField] float climbSpeed = 5f;
    float initialGravityScale = 6f;
    float ladderGravityScale = 0f;
    [SerializeField] Animator lacocoAnimation;
    [SerializeField] float jumpSpeed = 20f;
    bool isJumping = false;
    void Start()
    {
        lacocoRigidBody.GetComponent<Rigidbody2D>();
        lacocoAnimation.GetComponent<Animator>();
        lacocoBodyCollider.GetComponent<CapsuleCollider2D>();
        lacocoFeetCollider.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
        if (lacocoRigidBody.velocity.y < 0) {
            isJumping = false;
        }
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value) {
        if (value.isPressed && lacocoBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")) && lacocoRigidBody.velocity.x > 0) {
            lacocoRigidBody.gravityScale = initialGravityScale;
            lacocoRigidBody.velocity += new Vector2(0f, jumpSpeed);
            isJumping = true;
        } else if (value.isPressed && lacocoBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && lacocoFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            Debug.Log("touching");
            lacocoRigidBody.velocity += new Vector2(0f, jumpSpeed);
            isJumping = true;
        }
    }

    void Run() {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, lacocoRigidBody.velocity.y);
        lacocoRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(lacocoRigidBody.velocity.x) > Mathf.Epsilon;
        lacocoAnimation.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(lacocoRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(lacocoRigidBody.velocity.x), 1f);
        }
    }

    void ClimbLadder() {
        if (lacocoFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")) && !isJumping) {
            Vector2 climbVelocity = new Vector2(lacocoRigidBody.velocity.x, moveInput.y * climbSpeed);
            lacocoRigidBody.velocity = climbVelocity;
            lacocoRigidBody.gravityScale = ladderGravityScale;
            bool playerHasVerticalSpeed = Mathf.Abs(lacocoRigidBody.velocity.y) > Mathf.Epsilon;
            lacocoAnimation.SetBool("isClimbing", playerHasVerticalSpeed);
        } else {
            lacocoRigidBody.gravityScale = initialGravityScale;
        }
    }
}
