using UnityEngine;
using System.Collections;

public class TextFade : MonoBehaviour {
    public TextMesh txt;
    public float speed;
    bool animating;

    public void animate() {
        animating = true;
        txt.color = new Color(1, 1, 1, 0);
    }

    void Awake() {
        txt.color = new Color(1, 1, 1, 0);
    }

    void Update() {
        if (animating) {
            float newAlpha = txt.color.a + speed * Time.deltaTime;
            if(newAlpha >= 1) {
                animating = false;
                newAlpha = 1;
            }
            txt.color = new Color(1, 1, 1, newAlpha);
        }
    }
}
