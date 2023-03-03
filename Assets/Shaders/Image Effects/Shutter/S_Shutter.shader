Shader "Hidden/S_Shutter"
{
    Properties
    {
        [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
        _ShutterVal ("Shutter Value (Debug)", Range(0,1)) = 0
        _FlashVal ("Flash Value (Debug)", Range(0,1)) = 0
        _FlashOpacity ("Flash Opacity", Range(0,1)) = 1
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Speed;
            float _ShutterVal;
            float _FlashVal;
            float _FlashOpacity;

            fixed4 frag (v2f i) : SV_Target
            {
                float gradient = 4 * (i.uv.y * (1 - i.uv.y));
                float shutter = 1 - step(gradient, sin(_ShutterVal * 3.14));
                float flash = sin(_FlashVal * 3.14) * _FlashOpacity;
                fixed4 col = (tex2D(_MainTex, i.uv) + flash) * shutter; 
                return col;
            }
            ENDCG
        }
    }
}
