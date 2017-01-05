using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public Transform pauseMenuCanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
	}

    public void Pause() {

        if (pauseMenuCanvas.gameObject.activeInHierarchy == false) {
            pauseMenuCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Exit() {
        pauseMenuCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        Application.LoadLevel("MainMenu");
    }
}
