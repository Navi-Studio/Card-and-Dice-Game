//RealToon V5.0.8
//MJQStudioWorks
//2020

Shader "RealToon/Version 5/Lite/Default" {
    Properties {

		[Enum(Off,2,On,0)] _DoubleSided("Double Sided", int) = 2

        _MainTex ("Texture", 2D) = "white" {}
        [HDR] _MainColor ("Main Color", Color) = (0.6886792,0.6886792,0.6886792,1)

		[Toggle(NOKEWO)] _MVCOL ("Mix Vertex Color", Float ) = 0

		[Toggle(NOKEWO)] _MCIALO ("Main Color In Ambient Light Only", Float ) = 0

		[HDR] _HighlightColor ("Highlight Color", Color) = (1,1,1,1)
        _HighlightColorPower ("Highlight Color Power", Float ) = 1

        [Toggle(NOKEWO)] _EnableTextureTransparent ("Enable Texture Transparent", Float ) = 0

		_MCapIntensity ("Intensity", Range(0, 1)) = 1
		_MCap ("MatCap", 2D) = "white" {}
		[Toggle(NOKEWO)] _SPECMODE ("Specular Mode", Float ) = 0
		_SPECIN ("Specular Power", Float ) = 1
		_MCapMask ("Mask MatCap", 2D) = "white" {}

        _NormalMap ("Normal Map", 2D) = "bump" {}
        _NormalMapIntensity ("Intensity", Float ) = 1

        _OutlineWidth ("Width", Float ) = 0.5
        _OutlineWidthControl ("Width Control", 2D) = "white" {}

		[Enum(Normal,0,Origin,1)] _OutlineExtrudeMethod("Outline Extrude Method", int) = 0

		_OutlineOffset ("Outline Offset", Vector) = (0,0,0)
		_OutlineZPostionInCamera ("Outline Z Position In Camera", Float) = 0

		[Enum(Off,1,On,0)] _DoubleSidedOutline("Double Sided Outline", int) = 1

        [Toggle(NOKEWO)] _OutlineWidthAffectedByViewDistance ("Outline Width Affected By View Distance", Float ) = 0
		_FarDistanceMaxWidth ("Far Distance Max Width", Float ) = 10

        [Toggle(NOKEWO)] _VertexColorBlueAffectOutlineWitdh ("Vertex Color Blue Affect Outline Width", Float ) = 0
        [HDR] _OutlineColor ("Color", Color) = (0,0,0,1)

		[Toggle(NOKEWO)] _MixMainTexToOutline ("Mix Main Texture To Outline", Float ) = 0

        [Toggle(NOKEWO)] _LightAffectOutlineColor ("Light Affect Outline Color", Float ) = 0

        _SelfLitIntensity ("Intensity", Range(0, 1)) = 0
        [HDR] _SelfLitColor ("Color", Color) = (1,1,1,1)
        _SelfLitPower ("Power", Float ) = 2
		_TEXMCOLINT ("Texture and Main Color Intensity", Float ) = 1
        [Toggle(NOKEWO)] _SelfLitHighContrast ("High Contrast", Float ) = 1
        _MaskSelfLit ("Mask Self Lit", 2D) = "white" {}

        _Glossiness ("Glossiness", Range(0, 1)) = 0.6
        _GlossSoftness ("Softness", Range(0, 1)) = 0
        [HDR] _GlossColor ("Color", Color) = (1,1,1,1)
        _GlossColorPower ("Color Power", Float ) = 10
        _MaskGloss ("Mask Gloss", 2D) = "white" {}

        _GlossTexture ("Gloss Texture", 2D) = "black" {}
        _GlossTextureSoftness ("Softness", Float ) = 0
		[Toggle(NOKEWO)] _PSGLOTEX ("Pattern Style", Float ) = 0 
        [Toggle(NOKEWO)] _GlossTextureFollowObjectRotation ("Follow Object Rotation", Float ) = 0
        _GlossTextureFollowLight ("Follow Light", Range(0, 1)) = 0

        [HDR] _OverallShadowColor ("Overall Shadow Color", Color) = (0,0,0,1)
        _OverallShadowColorPower ("Overall Shadow Color Power", Float ) = 1
        [Toggle(NOKEWO)] _SelfShadowShadowTAtViewDirection ("Self Shadow & ShadowT At View Direction", Float ) = 0

        _SelfShadowThreshold ("Threshold", Range(0, 1)) = 0.85
        _SelfShadowHardness ("Hardness", Range(0, 1)) = 1
        [Toggle(NOKEWO)] _VertexColorGreenControlSelfShadowThreshold ("Vertex Color Green Control Self Shadow Threshold", Float ) = 0
        [HDR] _SelfShadowRealTimeShadowColor ("Self Shadow & Real Time Shadow Color", Color) = (1,1,1,1)
        _SelfShadowRealTimeShadowColorPower ("Self Shadow & Real Time Shadow Color Power", Float ) = 1

        _SmoothObjectNormal ("Smooth Object Normal", Range(0, 1)) = 0
        [Toggle(NOKEWO)] _VertexColorRedControlSmoothObjectNormal ("Vertex Color Red Control Smooth Object Normal", Float ) = 0
        _XYZPosition ("XYZ Position", Vector) = (0,0,0,0)
        _XYZHardness ("XYZ Hardness", Float ) = 14
        [Toggle(NOKEWO)] _ShowNormal ("Show Normal", Float ) = 0

        _ShadowColorTexture ("Shadow Color Texture", 2D) = "white" {}
        _ShadowColorTexturePower ("Power", Float ) = 0

        _ShadowT ("ShadowT", 2D) = "white" {}
        _ShadowTLightThreshold ("Light Threshold", Float ) = 50
        _ShadowTShadowThreshold ("Shadow Threshold", Float ) = 0
        _ShadowTHardness ("Hardness", Range(0, 1)) = 1
        [HDR] _ShadowTColor ("Color", Color) = (1,1,1,1)
        _ShadowTColorPower ("Color Power", Float ) = 1
        [Toggle(NOKEWO)] _LightFalloffAffectShadowT ("Light Falloff Affect ShadowT", Float ) = 0

		[Toggle(NOKEWO)] _STIL ("Ignore Light", Float ) = 0

        _PTexture ("PTexture", 2D) = "white" {}
        _PTexturePower ("Power", Float ) = 0

		_DirectionalLightIntensity ("Directional Light Intensity", Float ) = 0
		_PointSpotlightIntensity ("Point and Spot Light Intensity", Float ) = 0.1

		[Toggle(L_F_RELGI_ON)] _RELG ("Receive Environmental Lighting and GI", Float ) = 1
		[Toggle(L_F_UOAL_ON)] _L_F_UOAL ("Use Old Ambient Light", Float ) = 0

		_LightFalloffSoftness ("Light Falloff Softness", Range(0, 1)) = 1

        _CustomLightDirectionIntensity ("Intensity", Range(0, 1)) = 0
        [Toggle(NOKEWO)] _CustomLightDirectionFollowObjectRotation ("Custom Light Direction Follow Object Rotation", Float ) = 0
        _CustomLightDirection ("Custom Light Direction", Vector) = (0,0,10,0)

        _FReflectionIntensity ("Intensity", Range(0, 1)) = 0
        _FReflection ("FReflection", 2D) = "black" {}
        _FReflectionRoughtness ("Roughtness", Float ) = 0

		_RefMetallic ("Metallic", Range(0, 1) ) = 0

		_MaskFReflection ("Mask FReflection", 2D) = "white" {}

        _RimLightUnfill ("Unfill", Float ) = 1.5
        _RimLightSoftness ("Softness", Range(0, 1)) = 1
        [HDR] _RimLightColor ("Color", Color) = (1,1,1,1)
        _RimLightColorPower ("Color Power", Float ) = 10
		[Toggle(NOKEWO)] _RimLightInLight ("Rim Light In Light", Float ) = 1
        [Toggle(NOKEWO)] _LightAffectRimLightColor ("Light Affect Rim Light Color", Float ) = 0

		_RefVal ("ID", int ) = 0
        [Enum(Blank,8,A,0,B,2)] _Oper("Set 1", int) = 0
        [Enum(Blank,8,None,4,A,6,B,7)] _Compa("Set 2", int) = 4

		[Toggle(L_F_MC_ON)] _L_F_MC ("MatCap", Float ) = 0
		[Toggle(L_F_NM_ON)] _L_F_NM ("Normal Map", Float ) = 0
		[Toggle(L_F_O_ON)] _L_F_O ("Outline", Float ) = 1
		[Toggle(L_F_SL_ON)] _L_F_SL ("Self Lit", Float ) = 0
		[Toggle(L_F_GLO_ON)] _L_F_GLO ("Gloss", Float ) = 0
		[Toggle(L_F_GLOT_ON)] _L_F_GLOT ("Gloss Texture", Float ) = 0
		[Toggle(L_F_SS_ON)] _L_F_SS ("Self Shadow", Float ) = 1
		[Toggle(L_F_SON_ON)] _L_F_SON ("Smooth Object Normal", Float ) = 0
		[Toggle(L_F_SCT_ON)] _L_F_SCT ("Shadow Color Texture", Float ) = 0
		[Toggle(L_F_ST_ON)] _L_F_ST ("ShadowT", Float ) = 0
		[Toggle(L_F_PT_ON)] _L_F_PT ("PTexture", Float ) = 0
		[Toggle(L_F_CLD_ON)] _L_F_CLD ("Custom Light Direction", Float ) = 0
		[Toggle(L_F_FR_ON)] _L_F_FR ("FRelfection", Float ) = 0
		[Toggle(L_F_RL_ON)] _L_F_RL ("Rim Light", Float ) = 0
		[Toggle(L_F_HPSS_ON)] _L_F_HPSS ("Hide Point & Spot Light Shadow", Float ) = 0

    }

    SubShader {
        Tags {
            "Queue"="Geometry"
			"RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
					"LightMode" = "Always"
            }
            Cull [_DoubleSidedOutline]

            Stencil {
            	Ref[_RefVal]
            	Comp [_Compa]
            	Pass [_Oper]
            	Fail [_Oper]
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog

			#pragma multi_compile_instancing

            #pragma only_renderers d3d9 d3d11 vulkan glcore gles3 gles metal xboxone ps4 wiiu switch
            #pragma target 3.0

			#pragma shader_feature L_F_O_ON

			uniform float4 _LightColor0;

			uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
			uniform fixed _EnableTextureTransparent;

			uniform half _OutlineWidth;
			uniform sampler2D _OutlineWidthControl; uniform float4 _OutlineWidthControl_ST;
			uniform int _OutlineExtrudeMethod;
			uniform float3 _OEM;
			uniform half3 _OutlineOffset;
			uniform half _OutlineZPostionInCamera;
			uniform half4 _OutlineColor;
			uniform half _MixMainTexToOutline;
			uniform fixed _LightAffectOutlineColor;
			uniform fixed _OutlineWidthAffectedByViewDistance;
			uniform half _FarDistanceMaxWidth;
			uniform fixed _VertexColorBlueAffectOutlineWitdh;

            struct VertexInput 
			{

				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 texcoord0 : TEXCOORD0;
				float4 vertexColor : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID

            };

            struct VertexOutput 
			{

				float4 pos : SV_POSITION;
				float2 uv0 : TEXCOORD0;
				float4 vertexColor : COLOR;
				UNITY_FOG_COORDS(1)
				UNITY_VERTEX_OUTPUT_STEREO

            };

            VertexOutput vert (VertexInput v)
			{

                VertexOutput o = (VertexOutput)0;

				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_OUTPUT(VertexOutput,o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				o.uv0 = v.texcoord0;
				o.vertexColor = v.vertexColor;

				float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
				half RTL_OB_VP_CAL = distance(objPos.rgb,_WorldSpaceCameraPos);

				half RTL_OL_VCRAOW_OO = lerp( _OutlineWidth, (_OutlineWidth*(1.0 - o.vertexColor.b)), _VertexColorBlueAffectOutlineWitdh );
				half RTL_OL_OLWABVD_OO = lerp( RTL_OL_VCRAOW_OO, ( clamp(RTL_OL_VCRAOW_OO*RTL_OB_VP_CAL, RTL_OL_VCRAOW_OO, _FarDistanceMaxWidth) ) , _OutlineWidthAffectedByViewDistance );     
				half4 _OutlineWidthControl_var = tex2Dlod(_OutlineWidthControl,float4(TRANSFORM_TEX(o.uv0, _OutlineWidthControl),0.0,0));

				_OEM = lerp(v.normal,normalize(v.vertex),_OutlineExtrudeMethod); 
				
				half RTL_OL = ( RTL_OL_OLWABVD_OO * 0.01 ) * _OutlineWidthControl_var.r;
				o.pos = UnityObjectToClipPos( float4((v.vertex.xyz + _OutlineOffset.xyz * 0.01) + _OEM*RTL_OL,1) );
				
				#if defined(SHADER_API_GLCORE) || defined(SHADER_API_GLES) || defined(SHADER_API_GLES3)
					o.pos.z = o.pos.z + _OutlineZPostionInCamera * 0.0005;
				#else
					o.pos.z = o.pos.z - _OutlineZPostionInCamera * 0.0005;
				#endif
				
				UNITY_TRANSFER_FOG(o,o.pos);

                return o;
            }

            float4 frag(VertexOutput i) : COLOR 
			{

				float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
				float3 lightColor = _LightColor0.rgb;

				half4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
				clip(lerp( 1.0, _MainTex_var.a, _EnableTextureTransparent ) - 0.5);


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_OutlineColor = float4(GammaToLinearSpace(_OutlineColor.rgb), _OutlineColor.a);
				#endif

				float node_6587 = 0.0;
				half3 RTL_OL_LAOC_OO = lerp( lerp(_OutlineColor.rgb,_OutlineColor.rgb * _MainTex_var, _MixMainTexToOutline), lerp(float3(node_6587,node_6587,node_6587), lerp(_OutlineColor.rgb,_OutlineColor.rgb * _MainTex_var, _MixMainTexToOutline) ,lightColor.rgb), _LightAffectOutlineColor );
				//


				fixed4 finalRGBA = fixed4(RTL_OL_LAOC_OO,1);

				UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
				return finalRGBA;

            }

            ENDCG

        }

        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }

            Cull [_DoubleSided]

            Stencil {
            	Ref[_RefVal]
            	Comp [_Compa]
            	Pass [_Oper]
            	Fail [_Oper]
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog

			#pragma multi_compile_instancing

            #pragma only_renderers d3d9 d3d11 vulkan glcore gles3 gles metal xboxone ps4 wiiu switch
            #pragma target 3.0

			#pragma shader_feature L_F_MC_ON
			#pragma shader_feature L_F_NM_ON
			#pragma shader_feature L_F_SL_ON
			#pragma shader_feature L_F_GLO_ON
			#pragma shader_feature L_F_GLOT_ON
			#pragma shader_feature L_F_SS_ON
			#pragma shader_feature L_F_SON_ON
			#pragma shader_feature L_F_SCT_ON
			#pragma shader_feature L_F_ST_ON
			#pragma shader_feature L_F_PT_ON
			#pragma shader_feature L_F_FR_ON
			#pragma shader_feature L_F_RL_ON
			#pragma shader_feature L_F_RELGI_ON
			#pragma shader_feature L_F_UOAL_ON
			#pragma shader_feature L_F_CLD_ON

			uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform half4 _MainColor;
			uniform half _MVCOL;
			uniform fixed _MCIALO;

			uniform half4 _HighlightColor;
            uniform half _HighlightColorPower;

			uniform fixed _EnableTextureTransparent;

			#if L_F_MC_ON
				uniform half _MCapIntensity;
				uniform sampler2D _MCap; uniform float4 _MCap_ST;
				uniform half _SPECMODE;
				uniform half _SPECIN;
				uniform sampler2D _MCapMask; uniform float4 _MCapMask_ST;
			#endif

			#if L_F_NM_ON
				uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
				uniform half _NormalMapIntensity;
			#endif

			#if L_F_SL_ON
				uniform half _SelfLitIntensity;
				uniform half4 _SelfLitColor;
				uniform half _SelfLitPower;
				uniform half _TEXMCOLINT;
				uniform fixed _SelfLitHighContrast;
				uniform sampler2D _MaskSelfLit; uniform float4 _MaskSelfLit_ST;
			#endif

			#if L_F_GLO_ON
				uniform half _Glossiness;
				uniform half _GlossSoftness;
				uniform half4 _GlossColor;
				uniform half _GlossColorPower;
				uniform sampler2D _MaskGloss; uniform float4 _MaskGloss_ST;
			#endif

			#if L_F_GLO_ON
				#if L_F_GLOT_ON
					uniform sampler2D _GlossTexture; uniform float4 _GlossTexture_ST;
					uniform half _GlossTextureSoftness;
					uniform half _PSGLOTEX;
					uniform fixed _GlossTextureFollowObjectRotation;
					uniform half _GlossTextureFollowLight;
				#endif
			#endif

			uniform half4 _OverallShadowColor;
            uniform half _OverallShadowColorPower;

			uniform fixed _SelfShadowShadowTAtViewDirection;

			#if L_F_SS_ON
				uniform half _SelfShadowThreshold;
				uniform half _SelfShadowHardness;
				uniform fixed _VertexColorGreenControlSelfShadowThreshold;
			#endif

			uniform half4 _SelfShadowRealTimeShadowColor;
            uniform half _SelfShadowRealTimeShadowColorPower;

			#if L_F_SON_ON
				uniform half _SmoothObjectNormal;
				uniform fixed _VertexColorRedControlSmoothObjectNormal;
				uniform float4 _XYZPosition;
				uniform half _XYZHardness;
				uniform fixed _ShowNormal;
			#endif

			#if L_F_SCT_ON
				uniform sampler2D _ShadowColorTexture; uniform float4 _ShadowColorTexture_ST;
				uniform half _ShadowColorTexturePower;
			#endif

			#if L_F_ST_ON
				uniform sampler2D _ShadowT; uniform float4 _ShadowT_ST;
				uniform half _ShadowTLightThreshold;
				uniform half _ShadowTShadowThreshold;
				uniform half4 _ShadowTColor;
				uniform half _ShadowTColorPower;
				uniform half _ShadowTHardness;
				uniform half _STIL;
				uniform fixed _LightFalloffAffectShadowT;
			#endif
			
			#if L_F_PT_ON
			    uniform sampler2D _PTexture; uniform float4 _PTexture_ST;
				uniform half _PTexturePower;
			#endif

			uniform half _DirectionalLightIntensity;

			#if L_F_CLD_ON
				uniform half _CustomLightDirectionIntensity;
				uniform half4 _CustomLightDirection;
				uniform fixed _CustomLightDirectionFollowObjectRotation;
			#endif

			#if L_F_FR_ON
				uniform half _FReflectionIntensity;
				uniform sampler2D _FReflection; uniform float4 _FReflection_ST;
				uniform half _FReflectionRoughtness;
				uniform half _RefMetallic;
				uniform sampler2D _MaskFReflection; uniform float4 _MaskFReflection_ST;
			#endif
                        
			#if L_F_RL_ON
				uniform half _RimLightUnfill;
				uniform half _RimLightSoftness;
				uniform fixed _LightAffectRimLightColor;
				uniform half4 _RimLightColor;
				uniform half _RimLightColorPower;
				uniform fixed _RimLightInLight;
			#endif

			#if L_F_RELGI_ON

				half3 AL_GI()
				{
					return ShadeSH9(float4(0,0,0,1));
				}

			#endif

            struct VertexInput 
			{

                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID

            };

            struct VertexOutput 
			{

                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
				UNITY_VERTEX_OUTPUT_STEREO

            };

            VertexOutput vert (VertexInput v) 
			{

                VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_OUTPUT(VertexOutput,o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;

                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);

                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);

                o.pos = UnityObjectToClipPos( v.vertex );

                UNITY_TRANSFER_FOG(o,o.pos);

                o.projPos = ComputeScreenPos (o.pos);

                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)

                return o;

            }

            float4 frag(VertexOutput i) : COLOR 
			{

				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

				#if L_F_NM_ON
					half3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
					float3 normalLocal = lerp(half3(0,0,1),_NormalMap_var.rgb,_NormalMapIntensity);
				#else
					float3 normalLocal = half3(0,0,1);
				#endif

                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
				float2 sceneUVs = (i.projPos.xy / i.projPos.w);

                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform ));

				half RTL_OB_VP_CAL = distance(objPos.rgb,_WorldSpaceCameraPos);
				half2 RTL_VD_CAL = (float2((sceneUVs.x * 2 - 1)*(_ScreenParams.r/_ScreenParams.g), sceneUVs.y * 2 - 1).rg*RTL_OB_VP_CAL);

				#if L_F_MC_ON
            
					half2 MUV = (mul( UNITY_MATRIX_V, float4(normalDirection,0) ).xyz.rgb.rg*0.5+0.5);
					half4 _MatCap_var = tex2D(_MCap,TRANSFORM_TEX(MUV, _MCap));
					half4 _MCapMask_var = tex2D(_MCapMask,TRANSFORM_TEX(i.uv0, _MCapMask));
					float3 MCapOutP = lerp( lerp(1,0, _SPECMODE), lerp( lerp(1,0, _SPECMODE) ,_MatCap_var.rgb,_MCapIntensity) ,_MCapMask_var.rgb ); 

				#else
            
					half MCapOutP = 1;

				#endif

                half4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
				clip(lerp( 1.0, _MainTex_var.a, _EnableTextureTransparent ) - 0.5);
				half3 _RTL_MVCOL = lerp(1, i.vertexColor, _MVCOL);


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_MainColor = float4(GammaToLinearSpace(_MainColor.rgb), _MainColor.a);
				#endif

				#if L_F_MC_ON 

					half3 SPECMode_Sel = lerp( (_MainColor.rgb * MCapOutP), ( _MainColor.rgb + (MCapOutP * _SPECIN) ), _SPECMODE);
					half3 RTL_TEX_COL = _MainTex_var.rgb * SPECMode_Sel * _RTL_MVCOL;

				#else

					half3 RTL_TEX_COL = _MainTex_var.rgb * _MainColor.rgb * MCapOutP * _RTL_MVCOL;

				#endif
				//


                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);

                float3 lightColor = _LightColor0.rgb;

                float3 halfDirection = normalize(viewDirection+lightDirection);

                float attenuation = LIGHT_ATTENUATION(i);

				#if L_F_SON_ON

					float3 node_76 = mul( unity_WorldToObject, float4((i.posWorld.rgb-objPos.rgb),0) ).xyz.rgb.rgb;

					half RTL_SON_VCBCSON_OO = lerp( _SmoothObjectNormal, (_SmoothObjectNormal*(1.0 - i.vertexColor.r)), _VertexColorRedControlSmoothObjectNormal );
					half3 RTL_SON_ON_OTHERS = lerp(normalDirection,mul( unity_ObjectToWorld, float4(float3((_XYZPosition.r+(_XYZHardness*node_76.r)),(_XYZPosition.g+(_XYZHardness*node_76.g)),(_XYZPosition.b+(_XYZHardness*node_76.b))),0) ).xyz.rgb,RTL_SON_VCBCSON_OO);
					
					half3 RTL_SON = RTL_SON_ON_OTHERS;


					half3 RTL_SNORM_OO = lerp( 1.0, RTL_SON_ON_OTHERS, _ShowNormal );
					half3 RTL_SON_CHE_1 = RTL_SNORM_OO;

				#else

					half3 RTL_SON = normalDirection;
					half3 RTL_SON_CHE_1 = 1;

				#endif

				#if L_F_RELGI_ON

					#if L_F_UOAL_ON

						half3 RTL_UAL = UNITY_LIGHTMODEL_AMBIENT.rgb;
						half3 RTL_UOAL = RTL_UAL;

					#else

						half3 RTL_GI = AL_GI();
						half3 RTL_UOAL = RTL_GI;

					#endif

				#else

					half3 RTL_UOAL = 0;

				#endif

				#if L_F_SCT_ON

					half4 _ShadowColorTexture_var = tex2D(_ShadowColorTexture,TRANSFORM_TEX(i.uv0, _ShadowColorTexture));
					half3 RTL_SCT_ON = lerp(_ShadowColorTexture_var.rgb,(_ShadowColorTexture_var.rgb*_ShadowColorTexture_var.rgb),_ShadowColorTexturePower);

					half3 RTL_SCT = RTL_SCT_ON;

				#else

					half3 RTL_SCT = 1;

				#endif

				#if L_F_PT_ON

					half2 node_2443 = RTL_VD_CAL;
					half4 _PTexture_var = tex2D(_PTexture,TRANSFORM_TEX(RTL_VD_CAL, _PTexture));
					half RTL_PT_ON = lerp((1.0 - _PTexturePower),1.0,_PTexture_var.r);

					half RTL_PT = RTL_PT_ON;

				#else

					half RTL_PT = 1;

				#endif


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_OverallShadowColor = float4(GammaToLinearSpace(_OverallShadowColor.rgb), _OverallShadowColor.a);
				#endif

				half3 RTL_OSC = (_OverallShadowColor.rgb*_OverallShadowColorPower);
				//


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_HighlightColor = float4(GammaToLinearSpace(_HighlightColor.rgb), _HighlightColor.a);
				#endif

				half3 RTL_HL = (_HighlightColor.rgb*_HighlightColorPower+_DirectionalLightIntensity);
				//


				half RTL_LVLC = saturate( dot( lightColor.rgb , float3(0.3,0.59,0.11) ) );
				half3 RTL_MCIALO = lerp(RTL_TEX_COL , lerp(RTL_TEX_COL , _MainTex_var.rgb * MCapOutP * 0.7 , clamp((RTL_LVLC*1),0,1) ) , _MCIALO ); 

				#if L_F_GLO_ON

					#if L_F_GLOT_ON

						half3 RTL_GT_FL_Sli = lerp(viewDirection,halfDirection,_GlossTextureFollowLight);
						half3 node_2832 = reflect(RTL_GT_FL_Sli,normalDirection);
						half3 RTL_GT_FOR_OO = lerp( node_2832, mul( unity_WorldToObject, float4(node_2832,0) ).xyz.rgb, _GlossTextureFollowObjectRotation );
						half2 node_9280 = RTL_GT_FOR_OO.rg;
						half2 node_8759 = (float2((-1*node_9280.r),node_9280.g)*0.5+0.5);
						half4 _GlossTexture_var = tex2Dlod(_GlossTexture,float4(TRANSFORM_TEX( lerp(node_8759,RTL_VD_CAL,_PSGLOTEX) , _GlossTexture),0.0,_GlossTextureSoftness));
						half RTL_GT_ON = _GlossTexture_var.r;
						
						half3 RTL_GT = RTL_GT_ON;
					
					#else

						half RTL_GLO_MAIN_SOF_Sli = lerp(0.1,1.0,_GlossSoftness);
						half RTL_NDOTH = max(0,dot(halfDirection,normalDirection));
						half RTL_GLO_MAIN = smoothstep( 0.1, RTL_GLO_MAIN_SOF_Sli, pow(RTL_NDOTH,exp2(lerp(-2,15,_Glossiness))) );

						half3 RTL_GT = RTL_GLO_MAIN;

					#endif

					half4 _MaskGloss_var = tex2D(_MaskGloss,TRANSFORM_TEX(i.uv0, _MaskGloss));


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_GlossColor = float4(GammaToLinearSpace(_GlossColor.rgb), _GlossColor.a);
					#endif

					half3 RTL_GLO_MAS = lerp(RTL_HL,lerp(RTL_HL,(_GlossColor.rgb*_GlossColorPower),RTL_GT),_MaskGloss_var.r);
					//


					half3 RTL_GLO = RTL_GLO_MAS;

				#else

					half3 RTL_GLO = RTL_HL;

				#endif

				#if L_F_RL_ON

					float node_4353 = 0.0;
					float node_3687 = 0.0;


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_RimLightColor = float4(GammaToLinearSpace(_RimLightColor.rgb), _RimLightColor.a);
					#endif

					half3 RTL_RL_LARL_OO = lerp( _RimLightColor.rgb, lerp(float3(node_3687,node_3687,node_3687),_RimLightColor.rgb,lightColor.rgb), _LightAffectRimLightColor );
					//


					half RTL_RL_S_Sli = lerp(1.70,0.29,_RimLightSoftness);
					half3 RTL_RL_MAIN = lerp(float3(node_4353,node_4353,node_4353),(RTL_RL_LARL_OO*_RimLightColorPower),smoothstep( 1.71, RTL_RL_S_Sli, pow(1.0-max(0,dot(normalDirection, viewDirection)),(1.0 - _RimLightUnfill)) ));
					half3 RTL_RL_IL_OO = lerp(RTL_GLO,(RTL_GLO+RTL_RL_MAIN),_RimLightInLight);

					half3 RTL_RL_CHE_1 = RTL_RL_IL_OO;

				#else

					half3 RTL_RL_CHE_1 = RTL_GLO;

				#endif

				#if L_F_CLD_ON

					half3 RTL_CLD_CLDFOR_OO = lerp( _CustomLightDirection.rgb, mul( unity_ObjectToWorld, float4(_CustomLightDirection.rgb,0) ).xyz.rgb, _CustomLightDirectionFollowObjectRotation );
					half3 RTL_CLD_CLDI_Sli = lerp(lightDirection,RTL_CLD_CLDFOR_OO,_CustomLightDirectionIntensity);
					half3 RTL_CLD = RTL_CLD_CLDI_Sli;

				#else

					half3 RTL_CLD = lightDirection;

				#endif

				half3 RTL_ST_SS_AVD_OO = lerp( RTL_CLD, viewDirection, _SelfShadowShadowTAtViewDirection );
				half RTL_NDOTL = 0.5*dot(RTL_ST_SS_AVD_OO,RTL_SON)+0.5;
				
				#if L_F_ST_ON

					float node_4736 = 1.0;
					half4 _ShadowT_var = tex2D(_ShadowT,TRANSFORM_TEX(i.uv0, _ShadowT));
					half RTL_ST_H_Sli = lerp(0.0,0.22,_ShadowTHardness);
					half RTL_ST_LFAST_OO = lerp(lerp( RTL_NDOTL, (attenuation*RTL_NDOTL), _LightFalloffAffectShadowT ) , 1 , _STIL );


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_ShadowTColor = float4(GammaToLinearSpace(_ShadowTColor.rgb), _ShadowTColor.a);
					#endif

					half3 RTL_ST_ON = lerp(((_ShadowTColor.rgb*_ShadowTColorPower)*RTL_SCT*RTL_PT*RTL_OSC),float3(node_4736,node_4736,node_4736),smoothstep( RTL_ST_H_Sli, 0.22, ((_ShadowT_var.r*(1.0 - _ShadowTShadowThreshold))*(RTL_ST_LFAST_OO*_ShadowTLightThreshold*0.01)) ));
					//

					
					half3 RTL_ST = RTL_ST_ON;

				#else

					half3 RTL_ST = 1;

				#endif

				#if L_F_SS_ON

					half RTL_SS_SSH_Sil = lerp(0.3,1.0,_SelfShadowHardness);
					half RTL_SS_VCGVSSS_OO = lerp( _SelfShadowThreshold, (_SelfShadowThreshold*(1.0 - i.vertexColor.g)), _VertexColorGreenControlSelfShadowThreshold );
					half RTL_SS_ON = (smoothstep( RTL_SS_SSH_Sil, 1.0, (RTL_NDOTL*lerp(7,RTL_SS_VCGVSSS_OO,_SelfShadowThreshold)) )*attenuation);
					half RTL_SS = RTL_SS_ON;

				#else

					half RTL_SS = attenuation;

				#endif


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_SelfShadowRealTimeShadowColor = float4(GammaToLinearSpace(_SelfShadowRealTimeShadowColor.rgb), _SelfShadowRealTimeShadowColor.a);
				#endif

				half3 RTL_FR_OFF_OTHERS = (lerp( RTL_TEX_COL , _MainTex_var.rgb , _MCIALO) * lerp((((_SelfShadowRealTimeShadowColor.rgb*_SelfShadowRealTimeShadowColorPower)*RTL_OSC*RTL_SCT*RTL_PT)*RTL_LVLC),(RTL_RL_CHE_1*RTL_ST*RTL_SON_CHE_1*lightColor.rgb),RTL_SS));
				//


				#if L_F_FR_ON

					half2 node_8431 = reflect(viewDirection,normalDirection).rg;
					half2 node_4207 = (float2(node_8431.r,(-1*node_8431.g))*0.5+0.5);
					half4 _FReflection_var = tex2Dlod(_FReflection,float4(TRANSFORM_TEX(node_4207, _FReflection),0.0,_FReflectionRoughtness));

					half4 _MaskFReflection_var = tex2D(_MaskFReflection,TRANSFORM_TEX(i.uv0, _MaskFReflection));
					half3 RTL_FR_MET_Sli = lerp(1,(RTL_TEX_COL * 2) , _RefMetallic);
					half3 RTL_FR_MAS = lerp(RTL_FR_OFF_OTHERS, _FReflection_var.rgb * RTL_FR_MET_Sli ,_MaskFReflection_var.r);
					half3 RTL_FR_ON = lerp(RTL_FR_OFF_OTHERS,RTL_FR_MAS,_FReflectionIntensity);

					half3 RTL_FR = RTL_FR_ON;

				#else

					half3 RTL_FR = RTL_FR_OFF_OTHERS;

				#endif

				#if L_F_SL_ON

					half4 _MaskSelfLit_var = tex2D(_MaskSelfLit,TRANSFORM_TEX(i.uv0, _MaskSelfLit));


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_SelfLitColor = float4(GammaToLinearSpace(_SelfLitColor.rgb), _SelfLitColor.a);
					#endif

					half3 RTL_SL_MAS = lerp(RTL_UOAL,((_SelfLitColor.rgb*RTL_TEX_COL*lerp( 1.0, RTL_TEX_COL, _SelfLitHighContrast ))*_SelfLitPower),_MaskSelfLit_var.r);
					//


					half3 RTL_SL_ON = lerp(RTL_UOAL,RTL_SL_MAS,_SelfLitIntensity);

					half3 RTL_SL = RTL_SL_ON;

					half3 RTL_FR_SEL = lerp(RTL_FR,lerp(RTL_FR,RTL_TEX_COL*_TEXMCOLINT,_MaskSelfLit_var.r),_SelfLitIntensity);
					half3 RTL_SL_CHE_1 = RTL_FR_SEL;

				#else

					half3 RTL_SL = RTL_UOAL;
					half3 RTL_SL_CHE_1 = RTL_FR;

				#endif

				#if L_F_RL_ON

					half3 RTL_RL_ON = lerp((RTL_SL_CHE_1+RTL_RL_MAIN),RTL_SL_CHE_1,_RimLightInLight);
					half3 RTL_RL = RTL_RL_ON; 

				#else

					half3 RTL_RL = RTL_SL_CHE_1;

				#endif

				float3 emissive = (RTL_MCIALO*RTL_SL);
				float3 finalColor = emissive + RTL_RL;

                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;

            }

            ENDCG

        }

        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }

			Cull [_DoubleSided]
			Blend One One
            
			Stencil {
            	Ref[_RefVal]
            	Comp [_Compa]
            	Pass [_Oper]
            	Fail [_Oper]
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog

			#pragma multi_compile_instancing

            #pragma only_renderers d3d9 d3d11 vulkan glcore gles3 gles metal xboxone ps4 wiiu switch
            #pragma target 3.0

			#pragma shader_feature L_F_MC_ON
			#pragma shader_feature L_F_NM_ON
			#pragma shader_feature L_F_SL_ON
			#pragma shader_feature L_F_GLO_ON
			#pragma shader_feature L_F_GLOT_ON
			#pragma shader_feature L_F_SS_ON
			#pragma shader_feature L_F_SON_ON
			#pragma shader_feature L_F_SCT_ON
			#pragma shader_feature L_F_ST_ON
			#pragma shader_feature L_F_PT_ON
			#pragma shader_feature L_F_FR_ON
			#pragma shader_feature L_F_RL_ON
			#pragma shader_feature L_F_RELGI_ON
			#pragma shader_feature L_F_UOAL_ON
			#pragma shader_feature L_F_CLD_ON
			#pragma shader_feature L_F_HPSS_ON

            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform half4 _MainColor;
			uniform half _MVCOL;
			uniform fixed _MCIALO;

			uniform half4 _HighlightColor;
            uniform half _HighlightColorPower;

			uniform fixed _EnableTextureTransparent;

			#if L_F_MC_ON
				uniform half _MCapIntensity;
				uniform sampler2D _MCap; uniform float4 _MCap_ST;
				uniform half _SPECMODE;
				uniform half _SPECIN;
				uniform sampler2D _MCapMask; uniform float4 _MCapMask_ST;
			#endif

			#if L_F_NM_ON
				uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
				uniform half _NormalMapIntensity;
			#endif

			#if L_F_SL_ON
				uniform half _SelfLitIntensity;
				uniform half4 _SelfLitColor;
				uniform half _SelfLitPower;
				uniform half _TEXMCOLINT;
				uniform fixed _SelfLitHighContrast;
				uniform sampler2D _MaskSelfLit; uniform float4 _MaskSelfLit_ST;
			#endif

			#if L_F_GLO_ON
				uniform half _Glossiness;
				uniform half _GlossSoftness;
				uniform half4 _GlossColor;
				uniform half _GlossColorPower;
				uniform sampler2D _MaskGloss; uniform float4 _MaskGloss_ST;
			#endif

			#if L_F_GLO_ON
				#if L_F_GLOT_ON
					uniform sampler2D _GlossTexture; uniform float4 _GlossTexture_ST;
					uniform half _GlossTextureSoftness;
					uniform half _PSGLOTEX;
					uniform fixed _GlossTextureFollowObjectRotation;
					uniform half _GlossTextureFollowLight;
				#endif
			#endif

			uniform half4 _OverallShadowColor;
            uniform half _OverallShadowColorPower;

			uniform fixed _SelfShadowShadowTAtViewDirection;

			#if L_F_SS_ON
				uniform half _SelfShadowThreshold;
				uniform half _SelfShadowHardness;
				uniform fixed _VertexColorGreenControlSelfShadowThreshold;
			#endif

			uniform half4 _SelfShadowRealTimeShadowColor;
            uniform half _SelfShadowRealTimeShadowColorPower;

			#if L_F_SON_ON
				uniform half _SmoothObjectNormal;
				uniform fixed _VertexColorRedControlSmoothObjectNormal;
				uniform float4 _XYZPosition;
				uniform half _XYZHardness;
				uniform fixed _ShowNormal;
			#endif

			#if L_F_SCT_ON
				uniform sampler2D _ShadowColorTexture; uniform float4 _ShadowColorTexture_ST;
				uniform half _ShadowColorTexturePower;
			#endif

			#if L_F_ST_ON
				uniform sampler2D _ShadowT; uniform float4 _ShadowT_ST;
				uniform half _ShadowTLightThreshold;
				uniform half _ShadowTShadowThreshold;
				uniform half4 _ShadowTColor;
				uniform half _ShadowTColorPower;
				uniform half _ShadowTHardness;
				uniform half _STIL;
				uniform fixed _LightFalloffAffectShadowT;
			#endif
			
			#if L_F_PT_ON
			    uniform sampler2D _PTexture; uniform float4 _PTexture_ST;
				uniform half _PTexturePower;
			#endif

			uniform half _PointSpotlightIntensity;
			uniform half _LightFalloffSoftness;

			#if L_F_CLD_ON
				uniform half _CustomLightDirectionIntensity;
				uniform half4 _CustomLightDirection;
				uniform fixed _CustomLightDirectionFollowObjectRotation;
			#endif

			#if L_F_FR_ON
				uniform half _FReflectionIntensity;
				uniform sampler2D _FReflection; uniform float4 _FReflection_ST;
				uniform half _FReflectionRoughtness;
				uniform half _RefMetallic;
				uniform sampler2D _MaskFReflection; uniform float4 _MaskFReflection_ST;
			#endif
                        
			#if L_F_RL_ON
				uniform half _RimLightUnfill;
				uniform half _RimLightSoftness;
				uniform fixed _LightAffectRimLightColor;
				uniform half4 _RimLightColor;
				uniform half _RimLightColorPower;
				uniform fixed _RimLightInLight;
			#endif

			#if L_F_RELGI_ON

				half3 AL_GI()
				{
					return ShadeSH9(float4(0,0,0,1));
				}

			#endif

            struct VertexInput 
			{

                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID

            };

            struct VertexOutput 
			{

                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
				UNITY_VERTEX_OUTPUT_STEREO

            };

            VertexOutput vert (VertexInput v) 
			{

                VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_OUTPUT(VertexOutput,o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;

            }

            float4 frag(VertexOutput i) : COLOR 
			{

				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

				#if L_F_NM_ON
					half3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
					float3 normalLocal = lerp(half3(0,0,1),_NormalMap_var.rgb,_NormalMapIntensity);
				#else
					float3 normalLocal = half3(0,0,1);
				#endif

                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
				float2 sceneUVs = (i.projPos.xy / i.projPos.w);

                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform ));

				half RTL_OB_VP_CAL = distance(objPos.rgb,_WorldSpaceCameraPos);
				half2 RTL_VD_CAL = (float2((sceneUVs.x * 2 - 1)*(_ScreenParams.r/_ScreenParams.g), sceneUVs.y * 2 - 1).rg*RTL_OB_VP_CAL);

				#if L_F_MC_ON
            
					half2 MUV = (mul( UNITY_MATRIX_V, float4(normalDirection,0) ).xyz.rgb.rg*0.5+0.5);
					half4 _MatCap_var = tex2D(_MCap,TRANSFORM_TEX(MUV, _MCap));
					half4 _MCapMask_var = tex2D(_MCapMask,TRANSFORM_TEX(i.uv0, _MCapMask));
					float3 MCapOutP = lerp( lerp(1,0, _SPECMODE), lerp( lerp(1,0, _SPECMODE) ,_MatCap_var.rgb,_MCapIntensity) ,_MCapMask_var.rgb ); 
            
				#else
            
					half MCapOutP = 1;

				#endif

                half4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
				clip(lerp( 1.0, _MainTex_var.a, _EnableTextureTransparent ) - 0.5);
				half3 _RTL_MVCOL = lerp(1, i.vertexColor, _MVCOL);


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_MainColor = float4(GammaToLinearSpace(_MainColor.rgb), _MainColor.a);
				#endif

				#if L_F_MC_ON

					half3 SPECMode_Sel = lerp( (_MainColor.rgb * MCapOutP), ( _MainColor.rgb + (MCapOutP * _SPECIN) ), _SPECMODE);
					half3 RTL_TEX_COL = _MainTex_var.rgb * SPECMode_Sel * _RTL_MVCOL;

				#else

					half3 RTL_TEX_COL = _MainTex_var.rgb * _MainColor.rgb * MCapOutP * _RTL_MVCOL;

				#endif
				//


				float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
				float3 lightColor = _LightColor0.rgb;

				float3 halfDirection = normalize(viewDirection+lightDirection);

				fixed lightfo = 0;
				#ifdef POINT
					unityShadowCoord3 lightCoord = mul(unity_WorldToLight, unityShadowCoord4(i.posWorld.xyz, 1)).xyz; 
					lightfo = tex2D(_LightTexture0, dot(lightCoord, lightCoord).rr).UNITY_ATTEN_CHANNEL;
				#else
					lightfo;
				#endif
				#ifdef POINT_COOKIE
				#if !defined(UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS)
					#define DLCOO(input, worldPos) unityShadowCoord3 lightCoord = mul(unity_WorldToLight, unityShadowCoord4(worldPos, 1)).xyz
				#else
					#define DLCOO(input, worldPos) unityShadowCoord3 lightCoord = input._LightCoord
				#endif
					DLCOO(i, i.posWorld.xyz);
					lightfo = tex2D(_LightTextureB0, dot(lightCoord, lightCoord).rr).UNITY_ATTEN_CHANNEL * texCUBE(_LightTexture0, lightCoord).w;
				#else
					lightfo;
				#endif
				#ifdef SPOT
				#if !defined(UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS)
					#define DLCOO(input, worldPos) unityShadowCoord4 lightCoord = mul(unity_WorldToLight, unityShadowCoord4(worldPos, 1))
				#else
					#define DLCOO(input, worldPos) unityShadowCoord4 lightCoord = input._LightCoord
				#endif
					DLCOO(i, i.posWorld.xyz);
					lightfo = (lightCoord.z > 0) * UnitySpotCookie(lightCoord) * UnitySpotAttenuate(lightCoord);
				#else
					lightfo;
				#endif

				#if L_F_HPSS_ON
					fixed attenuation = 1; 
				#else
					fixed attenuation = SHADOW_ATTENUATION(i);
				#endif

				fixed lightfos = smoothstep(0, _LightFalloffSoftness ,lightfo);

				#if L_F_SON_ON

					float3 node_76 = mul( unity_WorldToObject, float4((i.posWorld.rgb-objPos.rgb),0) ).xyz.rgb.rgb;

					half RTL_SON_VCBCSON_OO = lerp( _SmoothObjectNormal, (_SmoothObjectNormal*(1.0 - i.vertexColor.r)), _VertexColorRedControlSmoothObjectNormal );
					half3 RTL_SON_ON_OTHERS = lerp(normalDirection,mul( unity_ObjectToWorld, float4(float3((_XYZPosition.r+(_XYZHardness*node_76.r)),(_XYZPosition.g+(_XYZHardness*node_76.g)),(_XYZPosition.b+(_XYZHardness*node_76.b))),0) ).xyz.rgb,RTL_SON_VCBCSON_OO);
					
					half3 RTL_SON = RTL_SON_ON_OTHERS;


					half3 RTL_SNORM_OO = lerp( 1.0, RTL_SON_ON_OTHERS, _ShowNormal );
					half3 RTL_SON_CHE_1 = RTL_SNORM_OO;

				#else

					half3 RTL_SON = normalDirection;
					half3 RTL_SON_CHE_1 = 1;

				#endif

				#if L_F_RELGI_ON

					#if L_F_UOAL_ON

						half3 RTL_UAL = UNITY_LIGHTMODEL_AMBIENT.rgb;
						half3 RTL_UOAL = RTL_UAL;

					#else

						half3 RTL_GI = AL_GI();
						half3 RTL_UOAL = RTL_GI;

					#endif

				#else

					half3 RTL_UOAL = 0;

				#endif

				#if L_F_SCT_ON

					half4 _ShadowColorTexture_var = tex2D(_ShadowColorTexture,TRANSFORM_TEX(i.uv0, _ShadowColorTexture));
					half3 RTL_SCT_ON = lerp(_ShadowColorTexture_var.rgb,(_ShadowColorTexture_var.rgb*_ShadowColorTexture_var.rgb),_ShadowColorTexturePower);

					half3 RTL_SCT = RTL_SCT_ON;

				#else

					half3 RTL_SCT = 1;

				#endif

				#if L_F_PT_ON

					half2 node_2443 = RTL_VD_CAL;
					half4 _PTexture_var = tex2D(_PTexture,TRANSFORM_TEX(RTL_VD_CAL, _PTexture));
					half RTL_PT_ON = lerp((1.0 - _PTexturePower),1.0,_PTexture_var.r);

					half RTL_PT = RTL_PT_ON;

				#else

					half RTL_PT = 1;

				#endif


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_OverallShadowColor = float4(GammaToLinearSpace(_OverallShadowColor.rgb), _OverallShadowColor.a);
				#endif

				half3 RTL_OSC = (_OverallShadowColor.rgb*_OverallShadowColorPower);
				//


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_HighlightColor = float4(GammaToLinearSpace(_HighlightColor.rgb), _HighlightColor.a);
				#endif

				half3 RTL_HL = (_HighlightColor.rgb*_HighlightColorPower+_PointSpotlightIntensity);
				//


				half RTL_LVLC = saturate( dot( lightColor.rgb , float3(0.3,0.59,0.11) ) );
				half3 RTL_MCIALO = lerp(RTL_TEX_COL , lerp(RTL_TEX_COL , _MainTex_var.rgb * MCapOutP * 0.7 , clamp((RTL_LVLC*1),0,1) ) , _MCIALO );

				#if L_F_GLO_ON

					#if L_F_GLOT_ON

						half3 RTL_GT_FL_Sli = lerp(viewDirection,halfDirection,_GlossTextureFollowLight);
						half3 node_2832 = reflect(RTL_GT_FL_Sli,normalDirection);
						half3 RTL_GT_FOR_OO = lerp( node_2832, mul( unity_WorldToObject, float4(node_2832,0) ).xyz.rgb, _GlossTextureFollowObjectRotation );
						half2 node_9280 = RTL_GT_FOR_OO.rg;
						half2 node_8759 = (float2((-1*node_9280.r),node_9280.g)*0.5+0.5);
						half4 _GlossTexture_var = tex2Dlod(_GlossTexture,float4(TRANSFORM_TEX( lerp(node_8759,RTL_VD_CAL,_PSGLOTEX) , _GlossTexture),0.0,_GlossTextureSoftness));
						half RTL_GT_ON = _GlossTexture_var.r;
						
						half3 RTL_GT = RTL_GT_ON;
					
					#else

						half RTL_GLO_MAIN_SOF_Sli = lerp(0.1,1.0,_GlossSoftness);
						half RTL_NDOTH = max(0,dot(halfDirection,normalDirection));
						half RTL_GLO_MAIN = smoothstep( 0.1, RTL_GLO_MAIN_SOF_Sli, pow(RTL_NDOTH,exp2(lerp(-2,15,_Glossiness))) );

						half3 RTL_GT = RTL_GLO_MAIN;

					#endif

					half4 _MaskGloss_var = tex2D(_MaskGloss,TRANSFORM_TEX(i.uv0, _MaskGloss));


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_GlossColor = float4(GammaToLinearSpace(_GlossColor.rgb), _GlossColor.a);
					#endif

					half3 RTL_GLO_MAS = lerp(RTL_HL,lerp(RTL_HL,(_GlossColor.rgb*_GlossColorPower),RTL_GT),_MaskGloss_var.r);
					//


					half3 RTL_GLO = RTL_GLO_MAS;

				#else

					half3 RTL_GLO = RTL_HL;

				#endif

				#if L_F_RL_ON

					float node_4353 = 0.0;
					float node_3687 = 0.0;


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_RimLightColor = float4(GammaToLinearSpace(_RimLightColor.rgb), _RimLightColor.a);
					#endif

					half3 RTL_RL_LARL_OO = lerp( _RimLightColor.rgb, lerp(float3(node_3687,node_3687,node_3687),_RimLightColor.rgb,lightColor.rgb), _LightAffectRimLightColor );
					//


					half RTL_RL_S_Sli = lerp(1.70,0.29,_RimLightSoftness);
					half3 RTL_RL_MAIN = lerp(float3(node_4353,node_4353,node_4353),(RTL_RL_LARL_OO*_RimLightColorPower),smoothstep( 1.71, RTL_RL_S_Sli, pow(1.0-max(0,dot(normalDirection, viewDirection)),(1.0 - _RimLightUnfill)) ));
					half3 RTL_RL_IL_OO = lerp(RTL_GLO,(RTL_GLO+RTL_RL_MAIN),_RimLightInLight);

					half3 RTL_RL_CHE_1 = RTL_RL_IL_OO;

				#else

					half3 RTL_RL_CHE_1 = RTL_GLO;

				#endif

				#if L_F_CLD_ON

					half3 RTL_CLD_CLDFOR_OO = lerp( _CustomLightDirection.rgb, mul( unity_ObjectToWorld, float4(_CustomLightDirection.rgb,0) ).xyz.rgb, _CustomLightDirectionFollowObjectRotation );
					half3 RTL_CLD_CLDI_Sli = lerp(lightDirection,RTL_CLD_CLDFOR_OO,_CustomLightDirectionIntensity);
					half3 RTL_CLD = RTL_CLD_CLDI_Sli;

				#else

					half3 RTL_CLD = lightDirection;

				#endif

				half3 RTL_ST_SS_AVD_OO = lerp( RTL_CLD, viewDirection, _SelfShadowShadowTAtViewDirection );
				half RTL_NDOTL = 0.5*dot(RTL_ST_SS_AVD_OO,RTL_SON)+0.5;
				
				#if L_F_ST_ON

					float node_4736 = 1.0;
					half4 _ShadowT_var = tex2D(_ShadowT,TRANSFORM_TEX(i.uv0, _ShadowT));
					half RTL_ST_H_Sli = lerp(0.0,0.22,_ShadowTHardness);
					half RTL_ST_LFAST_OO = lerp(lerp( RTL_NDOTL, (lightfos*RTL_NDOTL), _LightFalloffAffectShadowT ) , 1 , _STIL ); 


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_ShadowTColor = float4(GammaToLinearSpace(_ShadowTColor.rgb), _ShadowTColor.a);
					#endif

					half3 RTL_ST_ON = lerp(((_ShadowTColor.rgb*_ShadowTColorPower)*RTL_SCT*RTL_PT*RTL_OSC),float3(node_4736,node_4736,node_4736),smoothstep( RTL_ST_H_Sli, 0.22, ((_ShadowT_var.r*(1.0 - _ShadowTShadowThreshold))*(RTL_ST_LFAST_OO*_ShadowTLightThreshold*0.01)) ));
					//
					
					
					half3 RTL_ST = RTL_ST_ON;

				#else

					half3 RTL_ST = 1;

				#endif

				#if L_F_SS_ON

					half RTL_SS_SSH_Sil = lerp(0.3,1.0,_SelfShadowHardness);
					half RTL_SS_VCGVSSS_OO = lerp( _SelfShadowThreshold, (_SelfShadowThreshold*(1.0 - i.vertexColor.g)), _VertexColorGreenControlSelfShadowThreshold );
					half RTL_SS_ON = (smoothstep( RTL_SS_SSH_Sil, 1.0, (RTL_NDOTL*lerp(7,RTL_SS_VCGVSSS_OO,_SelfShadowThreshold)) )*attenuation);
					half RTL_SS = RTL_SS_ON;

				#else

					half RTL_SS = attenuation;

				#endif


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_SelfShadowRealTimeShadowColor = float4(GammaToLinearSpace(_SelfShadowRealTimeShadowColor.rgb), _SelfShadowRealTimeShadowColor.a);
				#endif

				half3 RTL_FR_OFF_OTHERS = (lerp( RTL_TEX_COL , _MainTex_var.rgb , _MCIALO) * lerp((((_SelfShadowRealTimeShadowColor.rgb*_SelfShadowRealTimeShadowColorPower)*RTL_OSC*RTL_SCT*RTL_PT)*RTL_LVLC),(RTL_RL_CHE_1*RTL_ST*RTL_SON_CHE_1*lightColor.rgb),RTL_SS));
				//


				#if L_F_FR_ON

					half2 node_8431 = reflect(viewDirection,normalDirection).rg;
					half2 node_4207 = (float2(node_8431.r,(-1*node_8431.g))*0.5+0.5);
					half4 _FReflection_var = tex2Dlod(_FReflection,float4(TRANSFORM_TEX(node_4207, _FReflection),0.0,_FReflectionRoughtness));

					half4 _MaskFReflection_var = tex2D(_MaskFReflection,TRANSFORM_TEX(i.uv0, _MaskFReflection));
					half3 RTL_FR_MET_Sli = lerp(1,(RTL_TEX_COL * 2) , _RefMetallic);
					half3 RTL_FR_MAS = lerp(RTL_FR_OFF_OTHERS, _FReflection_var.rgb * RTL_FR_MET_Sli ,_MaskFReflection_var.r);
					half3 RTL_FR_ON = lerp(RTL_FR_OFF_OTHERS,RTL_FR_MAS,_FReflectionIntensity);

					half3 RTL_FR = RTL_FR_ON;

				#else

					half3 RTL_FR = RTL_FR_OFF_OTHERS;

				#endif

				#if L_F_SL_ON

					half4 _MaskSelfLit_var = tex2D(_MaskSelfLit,TRANSFORM_TEX(i.uv0, _MaskSelfLit));


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_SelfLitColor = float4(GammaToLinearSpace(_SelfLitColor.rgb), _SelfLitColor.a);
					#endif

					half3 RTL_SL_MAS = lerp(RTL_UOAL,((_SelfLitColor.rgb*RTL_TEX_COL*lerp( 1.0, RTL_TEX_COL, _SelfLitHighContrast ))*_SelfLitPower),_MaskSelfLit_var.r);
					//


					half3 RTL_SL_ON = lerp(RTL_UOAL,RTL_SL_MAS,_SelfLitIntensity);

					half3 RTL_SL = RTL_SL_ON;

					half3 RTL_FR_SEL = lerp(RTL_FR,lerp(RTL_FR,RTL_TEX_COL*_TEXMCOLINT,_MaskSelfLit_var.r),_SelfLitIntensity);
					half3 RTL_SL_CHE_1 = RTL_FR_SEL;

				#else

					half3 RTL_SL = RTL_UOAL;
					half3 RTL_SL_CHE_1 = RTL_FR;

				#endif

				#if L_F_RL_ON

					half3 RTL_RL_ON = lerp((RTL_SL_CHE_1+RTL_RL_MAIN),RTL_SL_CHE_1,_RimLightInLight);
					half3 RTL_RL = RTL_RL_ON; 

				#else

					half3 RTL_RL = RTL_SL_CHE_1;

				#endif

				float3 emissive = (RTL_MCIALO*RTL_RL) * lightfos;
				float3 finalColor = (emissive);

                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;

            }

            ENDCG

        }

        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull [_DoubleSided]

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog

			#pragma multi_compile_instancing

            #pragma only_renderers d3d9 d3d11 vulkan glcore gles3 gles metal xboxone ps4 wiiu switch
            #pragma target 3.0

            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform fixed _EnableTextureTransparent;

            struct VertexInput 
			{

                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID

            };

            struct VertexOutput 
			{

                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
				UNITY_VERTEX_OUTPUT_STEREO

            };

            VertexOutput vert (VertexInput v) 
			{

                VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_OUTPUT(VertexOutput,o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                o.uv0 = v.texcoord0;

                o.pos = UnityObjectToClipPos( v.vertex );
				TRANSFER_SHADOW_CASTER(o)
                return o;

            }

            float4 frag(VertexOutput i) : COLOR 
			{

				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

                half4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(lerp( 1.0, _MainTex_var.a, _EnableTextureTransparent ) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)

            }

            ENDCG

        }

    }

	CustomEditor "RealToon.GUIInspector.RealToonShaderGUI_Lite"

}