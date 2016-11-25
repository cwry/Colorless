using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {
    public void restartLevel(Vector2 spawnPos) {
        Globals.respawnPosition = spawnPos;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
