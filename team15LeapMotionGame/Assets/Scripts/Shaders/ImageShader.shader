////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       ChannelMixer.shader
/// Author:         Chris Johnson
/// Date Created:   05/12/2021
/// Brief:  Shader used for colour blind settings
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Shader "Hidden/ImageShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _R("Red Mixing", Color) = (1,0,0,1)
        _G("Green Mixing", Color) = (0,1,0,1)
        _B("Blue Mixing", Color) = (0,0,1,1)
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
            fixed4 _R;
            fixed4 _G;
            fixed4 _B;

            //fixed4 frag (v2f i) : SV_Target
            //{
            //    fixed4 col = tex2D(_MainTex, i.uv);
            //    // just invert the colors
            //    col.rgb = 1 - col.rgb;
            //    return col;
            //}

            fixed4 frag(v2f_img i) : COLOR
            {
                fixed4 c = tex2D(_MainTex, i.uv);
                return fixed4
                (
                    c.r * _R[0] + c.g * _R[1] + c.b * _R[2],
                    c.r * _G[0] + c.g * _G[1] + c.b * _G[2],
                    c.r * _B[0] + c.g * _B[1] + c.b * _B[2],
                    c.a
                );
            }


            ENDCG
        }
    }
}
