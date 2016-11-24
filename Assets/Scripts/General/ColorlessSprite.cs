using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class ColorlessSprite : MonoBehaviour {
    private SpriteRenderer render = null;

    [SerializeField] private Sprite _mainTexture = null;
    public Sprite mainTexture {
        get {return _mainTexture;}
        set {
            _mainTexture = value;
            render.sprite = value;
        }
    }

    [SerializeField] private Texture2D _grayScaleTexture = null;
    public Texture2D grayScaleTexture {
        get { return _grayScaleTexture; }
        set {
            _grayScaleTexture = value;
            if (value != null) {
                render.sharedMaterial.SetTexture("_GrayTex", value);
                render.sharedMaterial.SetFloat("_grayFallback", 0);
            }
            else {
                render.sharedMaterial.SetFloat("_grayFallback", 1);
            }
        }
    }

    [SerializeField] private Texture2D _animationMaskTexture = null;
    public Texture2D animationMaskTexture {
        get { return _animationMaskTexture; }
        set {
            _animationMaskTexture = value;
            if (value != null) {
                render.sharedMaterial.SetTexture("_MaskTex", value);
                render.sharedMaterial.SetFloat("_animFallback", 0);
            }
            else {
                render.sharedMaterial.SetFloat("_animFallback", 1);
            }
        }
    }

    [SerializeField] private bool _flipX = false;
    public bool flipX {
        get { return _flipX; }
        set {
            _flipX = value;
            render.flipX = value;
        }
    }

    [SerializeField] private bool _flipY = false;
    public bool flipY {
        get { return _flipY; }
        set {
            _flipY = value;
            render.flipY = value;
        }
    }

    [SerializeField][Range(0.0f, 1.0f)] private float _interpolationRange;
    public float interpolationRange {
        get { return _interpolationRange; }
        set {
            _interpolationRange = value;
            render.sharedMaterial.SetFloat("_interpolationRange", value);
        }
    }

    [SerializeField][Range(0.0f, 1.0f)] private float _animationState;
    public float animationState {
        get { return _animationState; }
        set {
            _animationState = value;
            render.sharedMaterial.SetFloat("_animState", value);
        }
    }

    private void init() {
        render = GetComponent<SpriteRenderer>();
        if (render == null || render.sharedMaterial == null) {
            render = gameObject.AddComponent<SpriteRenderer>();
            render.sharedMaterial = new Material(Shader.Find("Custom/ColorlessAnimation"));
        }
        render.sprite = mainTexture;
        render.hideFlags = HideFlags.HideInInspector;
        render.sharedMaterial.hideFlags = HideFlags.HideInInspector;
    }

    void Awake() {
        init();
    }

    void OnEnable() {
        init();
    }

    public Material getMaterial(){
        return render.sharedMaterial;
    }

    private void editorPropertyHack() { //💀🔫
        mainTexture = mainTexture;
        grayScaleTexture = grayScaleTexture;
        animationMaskTexture = animationMaskTexture;
        flipX = flipX;
        flipY = flipY;
        interpolationRange = interpolationRange;
        animationState = animationState;
    }

    void Update() {
        if (Application.isEditor) {
            editorPropertyHack();
        }
    }
}
