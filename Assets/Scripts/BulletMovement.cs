using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletRigidBody;
    [SerializeField] float bulletSpeed = 20f;
    float xSpeed;
    PlayerMovement playerMovement;
    void Start()
    {
        bulletRigidBody.GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        xSpeed = playerMovement.transform.localScale.x * bulletSpeed;
        transform.localScale = new Vector2((Mathf.Sign(xSpeed)) * transform.localScale.x, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        bulletRigidBody.velocity = new Vector2(xSpeed, 0f);    
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            Destroy(other.gameObject);
        }
        if (other.tag == "Ground") {
            Debug.Log("Ground");
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
