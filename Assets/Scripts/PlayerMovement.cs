using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] Rigidbody2D lacocoRigidBody;
    // [SerializeField] Transform lacocoTransform;
    float runSpeed = 10f;
    void Start()
    {
        lacocoRigidBody.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void Run() {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, lacocoRigidBody.velocity.y);
        lacocoRigidBody.velocity = playerVelocity;
    }

    void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(lacocoRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(lacocoRigidBody.velocity.x), 1f);
        }
    }
}
