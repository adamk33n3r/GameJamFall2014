﻿Shader "Custom/Diffuse2Sided" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	}
	SubShader {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		Cull Off
		LOD 200
		CGPROGRAM
		#pragma surface surf TwoSided alpha
		sampler2D _MainTex;
		fixed4 _Color;
		struct Input {
			float2 uv_MainTex;
		};
		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		half4 LightingTwoSided(SurfaceOutput s, half3 lightDir, half atten) {
			half NdotL = dot (s.Normal, lightDir);
			half INdotL = dot (-s.Normal, lightDir);
			// Figure out if we should use the inverse normal or the regular normal based on light direction.
			half diff = (NdotL < 0) ? INdotL : NdotL;
			half4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * (diff * atten);
			c.a = s.Alpha;
			return c;
		}
		ENDCG
	}
	Fallback "Transparent/VertexLit"
}