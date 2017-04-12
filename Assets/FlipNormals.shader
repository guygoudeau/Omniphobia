Shader "Flip Normals" {
	Properties
	{

		_Color("Main Color", Color) = (1,1,1,0)
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}

	}

		SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" 
	}

	LOD 200
	Cull Front
	CGPROGRAM

	#pragma surface surf Lambert alpha:fade
	#pragma surface surf Lambert vertex:vert

	sampler2D _MainTex;
	fixed4 _Color;

	struct Input {
		float2 uv_MainTex;
	};

	void vert(inout appdata_full v)
	{
		v.normal.xyz = v.normal * -1;
	}

	void surf(Input IN, inout SurfaceOutput o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		o.Alpha = c.a;
	}
	ENDCG
	}

	Fallback "Legacy Shaders/Transparent/Diffuse"
}