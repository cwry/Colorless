using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueSystem : MonoBehaviour {

    public Text textField;
    public string[] texts;

    private int index = 0;
    private bool showing = false;

    public void show(){
        if (texts == null) return;
        index = 0;
        textField.text = texts[0];
        Globals.suppressPlayInput = true;
        showing = true;
        Time.timeScale = float.Epsilon;
        gameObject.SetActive(true);
    }

    public void hide(){
        Globals.suppressPlayInput = false;
        showing = false;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    void Update(){
        if (showing){
            if (Input.GetKeyDown(KeyCode.Space)){
                if(texts.Length > index + 1){
                    index++;
                    textField.text = texts[index];
                }
                else{
                    hide();
                }
            }
        }
    }
}
