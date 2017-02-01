using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour {

    public GameObject quitMenu;
    public GameObject optionMenu;
    public GameObject startMenu;
    public GameObject creditsMenu;

    public Button startText;
    public Button exitText;
    public GameObject colorAnimation;

    public EventSystem eventS;
    private GameObject storedSelected;

    public GameObject creditsBackText;
    public GameObject controlsBackText;
    public GameObject quitNoText;
    public GameObject optionsBackText;
    public GameObject sMB;

    // Use this for initialization
    void Start () {
        storedSelected = eventS.firstSelectedGameObject;
        startText = startText.GetComponent<Button>();
        exitText = startText.GetComponent<Button>();
        quitMenu.SetActive(false);
        optionMenu.SetActive(false);
        creditsMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    IEnumerator LevelFade() {
        float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFade>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(1);
    }

    public void Update() {
        if (eventS.currentSelectedGameObject != storedSelected) {
            if (eventS.currentSelectedGameObject == null) {
                eventS.SetSelectedGameObject(storedSelected);
            } else storedSelected = eventS.currentSelectedGameObject;
        }
    }

    public void ExitPress() {
        quitMenu.SetActive(true);
        startText.enabled = false;
        exitText.enabled = false;
        startMenu.SetActive(false);
        eventS.SetSelectedGameObject(quitNoText);
    }


    public void NoPress() {
        quitMenu.SetActive(false);
        startText.enabled = true;
        exitText.enabled = true;
        startMenu.SetActive(true);
        eventS.SetSelectedGameObject(sMB);
    }


    public void StartLevel() {
        colorAnimation.GetComponent<ColorAnimationHandler>().animate(1, false, () => { StartCoroutine(LevelFade()); }, () => { });
    }


    public void ExitGame() {
        Application.Quit();
    }

    public void OptionPress() {
        startMenu.SetActive(false);
        optionMenu.SetActive(true);
        eventS.SetSelectedGameObject(optionsBackText);
    }

    public void CreditsPress() {
        startMenu.SetActive(false);
        creditsMenu.SetActive(true);
        eventS.SetSelectedGameObject(creditsBackText);
    }

    public void BackPress() {
        startMenu.SetActive(true);
        creditsMenu.SetActive(false);
        optionMenu.SetActive(false);
        creditsMenu.SetActive(false);
        eventS.SetSelectedGameObject(sMB);
    }


}
