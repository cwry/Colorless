Shader "Custom/ColorlessAnimation" {
	Properties{
		_MainTex("Texture", 2D) = "white" {}
		_GrayTex("Grayscale", 2D) = "white" {}
		[Toggle] _grayFallback("Use grayscale fallback", Float) = 0
		_MaskTex("Animation Mask", 2D) = "black" {}
		[Toggle] _animFallback("Use mask fallback", Float) = 0
		_interpolationRange("Interpolation range", Range(0, 1)) = 0
		_animState("Animation state", Range(0, 1)) = 0
	}
	SubShader{
		Blend SrcAlpha OneMinusSrcAlpha
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		Pass{
			Cull Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _GrayTex;
			sampler2D _MaskTex;
			fixed _grayFallback;
			fixed _animFallback;
			fixed _interpolationRange;
			fixed _animState;

			//vv http://www.chilliant.com/rgb2hsv.html

			static float Epsilon = 1e-10;
			float3 RGBtoHCV(in float3 RGB) {
				float4 P = (RGB.g < RGB.b) ? float4(RGB.bg, -1.0, 2.0 / 3.0) : float4(RGB.gb, 0.0, -1.0 / 3.0);
				float4 Q = (RGB.r < P.x) ? float4(P.xyw, RGB.r) : float4(RGB.r, P.yzx);
				float C = Q.x - min(Q.w, Q.y);
				float H = abs((Q.w - Q.y) / (6 * C + Epsilon) + Q.z);
				return float3(H, C, Q.x);
			}

			float3 RGBtoHSV(in float3 RGB) {
				float3 HCV = RGBtoHCV(RGB);
				float S = HCV.y / (HCV.z + Epsilon);
				return float3(HCV.x, S, HCV.z);
			}

			float3 HUEtoRGB(in float H) {
				float R = abs(H * 6 - 3) - 1;
				float G = 2 - abs(H * 6 - 2);
				float B = 2 - abs(H * 6 - 4);
				return saturate(float3(R, G, B));
			}

			float3 HSVtoRGB(in float3 HSV) {
				float3 RGB = HUEtoRGB(HSV.x);
				return ((RGB - 1) * HSV.y + 1) * HSV.z;
			}

			//^^ http://www.chilliant.com/rgb2hsv.html

			struct vi {
				float4 vertex : POSITION;
				fixed2 uv : TEXCOORD0;
				fixed3 normal : NORMAL;
			};

			struct v2f {
				float4 pos : SV_POSITION;
				fixed2 uv : TEXCOORD0;
				float4 screenPos : TEXCOORD1;
				fixed3 normal : NORMAL;
			};

			v2f vert(vi i) {
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
				o.uv = i.uv;
				o.screenPos = ComputeScreenPos(o.pos);
				o.normal = normalize(i.normal);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target{
				fixed4 rgba = tex2D(_MainTex, i.uv);
				fixed3 hsv = RGBtoHSV(rgba);
				fixed thrF = 1 - _interpolationRange;
				fixed thr;
				if (_animFallback == 0) {
					thr = (1 - tex2D(_MaskTex, i.uv).x) * thrF;
				}
				else {
					fixed v = 1 - min(hsv.y, hsv.z);
					//return fixed4(v, v, v, rgba.a);
					thr = v * thrF;
				}

				if (_animState != 0 && thr <= _animState) {
					hsv.y *= min(1, ((_animState - thr) / _interpolationRange));
					return fixed4(HSVtoRGB(hsv), rgba.a);
				}
				
				if (_grayFallback == 0) {
					return tex2D(_GrayTex, i.uv);
				}
				return fixed4(hsv.z, hsv.z, hsv.z, rgba.a);
			}

			ENDCG
		}
	}
}
