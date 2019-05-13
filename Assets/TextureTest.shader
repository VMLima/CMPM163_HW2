Shader "Custom/TextureTest" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _GrassTex ("Grass Texture", 2D) = "white" {}
        _RockTex ("Rock Texture", 2D) = "white" {}
        _WaterTex ("Water Texture", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
	
    SubShader{
        Tags { "RenderType" = "Opaque" }
        Pass{  
            Cull Off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
                      
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv: TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv: TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
             
            sampler2D _MainTex;
            sampler2D _GrassTex;
            sampler2D _RockTex;
            sampler2D _WaterTex;

            float4 _MainTex_ST;
            float4 _GrassTex_ST;
            float4 _RockTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }
                      
            fixed4 frag(v2f i) : SV_Target {
                          
                float4 C = tex2D( _MainTex, i.uv);
                float4 col;
                 
                if (C.r == 0 && C.g == 1 && C.b == 0) {
                    col = tex2D(_GrassTex, i.uv);

                } else if (C.r == 1 && C.g == 0 && C.b == 0) {
                    col = tex2D(_RockTex, i.uv);

                } else if (C.r == 0 && C.g == 0 && C.b == 1) {
                    col = tex2D(_WaterTex, i.uv);

                } else {
                    col = tex2D(_MainTex, i.uv);
                }

                UNITY_APPLY_FOG(i.fogCoord, col);
                UNITY_OPAQUE_ALPHA(col.a);
                return col;
                          
            }

            ENDCG
        }

        // Pulled from Unity Standard Shader
        Pass {
            Name "ShadowCaster"
            Tags { "LightMode" = "ShadowCaster" }

            ZWrite On ZTest LEqual

            CGPROGRAM
            #pragma target 3.0

                // -------------------------------------


                #pragma shader_feature _ _ALPHATEST_ON _ALPHABLEND_ON _ALPHAPREMULTIPLY_ON
                #pragma shader_feature _METALLICGLOSSMAP
                #pragma shader_feature _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
                #pragma shader_feature _PARALLAXMAP
                #pragma multi_compile_shadowcaster
                #pragma multi_compile_instancing
                // Uncomment the following line to enable dithering LOD crossfade. Note: there are more in the file to uncomment for other passes.
                //#pragma multi_compile _ LOD_FADE_CROSSFADE

                #pragma vertex vertShadowCaster
                #pragma fragment fragShadowCaster

                #include "UnityStandardShadow.cginc"

                ENDCG
            }

        }

}
