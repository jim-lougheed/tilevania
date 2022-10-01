using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] Rigidbody2D lacocoRigidBody;
    float runSpeed = 10f;
    [SerializeField] Animator lacocoAnimation;
    [SerializeField] float jumpSpeed = 25f;
    void Start()
    {
        lacocoRigidBody.GetComponent<Rigidbody2D>();
        lacocoAnimation.GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value) {
        if (value.isPressed) {
            lacocoRigidBody.velocity += new Vector2(0f, jumpSpeed);
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
}
