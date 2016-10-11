using UnityEngine;
using System.Collections;

public class ColorRangeEditor : MonoBehaviour {
    public Material mat;
    public float[] ranges = new float[16];

    public void randomize() {
        for(int i = 0; i < ranges.Length; i++) {
            ranges[i] = Mathf.Round(Random.value);
        }
    }

    public void none() {
        for (int i = 0; i < ranges.Length; i++) {
            ranges[i] = 0;
        }
    }

    public void all() {
        for (int i = 0; i < ranges.Length; i++) {
            ranges[i] = 1;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) randomize();
        if (Input.GetKeyDown(KeyCode.E)) none();
        if (Input.GetKeyDown(KeyCode.T)) all();
        mat.SetFloatArray("_rangeFlags", ranges);
    }
}
