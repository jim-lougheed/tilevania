using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] Rigidbody2D lacocoRigidBody;
    float runSpeed = 10f;
    void Start()
    {
        lacocoRigidBody.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void Run() {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, lacocoRigidBody.velocity.y);
        lacocoRigidBody.velocity = playerVelocity;
    }
}
