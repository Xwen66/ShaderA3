Shader "Unlit/WaveShader"
{
    Properties
    {
        _WaveHeight ("Wave Height", Float) = 0.5
        _WaveColor ("Wave Color", Color) = (0, 0, 1, 1)
        _WaveSpeed ("Wave Speed", Float) = 1.0
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _WaveHeight;
            float4 _WaveColor;
            float _WaveSpeed;

            v2f vert (appdata v)
            {
                v2f o;
                float wave = sin(v.vertex.x * 10.0 + _Time.y * _WaveSpeed) * _WaveHeight;
                float4 modifiedVertex = v.vertex;
                modifiedVertex.y += wave;
                o.vertex = UnityObjectToClipPos(modifiedVertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * _WaveColor;
                return col;
            }
            ENDCG
        }
    }
}
