using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public Transform pauseMenuCanvas;

    public EventSystem eventS;
    private GameObject storedSelected;

    public GameObject sMB;

    // Use this for initialization
    void Start () {
        storedSelected = eventS.firstSelectedGameObject;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7") ){
            Pause();
        }
        if (eventS.currentSelectedGameObject != storedSelected) {
            if (eventS.currentSelectedGameObject == null) {
                eventS.SetSelectedGameObject(storedSelected);
            } else storedSelected = eventS.currentSelectedGameObject;
        }

    }

    public void Pause() {

        if (pauseMenuCanvas.gameObject.activeInHierarchy == false) {
            pauseMenuCanvas.gameObject.SetActive(true);
            Globals.suppressPlayInput = false;
            Time.timeScale = 0;
            eventS.SetSelectedGameObject(sMB);
        }
        else
        {
            pauseMenuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            Globals.suppressPlayInput = true;
        }
    }

    public void Restart() {
        pauseMenuCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void ExitToMainMenu() {
        pauseMenuCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitGame() {
        pauseMenuCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        Application.Quit();
    }
}
