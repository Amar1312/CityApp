Shader "Custom/MouthRing_Pixel"
{
	Properties
	{
		_MainColor("Ring Color", Color) = (0,1,1,1)
		_RingWidth("Ring Width", Range(0, 0.5)) = 0.1
		_Smoothness("Smoothness", Range(0, 0.5)) = 0.02
		_Intensity("Intensity", Range(0, 1)) = 0.5
		_MinRadius("Min Radius", Range(0, 1)) = 0.3
		_MaxRadius("Max Radius", Range(0, 1)) = 0.5
		_MaxBrightness("Max Brightness", Range(1, 5)) = 2.0

		_PixelCount("Pixel Density", Range(16, 256)) = 64
	}

		SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		ZWrite Off
		Cull Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			float4 _MainColor;
			float _RingWidth;
			float _Smoothness;
			float _Intensity;
			float _MinRadius;
			float _MaxRadius;
			float _MaxBrightness;
			float _PixelCount;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv * 2.0 - 1.0; // -1 to 1
				return o;
			}

			float4 frag(v2f i) : SV_Target
			{
				//  PIXELATION
				float2 uv = i.uv;
				uv = floor(uv * _PixelCount) / _PixelCount;

				float dist = length(uv);

				float radius = lerp(_MinRadius, _MaxRadius, _Intensity);

				float ring = smoothstep(
					_RingWidth + _Smoothness,
					_RingWidth,
					abs(dist - radius)
				);

				float alpha = ring;

				// Brightness
				float brightness = 1.0 + (_MaxBrightness - 1.0) * _Intensity;
				float3 color = _MainColor.rgb * brightness;

				// Optional LED glow
				float glow = smoothstep(
					_RingWidth * 2.0,
					0.0,
					abs(dist - radius)
				) * _Intensity;

				color += glow;

				return float4(color, alpha * _MainColor.a);
			}
			ENDCG
		}
	}
}
