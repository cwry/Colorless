using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditScroller : MonoBehaviour {

    public float speed;
    public float endPosition;
    public Text txt;

    void Update() {
        txt.rectTransform.position = new Vector3(txt.rectTransform.position.x, txt.rectTransform.position.y + Time.deltaTime * speed, txt.rectTransform.position.z);
        if(txt.rectTransform.anchoredPosition.y >= endPosition) {
            SceneManager.LoadScene(0);
        }
    }
}
