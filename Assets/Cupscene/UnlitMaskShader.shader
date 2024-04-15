Shader "Custom/UnlitMaskShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _MousePos("Mouse Position", Vector) = (0.5, 0.5, 0, 0)
        _Radius("Radius", Float) = 0.1
    }
    SubShader
    {
        Tags { "Queue" = "Overlay" }
        ZWrite Off
        Blend One OneMinusSrcAlpha
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
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            uniform float2 _MousePos; // Mouse position in UV coordinates
            uniform float _Radius;    // Radius of transparency around the mouse

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Calculate distance from UV coordinate to mouse position
                float distance = length(i.uv - _MousePos);
                // Use smoothstep to create a smooth transition based on the radius
                float alpha = smoothstep(_Radius - 0.01, _Radius + 0.01, distance);
                // Apply transparency effect
                fixed4 col = tex2D(_MainTex, i.uv);
                col.a *= alpha;
                return col;
            }
            ENDCG
        }
    }
}
