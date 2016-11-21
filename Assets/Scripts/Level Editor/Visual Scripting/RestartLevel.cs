using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {
    public void restartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
