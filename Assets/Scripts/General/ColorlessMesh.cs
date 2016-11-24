using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ColorlessMesh : MonoBehaviour {
    private MeshRenderer render = null;

    [SerializeField]
    private Texture2D _mainTexture = null;
    public Texture2D mainTexture {
        get { return _mainTexture; }
        set {
            _mainTexture = value;
            render.sharedMaterial.SetTexture("_MainTex", value);
        }
    }

    [SerializeField]
    private Texture2D _grayScaleTexture = null;
    public Texture2D grayScaleTexture {
        get { return _grayScaleTexture; }
        set {
            _grayScaleTexture = value;
            if (value != null) {
                render.sharedMaterial.SetTexture("_GrayTex", value);
                render.sharedMaterial.SetFloat("_grayFallback", 0);
            } else {
                render.sharedMaterial.SetFloat("_grayFallback", 1);
            }
        }
    }

    [SerializeField]
    private Texture2D _animationMaskTexture = null;
    public Texture2D animationMaskTexture {
        get { return _animationMaskTexture; }
        set {
            _animationMaskTexture = value;
            if (value != null) {
                render.sharedMaterial.SetTexture("_MaskTex", value);
                render.sharedMaterial.SetFloat("_animFallback", 0);
            } else {
                render.sharedMaterial.SetFloat("_animFallback", 1);
            }
        }
    }

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float _interpolationRange;
    public float interpolationRange {
        get { return _interpolationRange; }
        set {
            _interpolationRange = value;
            render.sharedMaterial.SetFloat("_interpolationRange", value);
        }
    }

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float _animationState;
    public float animationState {
        get { return _animationState; }
        set {
            _animationState = value;
            render.sharedMaterial.SetFloat("_animState", value);
        }
    }

    private void init() {
        render = GetComponent <MeshRenderer>();
        if (render == null || render.sharedMaterial == null) {
            render = gameObject.AddComponent<MeshRenderer>();
            render.sharedMaterial = new Material(Shader.Find("Custom/ColorlessAnimation"));
        }
        render.hideFlags = HideFlags.HideInInspector;
        render.sharedMaterial.hideFlags = HideFlags.HideInInspector;
    }

    void Awake() {
        init();
    }

    void OnEnable() {
        init();
    }

    public Material getMaterial() {
        return render.sharedMaterial;
    }

    private void editorPropertyHack() { //💀🔫
        mainTexture = mainTexture;
        grayScaleTexture = grayScaleTexture;
        animationMaskTexture = animationMaskTexture;
        interpolationRange = interpolationRange;
        animationState = animationState;
    }

    void Update() {
        if (Application.isEditor) {
            editorPropertyHack();
        }
    }
}
