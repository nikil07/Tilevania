using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(loadNextScene());
    }

    IEnumerator loadNextScene() {

        FindObjectOfType<Player>().disableControls();
        yield return new WaitForSeconds(2);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }
}
