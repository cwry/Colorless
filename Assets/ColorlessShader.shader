Shader "Custom/ColorlessShader" {
	Properties {
		_MainTex("Texture", 2D) = "white" {}
		[Toggle] _smooth("Smoothen Edges", Float) = 0
	}
	SubShader{
		Blend SrcAlpha OneMinusSrcAlpha
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed4 _MainTex_TexelSize;
			fixed _smooth;
			float _rangeFlags[16];

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

			static float hueRange[16] = {11, 21, 41, 51, 61, 81, 141, 170, 201, 221, 241, 281, 321, 331, 346, 355};
			int hueToRangeId(float hueF){
				int hue = hueF * 360.0;
				for (int i = 0; i < 16; i++) {
					if (hue < hueRange[i]) return i;
				}
				return 0;
			}

			fixed filterHSVColor(float3 hsv) {
				int rangeId = hueToRangeId(hsv.x);
				return _rangeFlags[hueToRangeId(hsv.x)];
			}

			fixed smoothSample(fixed2 uv) {
				fixed4 up = _rangeFlags[hueToRangeId(RGBtoHSV(tex2D(_MainTex, uv + fixed2(0, _MainTex_TexelSize.y)))).x];
				fixed4 down = _rangeFlags[hueToRangeId(RGBtoHSV(tex2D(_MainTex, uv - fixed2(0, _MainTex_TexelSize.y)))).x];
				fixed4 left = _rangeFlags[hueToRangeId(RGBtoHSV(tex2D(_MainTex, uv - fixed2(_MainTex_TexelSize.x, 0)))).x];
				fixed4 right = _rangeFlags[hueToRangeId(RGBtoHSV(tex2D(_MainTex, uv + fixed2(_MainTex_TexelSize.x, 0)))).x];
				return max(max(up, down), max(left, right)) * 0.5;
			}

			v2f vert(vi i) {
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
				o.uv = i.uv;
				o.screenPos = ComputeScreenPos(o.pos);
				o.normal = normalize(i.normal);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target {
				fixed4 texclr = tex2D(_MainTex, i.uv);
				fixed3 hsv = RGBtoHSV(texclr.rgb);
				fixed factor = _rangeFlags[hueToRangeId(hsv.x)];
				if (_smooth == 1 && factor == 0) {
					factor = smoothSample(i.uv);
				}
				hsv.y *= factor;
				fixed3 rgb = HSVtoRGB(hsv);
				return fixed4(rgb, texclr.a);
			}

			ENDCG
		}
	}
}
