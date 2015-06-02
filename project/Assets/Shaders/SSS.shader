Shader "Custom/Translucent" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		_BumpMap ("Normal", 2D) = "bump" {}
		_Color ("Diffuse Color", Color) = (1,1,1,1)
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess ("Shininess", Range (0.05, 1)) = 0.05
		
		
		// SUBSURFACE SCATTERING PROPERTIES
		
		// Ambient value, representing translucency that is always present
		_Ambient ("Ambient", Range (0, 1)) = 0.0
	
		// Power value for direct translucency
		_Power ("Power", Float) = 1.0
		
		// Subsurface Distortion, shifts the surface normal, allows for more organic, Fresnel-like
		_Distortion ("Subsurface Distortion", Float) = 0.0
		
		// Pre-computed Local Thickness Map, attenuates the computation where surface thickness varies
		_Thickness ("Thickness Map", 2D) = "bump" {}
		
		// Scale value - should be defined per-light, this makes it the central control point
		_Scale ("Subsurface Scale", Float) = 0.5
		
		// Subsurface colour
		_SubColor ("Subsurface Color", Color) = (1.0, 1.0, 1.0, 1.0)
		
		// Subsurface Intensity
		_SubIntensity ("Subsurface Intensity", Range (0, 0.1)) = 0.05
		
		
		// OUTLINE PROPERTIES
		
		// Outline Size
		_OutlineSize ("Outline Size", Float) = 0
		
		// Outline Color
		_OutlineColor ("Outline Color", Color) = (0.0, 0.0, 0.0)
	}
	
	SubShader {
		Tags { "RenderType"="Opaque" }
		CGPROGRAM
			#pragma surface surf SSS
			
			sampler2D _MainTex, _BumpMap, _Thickness;
			float _Ambient, _Power, _Distortion, _Scale;
			half3 _OutlineColor;
			half4 _Color, _SubColor;
			half _Shininess, _SubIntensity, _OutlineSize;
			
			struct Input {
				float2 uv_MainTex;
			};

			void surf (Input IN, inout SurfaceOutput o) {
				half4 tex = tex2D(_MainTex, IN.uv_MainTex);
				o.Albedo = tex.rgb * _Color.rgb;
				o.Alpha = tex2D(_Thickness, IN.uv_MainTex).r;
				o.Gloss = tex.a;
				o.Specular = _Shininess;
				o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));
			}

			half4 LightingSSS (SurfaceOutput s, fixed3 lightDir, fixed3 viewDir, fixed atten)
			{		
				// Translucency
				half3 transLightDir = lightDir + s.Normal * _Distortion;
				float transDot = pow(saturate(dot(viewDir, -transLightDir)), _Power) * _Scale;
				half3 transLight = atten * 2 * (transDot + _Ambient) * s.Alpha;
				half3 translucency =  s.Albedo * _LightColor0.rgb * transLight;

				// Blinn-Phong
				half3 h = normalize(lightDir + viewDir);
				half diff = saturate(dot(s.Normal, lightDir));
				float nh = saturate(dot(s.Normal, h));
				float spec = pow(nh, s.Specular * 256.0 / 2.0) * s.Gloss;
				half3 diffuse = s.Albedo * diff;
				half3 specular = _SpecColor.rgb * spec;
				half3 blinn_phong = atten * 2 * _LightColor0.rgb * (diffuse + specular);

				// Result = Translucency + Blinn-Phong
				half4 c;
				c.rgb = translucency * (_SubIntensity + _SubColor.rgb);
				c.rgb += blinn_phong; // comment this line to use only translucency
				if (_OutlineSize != 0 && dot(viewDir, s.Normal) < _OutlineSize) {
					c.rgb = _OutlineColor;
				}
				c.a = _LightColor0.a * _SpecColor.a * atten;
				c.a *= spec; // comment this line to use only translucency
				return c;
			}
		ENDCG
	}
	FallBack "Bumped Diffuse"
}