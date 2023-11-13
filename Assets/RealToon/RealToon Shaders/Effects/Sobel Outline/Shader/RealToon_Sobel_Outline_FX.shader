//RealToon Sobel Outline V1.0.1
//MJQStudioWorks
//2018

Shader "Hidden/RealToon/Effects/Sobel Outline" {
    Properties {
        [HideInInspector]_MainTex ("MainTex", 2D) = "white" {}
        _OutlineWidth ("Outline Width", Range(0, 1)) = 0.02
        _OutlineColorPower ("Outline Color Power", Float ) = 2
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
    }
    SubShader {

        Pass {

        	Cull Off
            ZTest Always
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma only_renderers d3d9 d3d11 vulkan glcore gles3 gles metal xboxone ps4 wiiu switch
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            float3 S_O_P_P( float CX , float2 uv , sampler2D tex ){
                       			float2 d = float2(CX, CX);
                        
                    			float4 hr = float4(0, 0, 0, 0);
                    			float4 vt = float4(0, 0, 0, 0);
                    			
                    			hr += tex2D(tex, (uv + float2(-1.0, -1.0) * d)) *  1.0;
                    			hr += tex2D(tex, (uv + float2( 0.0, -1.0) * d)) *  0.0;
                    			hr += tex2D(tex, (uv + float2( 1.0, -1.0) * d)) * -1.0;
                    			hr += tex2D(tex, (uv + float2(-1.0,  0.0) * d)) *  2.0;
                    			hr += tex2D(tex, (uv + float2( 0.0,  0.0) * d)) *  0.0;
                    			hr += tex2D(tex, (uv + float2( 1.0,  0.0) * d)) * -2.0;
                    			hr += tex2D(tex, (uv + float2(-1.0,  1.0) * d)) *  1.0;
                    			hr += tex2D(tex, (uv + float2( 0.0,  1.0) * d)) *  0.0;
                    			hr += tex2D(tex, (uv + float2( 1.0,  1.0) * d)) * -1.0;
                    			
                    			vt += tex2D(tex, (uv + float2(-1.0, -1.0) * d)) *  1.0;
                    			vt += tex2D(tex, (uv + float2( 0.0, -1.0) * d)) *  2.0;
                    			vt += tex2D(tex, (uv + float2( 1.0, -1.0) * d)) *  1.0;
                    			vt += tex2D(tex, (uv + float2(-1.0,  0.0) * d)) *  0.0;
                    			vt += tex2D(tex, (uv + float2( 0.0,  0.0) * d)) *  0.0;
                    			vt += tex2D(tex, (uv + float2( 1.0,  0.0) * d)) *  0.0;
                    			vt += tex2D(tex, (uv + float2(-1.0,  1.0) * d)) * -1.0;
                    			vt += tex2D(tex, (uv + float2( 0.0,  1.0) * d)) * -2.0;
                    			vt += tex2D(tex, (uv + float2( 1.0,  1.0) * d)) * -1.0;
                    			
                    			return sqrt(hr * hr + vt * vt);
            }
            
            uniform float _OutlineColorPower;
            uniform float _OutlineWidth;
            uniform float4 _OutlineColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {

                float4 node_1672 = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_578 = S_O_P_P( lerp(0.0,0.006,_OutlineWidth) , i.uv0 , _MainTex );
                float4 node_7147_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_7147_p = lerp(float4(float4(node_578,0.0).zy, node_7147_k.wz), float4(float4(node_578,0.0).yz, node_7147_k.xy), step(float4(node_578,0.0).z, float4(node_578,0.0).y));
                float4 node_7147_q = lerp(float4(node_7147_p.xyw, float4(node_578,0.0).x), float4(float4(node_578,0.0).x, node_7147_p.yzx), step(node_7147_p.x, float4(node_578,0.0).x));
                float node_7147_d = node_7147_q.x - min(node_7147_q.w, node_7147_q.y);
                float node_7147_e = 1.0e-10;
                float3 node_7147 = float3(abs(node_7147_q.z + (node_7147_q.w - node_7147_q.y) / (6.0 * node_7147_d + node_7147_e)), node_7147_d / (node_7147_q.x + node_7147_e), node_7147_q.x);;
                float3 finalColor = lerp(node_1672.rgb,(lerp(node_1672.rgb,(node_1672.rgb*node_1672.rgb),_OutlineColorPower)*_OutlineColor.rgb),node_7147.b);
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
}
