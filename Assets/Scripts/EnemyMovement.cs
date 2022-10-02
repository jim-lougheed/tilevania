using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Rigidbody2D enemyRigidBody;
    [SerializeField] BoxCollider2D enemyFrontCollider;
    void Start()
    {
        enemyRigidBody.GetComponent<Rigidbody2D>();
        enemyFrontCollider.GetComponent<BoxCollider2D>();
    }

    void OnTriggerExit2D(Collider2D other) {
        moveSpeed = -moveSpeed;
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidBody.velocity.x)), 1f);
    }

    void Update()
    {
        enemyRigidBody.velocity = new Vector2(moveSpeed, 0f);
    }
}
