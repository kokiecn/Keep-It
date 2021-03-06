// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Unlit/CullBack"
{
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
        [KeywordEnum(None, Front, Back)] _Cull("Culling", Int) = 2
    }
        SubShader{
            Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
            Lighting Off
            Cull[_Cull]
            ZTest Always ZWrite Off Fog { Mode Off }
            Blend SrcAlpha OneMinusSrcAlpha
            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma fragmentoption ARB_precision_hint_fastest
                #include "UnityCG.cginc"

                struct appdata_t {
                    float4 vertex : POSITION;
                    fixed4 color : COLOR;
                    float2 texcoord : TEXCOORD0;
                };

                struct v2f {
                    float4 vertex : POSITION;
                    fixed4 color : COLOR;
                    float2 texcoord : TEXCOORD0;
                };

                sampler2D _MainTex;
                uniform float4 _MainTex_ST;
                uniform fixed4 _Color;

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.color = v.color * _Color;
                    o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : COLOR
                {
                    fixed4 col = i.color * tex2D(_MainTex, i.texcoord);
                    return col;
                }
                ENDCG
            }
        }
}