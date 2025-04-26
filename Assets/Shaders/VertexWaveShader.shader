Shader "Custom/VertexWaveShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _WaveSpeed ("Wave Speed", Float) = 1.0
        _WaveHeight ("Wave Height", Float) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 normal : TEXCOORD0;
            };

            float _WaveSpeed;
            float _WaveHeight;

            v2f vert (appdata v)
            {
                v2f o;
                float wave = sin(_Time.y * _WaveSpeed + v.vertex.x) * _WaveHeight;
                v.vertex.y += wave;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                return half4(1, 1, 1, 1);
            }
            ENDCG
        }
    }
} 