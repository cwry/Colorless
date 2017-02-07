using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour {

    public GameObject quitMenu;
    public GameObject optionMenu;
    public GameObject startMenu;
    public GameObject creditsMenu;
    public GameObject controlsMenu;

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

    public GameObject OptionsSelect;
    public GameObject ControlsSelect;
    public GameObject CreditsSelect;
    public GameObject ExitSelect;

    public Image MenuSelectButton1;
    public Image MenuSelectButton2;
    public Image MenuSelectButton3;
    public Image MenuSelectButton4;
    public Image MenuSelectButton5;
    public Image MenuSelectButton6;
    public Image MenuSelectButton7;

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
        SceneManager.LoadScene(1);
    }

    public void Update() {
        if (eventS.currentSelectedGameObject != storedSelected) {
            if (eventS.currentSelectedGameObject == null) {
                eventS.SetSelectedGameObject(storedSelected);
            } else storedSelected = eventS.currentSelectedGameObject;
        }

        if (eventS.currentSelectedGameObject == sMB)
            MenuSelectButton1.sprite = Resources.Load<Sprite>("MenuSelectButton_color");
        else MenuSelectButton1.sprite = Resources.Load<Sprite>("MenuSelectButton_Grey");

        if (eventS.currentSelectedGameObject == OptionsSelect)
            MenuSelectButton2.sprite = Resources.Load<Sprite>("MenuSelectButton_color");
        else MenuSelectButton2.sprite = Resources.Load<Sprite>("MenuSelectButton_Grey");

        if (eventS.currentSelectedGameObject == CreditsSelect)
            MenuSelectButton3.sprite = Resources.Load<Sprite>("MenuSelectButton_color");
        else MenuSelectButton3.sprite = Resources.Load<Sprite>("MenuSelectButton_Grey");

        if (eventS.currentSelectedGameObject == ControlsSelect)
            MenuSelectButton4.sprite = Resources.Load<Sprite>("MenuSelectButton_color");
        else MenuSelectButton4.sprite = Resources.Load<Sprite>("MenuSelectButton_Grey");

        if (eventS.currentSelectedGameObject == ExitSelect)
            MenuSelectButton5.sprite = Resources.Load<Sprite>("MenuSelectButton_color");
        else MenuSelectButton5.sprite = Resources.Load<Sprite>("MenuSelectButton_Grey");

        if (eventS.currentSelectedGameObject == creditsBackText)
            MenuSelectButton6.sprite = Resources.Load<Sprite>("MenuSelectButton_color");
        else MenuSelectButton7.sprite = Resources.Load<Sprite>("MenuSelectButton_Grey");

        if (eventS.currentSelectedGameObject == controlsBackText)
            MenuSelectButton7.sprite = Resources.Load<Sprite>("MenuSelectButton_color");
        else MenuSelectButton7.sprite = Resources.Load<Sprite>("MenuSelectButton_Grey");
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

    public void ControlsPress() {
        startMenu.SetActive(false);
        controlsMenu.SetActive(true);
        eventS.SetSelectedGameObject(controlsBackText);
    }

    public void BackPress() {
        startMenu.SetActive(true);
        creditsMenu.SetActive(false);
        optionMenu.SetActive(false);
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        eventS.SetSelectedGameObject(sMB);
    }


}
