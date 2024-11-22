Shader "Custom/DepthShader"
{
    Properties
    {
        _DepthMultiplier ("Depth Multiplier", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _CameraDepthTexture;
            float _DepthMultiplier;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = o.pos.xy * 0.5 + 0.5;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Read depth from depth texture
                float depth = tex2D(_CameraDepthTexture, i.uv).r;
                // Convert depth to brightness (closer = brighter)
                float brightness = (_DepthMultiplier * depth);
                brightness =  /*255.0 - */clamp(brightness, 0.0, 255.0); // not to let values excede 255
                return fixed4(brightness, brightness, brightness, 1.0); // rgba I think
            }
            ENDCG
        }
    }
}
