using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PauseMenuTwo : MonoBehaviour {

    public EventSystem eventS;

    public GameObject ResumeSelect;
    public GameObject RestartSelect;
    public GameObject BackSelect;
    public GameObject QuitSelect;

    public Image MenuSelectButton1;
    public Image MenuSelectButton2;
    public Image MenuSelectButton3;
    public Image MenuSelectButton4;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (eventS.currentSelectedGameObject == ResumeSelect)
            MenuSelectButton1.sprite = Resources.Load<Sprite>("MenuSelectButton_color");
        else MenuSelectButton1.sprite = Resources.Load<Sprite>("MenuSelectButton_Grey");

        if (eventS.currentSelectedGameObject == RestartSelect)
            MenuSelectButton2.sprite = Resources.Load<Sprite>("MenuSelectButton_color");
        else MenuSelectButton2.sprite = Resources.Load<Sprite>("MenuSelectButton_Grey");

        if (eventS.currentSelectedGameObject == BackSelect)
            MenuSelectButton3.sprite = Resources.Load<Sprite>("MenuSelectButton_color");
        else MenuSelectButton3.sprite = Resources.Load<Sprite>("MenuSelectButton_Grey");

        if (eventS.currentSelectedGameObject == QuitSelect)
            MenuSelectButton4.sprite = Resources.Load<Sprite>("MenuSelectButton_color");
        else MenuSelectButton4.sprite = Resources.Load<Sprite>("MenuSelectButton_Grey");
    }
}
