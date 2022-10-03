using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
 [SerializeField] BoxCollider2D exitCollider;
 int waitTime = 1;

 void Start() {
    exitCollider.GetComponent<BoxCollider2D>();
 }

 void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Player") {
        StartCoroutine(StartNextLevel());
    }
 }

 IEnumerator StartNextLevel() {
    yield return new WaitForSecondsRealtime(waitTime);
    int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
        nextSceneIndex = 0;
    }
    FindObjectOfType<ScenePersist>().ResetScenePersist();
    SceneManager.LoadScene(nextSceneIndex);
 }
}
