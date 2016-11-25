using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void loadScene(int buildIndex) {
        SceneManager.LoadScene(buildIndex);
    }
}
