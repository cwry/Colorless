using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Canvas optionMenu;
    public Canvas startMenu;
    public Canvas creditsMenu;

    public Button startText;
    public Button exitText;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = startText.GetComponent<Button>();
        quitMenu.enabled = false;
        optionMenu.enabled = false;
        creditsMenu.enabled = false;
    }


    public void ExitPress() {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }


    public void NoPress() {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }


    public void StartLevel() {
         Application.LoadLevel(1);
    }


    public void ExitGame() {
        Application.Quit();
    }

    public void OptionPress() {
        startMenu.enabled = false;
        optionMenu.enabled = true;
    }

    public void CreditsPress() {
        startMenu.enabled = false;
        creditsMenu.enabled = true;
    }

    public void BackPress() {
        startMenu.enabled = true;
        creditsMenu.enabled = false;
        optionMenu.enabled = false;
    }
}
