using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSfx;
    [SerializeField] int scoreInterval = 100;
    bool wasCollected = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !wasCollected) {
            wasCollected = true;
            AudioSource.PlayClipAtPoint(coinPickupSfx, Camera.main.transform.position);
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddToScore(scoreInterval);
            // gameObject.SetActive(false);
        }
    }
}
