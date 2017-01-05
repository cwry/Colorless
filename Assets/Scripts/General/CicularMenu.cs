using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CicularMenu : MonoBehaviour {

    public List<MenuButton> buttons = new List<MenuButton>();
    private Vector2 Mouseposition;
    private Vector2 fromVector2M = new Vector2(0.5f, 1.0f);
    private Vector2 centercircle = new Vector2(0.5f, 0.5f);
    private Vector2 toVecor2M;

    public int menuItmes;
    public int CurMenuItem;
    private int OldMenuItem;


    // Use this for initialization
    void Start () {

        menuItmes = buttons.Count;
        foreach(MenuButton button in buttons) {

            button.sceneimage.color = button.NormalColor;
        }
        CurMenuItem = 0;
        OldMenuItem = 0;

    }
	
	// Update is called once per frame
	void Update () {

        GetCurrendMenuItem();
        if (Input.GetButtonDown("Fire1"))
            ButtonAction();

    }

    public void GetCurrendMenuItem() {

        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");

        Mouseposition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        toVecor2M = new Vector2(Mouseposition.x / Screen.width, Mouseposition.y / Screen.height);

        float angle = (Mathf.Atan2(fromVector2M.y - centercircle.y, fromVector2M.x - centercircle.x) - Mathf.Atan2(toVecor2M.y - centercircle.y, toVecor2M.x - centercircle.x)) * Mathf.Rad2Deg;

        //if (x != 0.0f || y != 0.0f) {
        //    angle = (Mathf.Atan2(x, y) * Mathf.Rad2Deg);
        //}

        if (angle < 0)
            angle += 360;

            CurMenuItem = (int) (angle / (360f / menuItmes));

        if(CurMenuItem != OldMenuItem) {

            buttons[OldMenuItem].sceneimage.color = buttons[OldMenuItem].NormalColor;
            OldMenuItem = CurMenuItem;
            buttons[CurMenuItem].sceneimage.color = buttons[CurMenuItem].HighlightedColor;
        }
    }

    public void ButtonAction() {

        buttons[CurMenuItem].sceneimage.color = buttons[CurMenuItem].PressedColor;
        if(CurMenuItem == 0) {

            print("What ever button 1 ist for");
        }

        if (CurMenuItem == 1) {

            print("What ever button 2 ist for");
        }

        if (CurMenuItem == 2) {

            print("What ever button 3 ist for");
        }

        if (CurMenuItem == 3) {

            print("What ever button 4 ist for");
        }

        if (CurMenuItem == 4) {

            print("What ever button 5 ist for");
        }

        if (CurMenuItem == 5) {

            print("What ever button 6 ist for");
        }
    }
}

[System.Serializable]
public class MenuButton {

    public string name;
    public Image sceneimage;
    public Color NormalColor = Color.white;
    public Color HighlightedColor = Color.grey;
    public Color PressedColor = Color.gray;
}