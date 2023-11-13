//RealToon V5.0.8
//MJQStudioWorks
//2020

Shader "RealToon/Version 5/Tessellation/Refraction" {
    Properties {

		[Enum(Off,2,On,0)] _DoubleSided("Double Sided", int) = 2

        _RefractionIntensity ("Refraction Intensity", Range(0, 1)) = 1

        [HDR] _MainColor ("Main Color", Color) = (0.6886792,0.6886792,0.6886792,1)
        [Toggle(NOKEWO)] _MainColorAffectTexture ("Main Color Affect Texture", Float ) = 0

		[HDR] _HighlightColor ("Highlight Color", Color) = (1,1,1,1)
        _HighlightColorPower ("Highlight Color Power", Float ) = 1

        _TextureIntesnity ("Texture Intesnity", Range(0, 1)) = 0
        _MainTex ("Texture", 2D) = "white" {}
        [Toggle(NOKEWO)] _TexturePatternStyle ("Texture Pattern Style", Float ) = 0

		_MCapIntensity ("Intensity", Range(0, 1)) = 1
		_MCap ("MatCap", 2D) = "white" {}
		[Toggle(NOKEWO)] _SPECMODE ("Specular Mode", Float ) = 0
		_SPECIN ("Specular Power", Float ) = 1
		_MCapMask ("Mask MatCap", 2D) = "white" {}

        _NormalMap ("Normal Map", 2D) = "bump" {}
        _NormalMapIntensity ("Normal Map Intensity", Float ) = 1

        _Saturation ("Saturation", Range(0, 2)) = 1

        _SelfLitIntensity ("Intensity", Range(0, 1)) = 0
        [HDR] _SelfLitColor ("Color", Color) = (1,1,1,1)
        _SelfLitPower ("Power", Float ) = 2
		_TEXMCOLINT ("Texture and Main Color Intensity", Float ) = 1
        [Toggle(NOKEWO)] _SelfLitHighContrast ("High Contrast", Float ) = 1
        _MaskSelfLit ("Mask Self Lit", 2D) = "white" {}

        _GlossIntensity ("Intensity", Range(0, 1)) = 1
        _Glossiness ("Glossiness", Range(0, 1)) = 0.6
        _GlossSoftness ("Softness", Range(0, 1)) = 0
        [HDR] _GlossColor ("Color", Color) = (1,1,1,1)
        _GlossColorPower ("Color Power", Float ) = 10
        _MaskGloss ("Mask Gloss", 2D) = "white" {}

        _GlossTexture ("Gloss Texture", 2D) = "black" {}
        _GlossTextureSoftness ("Softness", Float ) = 0
		[Toggle(NOKEWO)] _PSGLOTEX ("Pattern Style", Float ) = 0
        _GlossTextureRotate ("Rotate", Float ) = 0
        [Toggle(NOKEWO)] _GlossTextureFollowObjectRotation ("Follow Object Rotation", Float ) = 0
        _GlossTextureFollowLight ("Follow Light", Range(0, 1)) = 0

        [HDR] _OverallShadowColor ("Overall Shadow Color", Color) = (0,0,0,1)
        _OverallShadowColorPower ("Overall Shadow Color Power", Float ) = 1

        [Toggle(NOKEWO)] _SelfShadowShadowTAtViewDirection ("Self Shadow & ShadowT At View Direction", Float ) = 0

        _SelfShadowIntensity ("Self Shadow Intensity", Range(0, 1)) = 1
        _SelfShadowThreshold ("Threshold", Range(0, 1)) = 0.85
        [Toggle(NOKEWO)] _VertexColorGreenControlSelfShadowThreshold ("Vertex Color Green Control Self Shadow Threshold", Float ) = 0
        _SelfShadowHardness ("Hardness", Range(0, 1)) = 1
        [HDR] _SelfShadowColor ("Color", Color) = (1,1,1,1)
        _SelfShadowColorPower ("Color Power", Float ) = 1
        [Toggle(NOKEWO)] _SelfShadowAffectedByLightShadowStrength ("Self Shadow Affected By Light Shadow Strength", Float ) = 0

        _SmoothObjectNormal ("Smooth Object Normal", Range(0, 1)) = 0
        [Toggle(NOKEWO)] _VertexColorRedControlSmoothObjectNormal ("Vertex Color Red Control Smooth Object Normal", Float ) = 0
        _XYZPosition ("XYZ Position", Vector) = (0,0,0,0)
        _XYZHardness ("XYZ Hardness", Float ) = 14
        [Toggle(NOKEWO)] _ShowNormal ("Show Normal", Float ) = 0

        _ShadowColorTexture ("Shadow Color Texture", 2D) = "white" {}
        _ShadowColorTexturePower ("Power", Float ) = 0

        _ShadowTIntensity ("ShadowT Intensity", Range(0, 1)) = 1
        _ShadowT ("ShadowT", 2D) = "white" {}
        _ShadowTLightThreshold ("Light Threshold", Float ) = 50
        _ShadowTShadowThreshold ("Shadow Threshold", Float ) = 0
        [HDR] _ShadowTColor ("Color", Color) = (1,1,1,1)
        _ShadowTColorPower ("Color Power", Float ) = 1
        _ShadowTHardness ("Hardness", Range(0, 1)) = 1

		[Toggle(NOKEWO)] _STIL ("Ignore Light", Float ) = 0

		[Toggle(N_F_STIS_ON)] _N_F_STIS ("Show In Shadow", Float ) = 0
		[Toggle(N_F_STIAL_ON)] _N_F_STIAL ("Show In Ambient Light", Float ) = 0

        _ShowInAmbientLightShadowIntensity ("Show In Ambient Light & Shadow Intensity", Range(0, 1)) = 1
        _ShowInAmbientLightShadowThreshold ("Show In Ambient Light & Shadow Threshold", Float ) = 0.4

        [Toggle(NOKEWO)] _LightFalloffAffectShadowT ("Light Falloff Affect ShadowT", Float ) = 0

        _PTexture ("PTexture", 2D) = "white" {}
        _PTexturePower ("Power", Float ) = 1

		[Toggle(N_F_RELGI_ON)] _RELG ("Receive Environmental Lighting and GI", Float ) = 1
        _EnvironmentalLightingIntensity ("Environmental Lighting Intensity", Float ) = 1

        [Toggle(NOKEWO)] _GIFlatShade ("GI Flat Shade", Float ) = 0
        _GIShadeThreshold ("GI Shade Threshold", Range(0, 1)) = 0

        [Toggle(NOKEWO)] _LightAffectShadow ("Light Affect Shadow", Float ) = 0
        _LightIntensity ("Light Intensity", Float ) = -1

		_DirectionalLightIntensity ("Directional Light Intensity", Float ) = 0
		_PointSpotlightIntensity ("Point and Spot Light Intensity", Float ) = 0.45
		_LightFalloffSoftness ("Light Falloff Softness", Range(0, 1)) = 1

        _CustomLightDirectionIntensity ("Intensity", Range(0, 1)) = 0
        _CustomLightDirection ("Custom Light Direction", Vector) = (0,0,10,0)
        [Toggle(NOKEWO)] _CustomLightDirectionFollowObjectRotation ("Follow Object Rotation", Float ) = 0

        _ReflectionIntensity ("Intensity", Range(0, 1)) = 0
        _ReflectionRoughtness ("Roughtness", Float ) = 0
        _MaskReflection ("Mask Reflection", 2D) = "white" {}
        _FReflection ("FReflection", 2D) = "black" {}

        _RimLightUnfill ("Unfill", Float ) = 1.5
        [HDR] _RimLightColor ("Color", Color) = (1,1,1,1)
        _RimLightColorPower ("Color Power", Float ) = 10
        _RimLightSoftness ("Softness", Range(0, 1)) = 1
        [Toggle(NOKEWO)] _RimLightInLight ("Rim Light In Light", Float ) = 1
        [Toggle(NOKEWO)] _LightAffectRimLightColor ("Light Affect Rim Light Color", Float ) = 0

        _Depth ("Depth", Float ) = 0.2
        _DepthEdgeHardness ("Edge Hardness", Range(0, 1)) = 0.1
        [HDR] _DepthColor ("Color", Color) = (0.5,0.5,0.5,1)
        _DepthColorPower ("Color Power", Float ) = 1.8

		_TessellationSmoothness ("Smoothness", Range(0, 1)) = 0.5
        _TessellationTransition ("Tessellation Transition", Range(0, 1)) = 0.8
        _TessellationNear ("Tessellation Near", Float ) = 1
        _TessellationFar ("Tessellation Far", Float ) = 1

		_RefVal ("ID", int ) = 0
        [Enum(Blank,8,A,0,B,2)] _Oper("Set 1", int) = 0
        [Enum(Blank,8,None,4,A,6,B,7)] _Compa("Set 2", int) = 4

		[Toggle(N_F_MC_ON)] _N_F_MC ("MatCap", Float ) = 0
		[Toggle(N_F_NM_ON)] _N_F_NM ("Normal Map", Float ) = 0
		[Toggle(N_F_CA_ON)] _N_F_CA ("Color Adjustment", Float ) = 0
		[Toggle(N_F_SL_ON)] _N_F_SL ("Self Lit", Float ) = 0
		[Toggle(N_F_GLO_ON)] _N_F_GLO ("Gloss", Float ) = 0
		[Toggle(N_F_GLOT_ON)] _N_F_GLOT ("Gloss Texture", Float ) = 0
		[Toggle(N_F_SS_ON)] _N_F_SS ("Self Shadow", Float ) = 0
		[Toggle(N_F_SON_ON)] _N_F_SON ("Smooth Object Normal", Float ) = 0
		[Toggle(N_F_SCT_ON)] _N_F_SCT ("Shadow Color Texture", Float ) = 0
		[Toggle(N_F_ST_ON)] _N_F_ST ("ShadowT", Float ) = 0
		[Toggle(N_F_PT_ON)] _N_F_PT ("PTexture", Float ) = 0
		[Toggle(N_F_CLD_ON)] _N_F_CLD ("Custom Light Direction", Float ) = 0
		[Toggle(N_F_R_ON)] _N_F_R ("Reflection", Float ) = 0
		[Toggle(N_F_FR_ON)] _N_F_FR ("FReflection", Float ) = 0
		[Toggle(N_F_RL_ON)] _N_F_RL ("Rim Light", Float ) = 0
		[Toggle(N_F_D_ON)] _N_F_D ("Depth", Float ) = 0
		[Enum(On,1,Off,0)] _ZWrite("ZWrite", int) = 1

		[Toggle(N_F_NLASOBF_ON)] _N_F_NLASOBF ("No Light On BackFace", Float ) = 0


    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
			

			Stencil {
            	Ref[_RefVal]
            	Comp [_Compa]
            	Pass [_Oper]
            	Fail [_Oper]
            }
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
			#include "Tessellation.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog

            #pragma only_renderers d3d9 d3d11 glcore gles3 metal xboxone ps4 wiiu 
            #pragma target 5.0

			#pragma shader_feature N_F_MC_ON
			#pragma shader_feature N_F_NM_ON
			#pragma shader_feature N_F_CA_ON
			#pragma shader_feature N_F_SL_ON
			#pragma shader_feature N_F_GLO_ON
			#pragma shader_feature N_F_GLOT_ON
			#pragma shader_feature N_F_SS_ON
			#pragma shader_feature N_F_SCT_ON
			#pragma shader_feature N_F_ST_ON
			#pragma shader_feature N_F_STIS_ON
			#pragma shader_feature N_F_STIAL_ON 
			#pragma shader_feature N_F_SON_ON
			#pragma shader_feature N_F_PT_ON
			#pragma shader_feature N_F_RELGI_ON
			#pragma shader_feature N_F_CLD_ON
			#pragma shader_feature N_F_R_ON
			#pragma shader_feature N_F_FR_ON
			#pragma shader_feature N_F_RL_ON
			#pragma shader_feature N_F_D_ON
			#pragma shader_feature N_F_NLASOBF_ON

			uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;

			uniform half _RefractionIntensity;
            uniform half4 _MainColor;
			uniform fixed _MainColorAffectTexture;
			uniform half4 _HighlightColor;
			uniform half _HighlightColorPower;
			uniform half _TextureIntesnity;
			uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
			uniform fixed _TexturePatternStyle;

			#if N_F_MC_ON
				uniform half _MCapIntensity;
				uniform sampler2D _MCap; uniform float4 _MCap_ST;
				uniform half _SPECMODE;
				uniform half _SPECIN;
				uniform sampler2D _MCapMask; uniform float4 _MCapMask_ST;
			#endif

			#if N_F_NM_ON
				uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
				uniform half _NormalMapIntensity;
			#endif

			#if N_F_CA_ON
				uniform half _Saturation;
			#endif

			#if N_F_SL_ON
				uniform half _SelfLitIntensity;
				uniform half4 _SelfLitColor;
				uniform half _SelfLitPower;
				uniform half _TEXMCOLINT;
				uniform fixed _SelfLitHighContrast;
				uniform sampler2D _MaskSelfLit; uniform float4 _MaskSelfLit_ST;
			#endif

			#if N_F_GLO_ON
				uniform half _GlossIntensity;
				uniform half _Glossiness;
				uniform half _GlossSoftness;
				uniform half4 _GlossColor;
				uniform half _GlossColorPower;
				uniform sampler2D _MaskGloss; uniform float4 _MaskGloss_ST;
			#endif
			
			#if N_F_GLO_ON
				#if N_F_GLOT_ON
					uniform sampler2D _GlossTexture; uniform float4 _GlossTexture_ST;
					uniform half _GlossTextureSoftness;
					uniform half _PSGLOTEX;
					uniform half _GlossTextureRotate;
					uniform fixed _GlossTextureFollowObjectRotation;
					uniform half _GlossTextureFollowLight;
				#endif
			#endif

			uniform half4 _OverallShadowColor;
            uniform half _OverallShadowColorPower;

			uniform fixed _SelfShadowShadowTAtViewDirection;

			#if N_F_SS_ON
				uniform half _SelfShadowThreshold;
				uniform fixed _VertexColorGreenControlSelfShadowThreshold;
				uniform half _SelfShadowHardness;
				uniform fixed _SelfShadowAffectedByLightShadowStrength;
			#endif

			uniform half _SelfShadowIntensity;
			uniform half4 _SelfShadowColor;
			uniform half _SelfShadowColorPower;

			#if N_F_SON_ON
				uniform half _SmoothObjectNormal;
				uniform fixed _VertexColorRedControlSmoothObjectNormal;
				uniform float4 _XYZPosition;
				uniform half _XYZHardness;
				uniform fixed _ShowNormal;
			#endif

			#if N_F_SCT_ON
				uniform sampler2D _ShadowColorTexture; uniform float4 _ShadowColorTexture_ST;
				uniform half _ShadowColorTexturePower;
			#endif

			#if N_F_ST_ON
				uniform half _ShadowTIntensity;
				uniform sampler2D _ShadowT; uniform float4 _ShadowT_ST;
				uniform half _ShadowTLightThreshold;
				uniform half _ShadowTShadowThreshold;
				uniform half4 _ShadowTColor;
				uniform half _ShadowTColorPower;
				uniform half _ShadowTHardness;
				uniform half _STIL;
				uniform half _ShowInAmbientLightShadowIntensity;
				uniform half _ShowInAmbientLightShadowThreshold;
				uniform fixed _LightFalloffAffectShadowT;
			#endif

			#if N_F_PT_ON
				uniform sampler2D _PTexture; uniform float4 _PTexture_ST;
				uniform half _PTexturePower;
			#endif

			#if N_F_RELGI_ON
				uniform fixed _GIFlatShade;
				uniform half _GIShadeThreshold;
				uniform half _EnvironmentalLightingIntensity;
			#endif

			uniform fixed _LightAffectShadow;
			uniform half _LightIntensity;
			uniform half _DirectionalLightIntensity;

			#if N_F_CLD_ON
				uniform half _CustomLightDirectionIntensity;
				uniform half4 _CustomLightDirection;
				uniform fixed _CustomLightDirectionFollowObjectRotation;
			#endif

			#if N_F_R_ON
				uniform half _ReflectionIntensity;
				uniform half _ReflectionRoughtness;
				uniform half _RefMetallic;
				uniform sampler2D _MaskReflection; uniform float4 _MaskReflection_ST;
			#endif

			#if N_F_R_ON
				#if N_F_FR_ON
					uniform sampler2D _FReflection; uniform float4 _FReflection_ST;
				#endif
			#endif

			#if N_F_RL_ON
				uniform half _RimLightUnfill;
				uniform half _RimLightSoftness;	
				uniform fixed _LightAffectRimLightColor;
				uniform half4 _RimLightColor;
				uniform half _RimLightColorPower;
				uniform fixed _RimLightInLight;
			#endif
			            
			uniform half _Depth;
            uniform half _DepthEdgeHardness;
            uniform half4 _DepthColor;
            uniform half _DepthColorPower;
		
			uniform float _TessellationSmoothness;
			uniform half _TessellationTransition;
			uniform half _TessellationNear;
			uniform half _TessellationFar;

            half3 AL_GI( float3 N )
			{
				return ShadeSH9(float4(N,1));
            }

			#if N_F_R_ON

				float3 Ref( half3 VR , half Mip )
				{
					float4 skyData = UNITY_SAMPLE_TEXCUBE_LOD(unity_SpecCube0, VR, Mip);
					return DecodeHDR (skyData, unity_SpecCube0_HDR);
				}

			#endif

            fixed C_SS()
			{
				return _LightShadowData.x;
            }
            
            struct VertexInput 
			{

                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;

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
                UNITY_FOG_COORDS(6)

            };

            VertexOutput vert (VertexInput v) 
			{

                VertexOutput o = (VertexOutput)0;

                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;

            }

            #ifdef UNITY_CAN_COMPILE_TESSELLATION

                struct TessVertex 
				{

                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                    float4 vertexColor : COLOR;

                };

                struct OutputPatchConstant 
				{

                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;

                };

                TessVertex tessvert (VertexInput v) 
				{

                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    o.vertexColor = v.vertexColor;
                    return o;

                }

                float Tessellation(TessVertex v)
				{

                    half RTD_TES_TRANS_Sli = (1.0 - _TessellationTransition);
                    half RTD_TES = lerp(_TessellationNear,_TessellationFar,saturate((distance(mul(unity_ObjectToWorld, v.vertex).rgb,_WorldSpaceCameraPos)*RTD_TES_TRANS_Sli)));
                    return RTD_TES;

                }

                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2)
				{

                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);

                }

                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) 
				{

                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;

                }

                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]

                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) 
				{
                    return v[id];
                }

                [domain("tri")]

                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) 
				{

                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;

					float3 pp[3];
					for (int i = 0; i < 3; ++i)
					pp[i] = v.vertex.xyz - vi[i].normal * (dot(v.vertex.xyz, vi[i].normal) - dot(vi[i].vertex.xyz, vi[i].normal));
					v.vertex.xyz = _TessellationSmoothness * (pp[0] * bary.x + pp[1] * bary.y + pp[2] * bary.z) + (1.0f - _TessellationSmoothness) * v.vertex.xyz;

                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    v.vertexColor = vi[0].vertexColor*bary.x + vi[1].vertexColor*bary.y + vi[2].vertexColor*bary.z;
                    VertexOutput o = vert(v);
                    return o;

                }

            #endif

            float4 frag(VertexOutput i, float facing : VFACE) : COLOR 
			{

			     #if N_F_NM_ON
					half3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
					float3 normalLocal = lerp(half3(0,0,1),_NormalMap_var.rgb,_NormalMapIntensity);
				#else
					float3 normalLocal = half3(0,0,1);
				#endif

				half isFrontFace = ( facing >= 0 ? 1 : 0 );
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
				float2 sceneUVs = (i.projPos.xy / i.projPos.w);

                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform ));
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );

				half RTD_OB_VP_CAL = distance(objPos.rgb,_WorldSpaceCameraPos);
				half2 RTD_VD_Cal = (float2((sceneUVs.x * 2 - 1)*(_ScreenParams.r/_ScreenParams.g), sceneUVs.y * 2 - 1).rg*RTD_OB_VP_CAL);

                half2 RTD_TCR_TP_OO = lerp( i.uv0, RTD_VD_Cal, _TexturePatternStyle );
				half2 node_9073 = RTD_TCR_TP_OO;

				#if N_F_MC_ON
            
					half2 MUV = (mul( UNITY_MATRIX_V, float4(normalDirection,0) ).xyz.rgb.rg*0.5+0.5);
					half4 _MatCap_var = tex2D(_MCap,TRANSFORM_TEX(MUV, _MCap));
					half4 _MCapMask_var = tex2D(_MCapMask,TRANSFORM_TEX(i.uv0, _MCapMask)); 
					float3 MCapOutP = lerp( lerp(1,0, _SPECMODE), lerp( lerp(1,0, _SPECMODE) ,_MatCap_var.rgb,_MCapIntensity) ,_MCapMask_var.rgb );
            
				#else
            
					half MCapOutP = 1;

				#endif

                half4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_9073, _MainTex)); 
				
				
				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_MainColor = float4(GammaToLinearSpace(_MainColor.rgb), _MainColor.a);
				#endif

                half3 node_7067 = (tex2D( _GrabTexture, lerp(sceneUVs.rg,reflect(float3(sceneUVs.rg,0.0),normalDirection).rg,lerp(0.0,(-0.2),_RefractionIntensity))).rgb*_MainColor.rgb);
				//


				half3 ref_tex = lerp(node_7067,lerp(node_7067,lerp( _MainTex_var.rgb, (_MainTex_var.rgb*_MainColor.rgb), _MainColorAffectTexture ),_MainTex_var.a),_TextureIntesnity);

				#if N_F_MC_ON

					half3 SPECMode_Sel = lerp( (ref_tex* MCapOutP), ( ref_tex + (MCapOutP * _SPECIN) ), _SPECMODE);

					half3 RTD_TEX_COL_REF = SPECMode_Sel;

				#else

					half3 RTD_TEX_COL_REF = ref_tex * MCapOutP;

				#endif

                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);

                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);

                #if N_F_NLASOBF_ON
					float3 lightColor = lerp(0,_LightColor0.rgb,isFrontFace);
				#else
					float3 lightColor = _LightColor0.rgb;
				#endif

                float3 halfDirection = normalize(viewDirection+lightDirection);
                float attenuation = 1;

				#if N_F_SON_ON

					float3 node_76 = mul( unity_WorldToObject, float4((i.posWorld.rgb-objPos.rgb),0) ).xyz.rgb.rgb;
					half RTD_SON_VCBSON_OO = lerp( _SmoothObjectNormal, (_SmoothObjectNormal*(1.0 - i.vertexColor.r)), _VertexColorRedControlSmoothObjectNormal );
					half3 RTD_SON_ON_OTHERS = lerp(normalDirection,mul( unity_ObjectToWorld, float4(float3((_XYZPosition.r+(_XYZHardness*node_76.r)),(_XYZPosition.g+(_XYZHardness*node_76.g)),(_XYZPosition.b+(_XYZHardness*node_76.b))),0) ).xyz.rgb,RTD_SON_VCBSON_OO);
				
					half3 RTD_SON = RTD_SON_ON_OTHERS;

					half3 RTD_SNorm_OO = lerp( 1.0, RTD_SON_ON_OTHERS, _ShowNormal );
					half3 RTD_SON_CHE_1 = RTD_SNorm_OO;

				#else
					
					half3 RTD_SON = normalDirection;
					half3 RTD_SON_CHE_1 = 1;

				#endif

				#if N_F_RELGI_ON

					half3 RTD_GI_ST_Sli = (RTD_SON*_GIShadeThreshold);

					float node_2183 = 0;
					float node_8383 = 0.01;

					half3 RTD_GI_FS_OO = lerp( RTD_GI_ST_Sli, float3(smoothstep( float2(node_2183,node_2183), float2(node_8383,node_8383), (RTD_SON.rb*_GIShadeThreshold) ),0.0), _GIFlatShade );

				#else

					half3 RTD_GI_FS_OO = RTD_SON;

				#endif

				#if N_F_SCT_ON

					half4 _ShadowColorTexture_var = tex2D(_ShadowColorTexture,TRANSFORM_TEX(i.uv0, _ShadowColorTexture));
					half3 RTD_SCT_ON = lerp(_ShadowColorTexture_var.rgb,(_ShadowColorTexture_var.rgb*_ShadowColorTexture_var.rgb),_ShadowColorTexturePower);

					half3 RTD_SCT = RTD_SCT_ON;

				#else

					half3 RTD_SCT = 1;

				#endif

				#if N_F_PT_ON

					float2 node_405 = RTD_VD_Cal;
					half4 _PTexture_var = tex2D(_PTexture,TRANSFORM_TEX(node_405, _PTexture));
					half RTD_PT_ON = lerp((1.0 - _PTexturePower),1.0,_PTexture_var.r);

					half RTD_PT = RTD_PT_ON;

				#else

					half RTD_PT = 1;

				#endif


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_OverallShadowColor = float4(GammaToLinearSpace(_OverallShadowColor.rgb), _OverallShadowColor.a);
				#endif

				half3 RTD_OSC = (_OverallShadowColor.rgb*_OverallShadowColorPower);
				//


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_SelfShadowColor = float4(GammaToLinearSpace(_SelfShadowColor.rgb), _SelfShadowColor.a);
				#endif

				half3 node_1860 = ((_SelfShadowColor.rgb*_SelfShadowColorPower)*RTD_OSC*RTD_SCT*RTD_PT);
				//


                half3 node_6694 = (_LightIntensity+lightColor.rgb);

				half3 RTD_LAS = lerp(node_1860,(node_1860+node_6694),_LightAffectShadow);


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_HighlightColor = float4(GammaToLinearSpace(_HighlightColor.rgb), _HighlightColor.a);
				#endif

				half3 RTD_HL = (_HighlightColor.rgb*_HighlightColorPower+_DirectionalLightIntensity);
				//


                float4 node_6613_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_6613_p = lerp(float4(float4(lightColor.rgb,0.0).zy, node_6613_k.wz), float4(float4(lightColor.rgb,0.0).yz, node_6613_k.xy), step(float4(lightColor.rgb,0.0).z, float4(lightColor.rgb,0.0).y));
                float4 node_6613_q = lerp(float4(node_6613_p.xyw, float4(lightColor.rgb,0.0).x), float4(float4(lightColor.rgb,0.0).x, node_6613_p.yzx), step(node_6613_p.x, float4(lightColor.rgb,0.0).x));
                float node_6613_d = node_6613_q.x - min(node_6613_q.w, node_6613_q.y);
                float node_6613_e = 1.0e-10;
                half3 node_6613 = float3(abs(node_6613_q.z + (node_6613_q.w - node_6613_q.y) / (6.0 * node_6613_d + node_6613_e)), node_6613_d / (node_6613_q.x + node_6613_e), node_6613_q.x);

				half RTD_LVLC = saturate(node_6613.b);

				#if N_F_GLO_ON

					#if N_F_GLOT_ON

						float node_5992_ang = _GlossTextureRotate;
						float node_5992_spd = 1.0;
						float node_5992_cos = cos(node_5992_spd*node_5992_ang);
						float node_5992_sin = sin(node_5992_spd*node_5992_ang);
						float2 node_5992_piv = float2(0.5,0.5);

						half3 RTD_GT_FL_Sli = lerp(viewDirection,halfDirection,_GlossTextureFollowLight);
						half3 node_2832 = reflect(RTD_GT_FL_Sli,normalDirection);

						half3 RTD_GT_FOR_OO = lerp( node_2832, mul( unity_WorldToObject, float4(node_2832,0) ).xyz.rgb, _GlossTextureFollowObjectRotation );
						half2 node_9280 = RTD_GT_FOR_OO.rg;

						half2 node_5992 = (mul(float2((-1*node_9280.r),node_9280.g)-node_5992_piv,float2x2( node_5992_cos, -node_5992_sin, node_5992_sin, node_5992_cos))+node_5992_piv); 
						half2 node_8759 = (node_5992*0.5+0.5); 

						half4 _GlossTexture_var = tex2Dlod(_GlossTexture,float4(TRANSFORM_TEX( lerp(node_8759,RTD_VD_Cal,_PSGLOTEX) , _GlossTexture),0.0,_GlossTextureSoftness));
						half RTD_GT_ON = _GlossTexture_var.r;

						half3 RTD_GT = RTD_GT_ON;

					#else

						half RTD_GLO_MAIN_Sof_Sil = lerp(0.1,1.0,_GlossSoftness);
						half RTD_NDOTH = max(0,dot(halfDirection,normalDirection));
						half RTD_GLO_MAIN = smoothstep( 0.1, RTD_GLO_MAIN_Sof_Sil, pow(RTD_NDOTH,exp2(lerp(-2,15,_Glossiness))) );

						half3 RTD_GT = RTD_GLO_MAIN;

					#endif

					float node_9345 = 0.0;
					half3 RTD_GLO_I_Sil = lerp(float3(node_9345,node_9345,node_9345),RTD_GT,_GlossIntensity);
					half4 _MaskGloss_var = tex2D(_MaskGloss,TRANSFORM_TEX(i.uv0, _MaskGloss));
					half3 RTD_GLO_MAS = lerp(RTD_HL,lerp(RTD_HL,(_GlossColor.rgb*_GlossColorPower),RTD_GLO_I_Sil),_MaskGloss_var.r);

					half3 RTD_GLO = RTD_GLO_MAS;

				#else

					half3 RTD_GLO = RTD_HL;

				#endif

				#if N_F_RL_ON

					float node_4353 = 0.0;
					float node_3687 = 0.0;


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_RimLightColor = float4(GammaToLinearSpace(_RimLightColor.rgb), _RimLightColor.a);
					#endif

					half3 RTD_RL_LARL_OO = lerp( _RimLightColor.rgb, lerp(float3(node_3687,node_3687,node_3687),_RimLightColor.rgb,lightColor.rgb), _LightAffectRimLightColor );
					//


					half RTD_RL_S_Sli = lerp(1.7,0.29,_RimLightSoftness);
					half3 RTD_RL_MAIN = lerp(float3(node_4353,node_4353,node_4353),(RTD_RL_LARL_OO*_RimLightColorPower),smoothstep( 1.71, RTD_RL_S_Sli, pow(1.0-max(0,dot(normalDirection, viewDirection)),(1.0 - _RimLightUnfill)) ));
					half3 RTD_RL_IL_OO = lerp(RTD_GLO,(RTD_GLO+RTD_RL_MAIN),_RimLightInLight);

					half3 RTD_RL_CHE_1 = RTD_RL_IL_OO;

				#else

					half3 RTD_RL_CHE_1 = RTD_GLO;

				#endif

				#if N_F_CLD_ON

					half3 RTD_CLD_CLDFOR_OO = lerp( _CustomLightDirection.rgb, mul( unity_ObjectToWorld, float4(_CustomLightDirection.rgb,0) ).xyz.rgb, _CustomLightDirectionFollowObjectRotation );
					half3 RTD_CLD_CLDI_Sli = lerp(lightDirection,RTD_CLD_CLDFOR_OO,_CustomLightDirectionIntensity);
					half3 RTD_CLD = RTD_CLD_CLDI_Sli;

				#else

					half3 RTD_CLD = lightDirection;

				#endif

				half3 RTD_ST_SS_AVD_OO = lerp( RTD_CLD, viewDirection, _SelfShadowShadowTAtViewDirection );
				half RTD_NDOTL = 0.5*dot(RTD_ST_SS_AVD_OO,RTD_SON)+0.5;

				half3 RTD_ST_OFF_OTHERS = (RTD_RL_CHE_1*RTD_SON_CHE_1*lightColor.rgb);

				#if N_F_ST_ON

					float node_208 = 1.0; 
					half node_4736 = 1.0;
					float node_7419 = 1.0; 
					half node_3187 = 0.22; 

					half4 _ShadowT_var = tex2D(_ShadowT,TRANSFORM_TEX(i.uv0, _ShadowT)); 


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_ShadowTColor = float4(GammaToLinearSpace(_ShadowTColor.rgb), _ShadowTColor.a);
					#endif

					half3 node_338 = ((_ShadowTColor.rgb*_ShadowTColorPower)*RTD_SCT*RTD_PT*RTD_OSC);
					//


					half RTD_ST_H_Sli = lerp(0.0,0.22,_ShadowTHardness);
					half3 RTD_ST_IS_ON = lerp(float3(node_4736,node_4736,node_4736),lerp(node_338,float3(node_7419,node_7419,node_7419),smoothstep( RTD_ST_H_Sli, node_3187, (_ShowInAmbientLightShadowThreshold*_ShadowT_var.r) )),_ShadowTIntensity);

					#if N_F_STIAL_ON

						float node_932 = 1.0;
						half3 RTD_ST_ALI_Sli = lerp(float3(node_932,node_932,node_932),RTD_ST_IS_ON,_ShowInAmbientLightShadowIntensity);
						half3 RTD_STIAL_ON = lerp(RTD_ST_ALI_Sli,float3(node_208,node_208,node_208),clamp((RTD_LVLC*8.0),0,1));

						half3 RTD_STIAL = RTD_STIAL_ON;

					#else

						half3 RTD_STIAL = 1;

					#endif

					#if N_F_STIS_ON

						half3 RTD_ST_IS = lerp(1,RTD_ST_IS_ON,_ShowInAmbientLightShadowIntensity);

					#else

						half3 RTD_ST_IS = 1;

					#endif

					half RTD_ST_LFAST_OO = lerp(lerp( RTD_NDOTL, (attenuation*RTD_NDOTL), _LightFalloffAffectShadowT ) , 1 , _STIL );
					half RTD_ST_In_Sli = lerp(node_4736,smoothstep( RTD_ST_H_Sli, node_3187, ((_ShadowT_var.r*(1.0 - _ShadowTShadowThreshold))*(RTD_ST_LFAST_OO*_ShadowTLightThreshold)*0.01) ),_ShadowTIntensity);
					half3 RTD_ST_ON = lerp((lerp(node_338,(node_338+node_6694),_LightAffectShadow)*RTD_LVLC),RTD_ST_OFF_OTHERS,RTD_ST_In_Sli);


					half3 RTD_ST = RTD_ST_ON;

				#else

					half3 RTD_ST = RTD_ST_OFF_OTHERS;
					half3 RTD_STIAL = 1;
					half3 RTD_ST_IS = 1;

				#endif

				half RTD_SS_SV = 1.0;

				#if N_F_SS_ON
 
					half RTD_SS_SSH_Sli = lerp(0.3,1.0,_SelfShadowHardness);
					half RTD_SS_VCGCSSS_OO = lerp( _SelfShadowThreshold, (_SelfShadowThreshold*(1.0 - i.vertexColor.g)), _VertexColorGreenControlSelfShadowThreshold );
					half RTD_SS_SST = smoothstep( RTD_SS_SSH_Sli, 1.0, (RTD_NDOTL*lerp(7,RTD_SS_VCGCSSS_OO,_SelfShadowThreshold)) );
					half RTD_SS_SSABLSS_OO = lerp( RTD_SS_SST, lerp(RTD_SS_SST,RTD_SS_SV,C_SS()), _SelfShadowAffectedByLightShadowStrength );
					half RTD_SS_ON = lerp(RTD_SS_SV,(RTD_SS_SSABLSS_OO*attenuation),_SelfShadowIntensity);

					half RTD_SS = RTD_SS_ON;

				#else

					half RTD_SS_OFF = lerp(RTD_SS_SV,attenuation,_SelfShadowIntensity);

					half RTD_SS = RTD_SS_OFF;

				#endif

				half3 RTD_R_OFF_OTHERS = (RTD_TEX_COL_REF*lerp((RTD_LAS*RTD_LVLC*RTD_ST_IS),RTD_ST,RTD_SS));

				#if N_F_R_ON

				half3 RTD_FR_OFF_OTHERS = Ref( viewReflectDirection , _ReflectionRoughtness );

					#if N_F_FR_ON

						half2 node_8431 = reflect(viewDirection,normalDirection).rg;
						half2 node_4207 = (float2(node_8431.r,(-1*node_8431.g))*0.5+0.5);
						half4 _FReflection_var = tex2Dlod(_FReflection,float4(TRANSFORM_TEX(node_4207, _FReflection),0.0,_ReflectionRoughtness));
						fixed3 RTD_FR_ON = _FReflection_var.rgb;

						half3 RTD_FR = RTD_FR_ON;

					#else

						half3 RTD_FR = RTD_FR_OFF_OTHERS;

					#endif

					half4 _MaskReflection_var = tex2D(_MaskReflection,TRANSFORM_TEX(i.uv0, _MaskReflection));
					half3 RTD_R_MAS = lerp(RTD_R_OFF_OTHERS, RTD_FR ,_MaskReflection_var.r);
					half3 RTD_R_ON = lerp(RTD_R_OFF_OTHERS,RTD_R_MAS,_ReflectionIntensity);

					half3 RTD_R = RTD_R_ON;

				#else

					half3 RTD_R = RTD_R_OFF_OTHERS;
				
				#endif

				#if N_F_RELGI_ON

					float node_3622 = 0.0;
					float node_7998 = 1.0;

					half3 RTD_SL_OFF_OTHERS = (AL_GI( lerp(float3(node_3622,node_3622,node_3622),float3(node_7998,node_7998,node_7998),RTD_GI_FS_OO) )*_EnvironmentalLightingIntensity);

				#else

					half3 RTD_SL_OFF_OTHERS = 0;

				#endif

				#if N_F_SL_ON

					half3 RTD_SL_HC_OO = lerp( 1.0, RTD_TEX_COL_REF, _SelfLitHighContrast );
					half4 _MaskSelfLit_var = tex2D(_MaskSelfLit,TRANSFORM_TEX(i.uv0, _MaskSelfLit));


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_SelfLitColor = float4(GammaToLinearSpace(_SelfLitColor.rgb), _SelfLitColor.a);
					#endif

					half3 RTD_SL_MAS = lerp(RTD_SL_OFF_OTHERS,((_SelfLitColor.rgb*RTD_TEX_COL_REF*RTD_SL_HC_OO)*_SelfLitPower),_MaskSelfLit_var.r);
					//


					half3 RTD_SL_ON = lerp(RTD_SL_OFF_OTHERS,RTD_SL_MAS,_SelfLitIntensity);

					half3 RTD_SL = RTD_SL_ON;

					half3 RTD_R_SEL = lerp(RTD_R,lerp(RTD_R,RTD_TEX_COL_REF*_TEXMCOLINT,_MaskSelfLit_var.r),_SelfLitIntensity);
					half3 RTD_SL_CHE_1 = RTD_R_SEL;

				#else

					half3 RTD_SL = RTD_SL_OFF_OTHERS;
					half3 RTD_SL_CHE_1 = RTD_R;

				#endif

				#if N_F_RL_ON

					half3 RTD_RL_ON = lerp((RTD_SL_CHE_1+RTD_RL_MAIN),RTD_SL_CHE_1,_RimLightInLight);
					half3 RTD_RL = RTD_RL_ON;

				#else
				
					half3 RTD_RL = RTD_SL_CHE_1;

				#endif

				 #if N_F_D_ON

					float node_7145 = 0.0;
					half RTD_D_HAR_Sli = clamp(_DepthEdgeHardness,_DepthEdgeHardness,(1.0-0.001));
					half3 RTD_D_ON = (RTD_RL+lerp((_DepthColor.rgb*_DepthColorPower),float3(node_7145,node_7145,node_7145),smoothstep( RTD_D_HAR_Sli, 1.0, saturate((sceneZ-partZ)/_Depth) )));

					half3 RTD_D = RTD_D_ON;

				#else

					half3 RTD_D = RTD_RL;

				#endif

				half3 RTD_CA_OFF_OTHERS = ((RTD_TEX_COL_REF*RTD_SL*RTD_STIAL)+RTD_D);

				#if N_F_CA_ON

					half3 RTD_CA_ON = lerp(RTD_CA_OFF_OTHERS,dot(RTD_CA_OFF_OTHERS,float3(0.3,0.59,0.11)),(1.0 - _Saturation));
					half3 RTD_CA = RTD_CA_ON;

				#else

					half3 RTD_CA = RTD_CA_OFF_OTHERS;

				#endif
	
				float3 finalColor = RTD_CA;

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
            BlendOp Max
            ZWrite [_ZWrite]
            
			Stencil {
            	Ref[_RefVal]
            	Comp [_Compa]
            	Pass [_Oper]
            	Fail [_Oper]
            }
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
			#include "Tessellation.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog

            #pragma only_renderers d3d9 d3d11 glcore gles3 metal xboxone ps4 wiiu 
            #pragma target 5.0

			#pragma shader_feature N_F_MC_ON
			#pragma shader_feature N_F_NM_ON
			#pragma shader_feature N_F_CA_ON
			#pragma shader_feature N_F_SL_ON
			#pragma shader_feature N_F_GLO_ON
			#pragma shader_feature N_F_GLOT_ON
			#pragma shader_feature N_F_SS_ON
			#pragma shader_feature N_F_SCT_ON
			#pragma shader_feature N_F_ST_ON
			#pragma shader_feature N_F_STIS_ON
			#pragma shader_feature N_F_STIAL_ON 
			#pragma shader_feature N_F_SON_ON
			#pragma shader_feature N_F_PT_ON

			#pragma shader_feature N_F_RELGI_ON

			#pragma shader_feature N_F_CLD_ON
			#pragma shader_feature N_F_R_ON
			#pragma shader_feature N_F_FR_ON
			#pragma shader_feature N_F_RL_ON
			#pragma shader_feature N_F_D_ON
			#pragma shader_feature N_F_NLASOBF_ON

            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;

			uniform half _RefractionIntensity;
            uniform half4 _MainColor;
			uniform fixed _MainColorAffectTexture;
			uniform half4 _HighlightColor;
			uniform half _HighlightColorPower;
			uniform half _TextureIntesnity;
			uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
			uniform fixed _TexturePatternStyle;

			#if N_F_MC_ON
				uniform half _MCapIntensity;
				uniform sampler2D _MCap; uniform float4 _MCap_ST;
				uniform half _SPECMODE;
				uniform half _SPECIN;
				uniform sampler2D _MCapMask; uniform float4 _MCapMask_ST;
			#endif

			#if N_F_NM_ON
				uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
				uniform half _NormalMapIntensity;
			#endif

			#if N_F_CA_ON
				uniform half _Saturation;
			#endif

			#if N_F_SL_ON
				uniform half _SelfLitIntensity;
				uniform half4 _SelfLitColor;
				uniform half _SelfLitPower;
				uniform half _TEXMCOLINT;
				uniform fixed _SelfLitHighContrast;
				uniform sampler2D _MaskSelfLit; uniform float4 _MaskSelfLit_ST;
			#endif

			#if N_F_GLO_ON
				uniform half _GlossIntensity;
				uniform half _Glossiness;
				uniform half _GlossSoftness;
				uniform half4 _GlossColor;
				uniform half _GlossColorPower;
				uniform sampler2D _MaskGloss; uniform float4 _MaskGloss_ST;
			#endif
			
			#if N_F_GLO_ON
				#if N_F_GLOT_ON
					uniform sampler2D _GlossTexture; uniform float4 _GlossTexture_ST;
					uniform half _GlossTextureSoftness;
					uniform half _PSGLOTEX;
					uniform half _GlossTextureRotate;
					uniform fixed _GlossTextureFollowObjectRotation;
					uniform half _GlossTextureFollowLight;
				#endif
			#endif

			uniform half4 _OverallShadowColor;
            uniform half _OverallShadowColorPower;

			uniform fixed _SelfShadowShadowTAtViewDirection;

			#if N_F_SS_ON
				uniform half _SelfShadowThreshold;
				uniform fixed _VertexColorGreenControlSelfShadowThreshold;
				uniform half _SelfShadowHardness;
				uniform fixed _SelfShadowAffectedByLightShadowStrength;
			#endif

			uniform half _SelfShadowIntensity;
			uniform half4 _SelfShadowColor;
			uniform half _SelfShadowColorPower;

			#if N_F_SON_ON
				uniform half _SmoothObjectNormal;
				uniform fixed _VertexColorRedControlSmoothObjectNormal;
				uniform float4 _XYZPosition;
				uniform half _XYZHardness;
				uniform fixed _ShowNormal;
			#endif

			#if N_F_SCT_ON
				uniform sampler2D _ShadowColorTexture; uniform float4 _ShadowColorTexture_ST;
				uniform half _ShadowColorTexturePower;
			#endif

			#if N_F_ST_ON
				uniform half _ShadowTIntensity;
				uniform sampler2D _ShadowT; uniform float4 _ShadowT_ST;
				uniform half _ShadowTLightThreshold;
				uniform half _ShadowTShadowThreshold;
				uniform half4 _ShadowTColor;
				uniform half _ShadowTColorPower;
				uniform half _ShadowTHardness;
				uniform half _STIL;
				uniform half _ShowInAmbientLightShadowIntensity;
				uniform half _ShowInAmbientLightShadowThreshold;
				uniform fixed _LightFalloffAffectShadowT;
			#endif

			#if N_F_PT_ON
				uniform sampler2D _PTexture; uniform float4 _PTexture_ST;
				uniform half _PTexturePower;
			#endif

			#if N_F_RELGI_ON
				uniform fixed _GIFlatShade;
				uniform half _GIShadeThreshold;
				uniform half _EnvironmentalLightingIntensity;
			#endif

			uniform fixed _LightAffectShadow;
			uniform half _LightIntensity;
			uniform half _PointSpotlightIntensity;
			uniform half _LightFalloffSoftness;

			#if N_F_CLD_ON
				uniform half _CustomLightDirectionIntensity;
				uniform half4 _CustomLightDirection;
				uniform fixed _CustomLightDirectionFollowObjectRotation;
			#endif

			#if N_F_R_ON
				uniform half _ReflectionIntensity;
				uniform half _ReflectionRoughtness;
				uniform half _RefMetallic;
				uniform sampler2D _MaskReflection; uniform float4 _MaskReflection_ST;
			#endif

			#if N_F_R_ON
				#if N_F_FR_ON
					uniform sampler2D _FReflection; uniform float4 _FReflection_ST;
				#endif
			#endif

			#if N_F_RL_ON
				uniform half _RimLightUnfill;
				uniform half _RimLightSoftness;	
				uniform fixed _LightAffectRimLightColor;
				uniform half4 _RimLightColor;
				uniform half _RimLightColorPower;
				uniform fixed _RimLightInLight;
			#endif
			            
			uniform half _Depth;
            uniform half _DepthEdgeHardness;
            uniform half4 _DepthColor;
            uniform half _DepthColorPower;

			uniform float _TessellationSmoothness;
			uniform half _TessellationTransition;
			uniform half _TessellationNear;
			uniform half _TessellationFar;
		
            half3 AL_GI( float3 N )
			{
				return ShadeSH9(float4(N,1));
            }

			#if N_F_R_ON

				float3 Ref( half3 VR , half Mip )
				{
					float4 skyData = UNITY_SAMPLE_TEXCUBE_LOD(unity_SpecCube0, VR, Mip);
					return DecodeHDR (skyData, unity_SpecCube0_HDR);
				}

			#endif

            fixed C_SS()
			{
				return _LightShadowData.x;
            }

            struct VertexInput 
			{

                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;

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

            };

            VertexOutput vert (VertexInput v) 
			{

                VertexOutput o = (VertexOutput)0;

                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;

            }

            #ifdef UNITY_CAN_COMPILE_TESSELLATION

                struct TessVertex 
				{

                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                    float4 vertexColor : COLOR;

                };

                struct OutputPatchConstant 
				{

                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;

                };

                TessVertex tessvert (VertexInput v) 
				{

                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    o.vertexColor = v.vertexColor;
                    return o;

                }

                float Tessellation(TessVertex v)
				{

                    half RTD_TES_TRANS_Sli = (1.0 - _TessellationTransition);
                    half RTD_TES = lerp(_TessellationNear,_TessellationFar,saturate((distance(mul(unity_ObjectToWorld, v.vertex).rgb,_WorldSpaceCameraPos)*RTD_TES_TRANS_Sli)));
                    return RTD_TES;

                }

                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2)
				{

                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);

                }

                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) 
				{

                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;

                }

                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]

                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) 
				{
                    return v[id];
                }

                [domain("tri")]

                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) 
				{

                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;

					float3 pp[3];
					for (int i = 0; i < 3; ++i)
					pp[i] = v.vertex.xyz - vi[i].normal * (dot(v.vertex.xyz, vi[i].normal) - dot(vi[i].vertex.xyz, vi[i].normal));
					v.vertex.xyz = _TessellationSmoothness * (pp[0] * bary.x + pp[1] * bary.y + pp[2] * bary.z) + (1.0f - _TessellationSmoothness) * v.vertex.xyz;

                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    v.vertexColor = vi[0].vertexColor*bary.x + vi[1].vertexColor*bary.y + vi[2].vertexColor*bary.z;
                    VertexOutput o = vert(v);
                    return o;

                }

            #endif

            float4 frag(VertexOutput i, float facing : VFACE) : COLOR 
			{

			     #if N_F_NM_ON
					half3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
					float3 normalLocal = lerp(half3(0,0,1),_NormalMap_var.rgb,_NormalMapIntensity);
				#else
					float3 normalLocal = half3(0,0,1);
				#endif

				half isFrontFace = ( facing >= 0 ? 1 : 0 );
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
				float2 sceneUVs = (i.projPos.xy / i.projPos.w);

                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform ));
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );

				half RTD_OB_VP_CAL = distance(objPos.rgb,_WorldSpaceCameraPos);
				half2 RTD_VD_Cal = (float2((sceneUVs.x * 2 - 1)*(_ScreenParams.r/_ScreenParams.g), sceneUVs.y * 2 - 1).rg*RTD_OB_VP_CAL);

                half2 RTD_TCR_TP_OO = lerp( i.uv0, RTD_VD_Cal, _TexturePatternStyle );
				half2 node_9073 = RTD_TCR_TP_OO;

				#if N_F_MC_ON
            
					half2 MUV = (mul( UNITY_MATRIX_V, float4(normalDirection,0) ).xyz.rgb.rg*0.5+0.5);
					half4 _MatCap_var = tex2D(_MCap,TRANSFORM_TEX(MUV, _MCap));
					half4 _MCapMask_var = tex2D(_MCapMask,TRANSFORM_TEX(i.uv0, _MCapMask)); 
					float3 MCapOutP = lerp( lerp(1,0, _SPECMODE), lerp( lerp(1,0, _SPECMODE) ,_MatCap_var.rgb,_MCapIntensity) ,_MCapMask_var.rgb );

				#else
            
					half MCapOutP = 1; 

				#endif

                half4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_9073, _MainTex)); 


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_MainColor = float4(GammaToLinearSpace(_MainColor.rgb), _MainColor.a);
				#endif

                half3 node_7067 = (tex2D( _GrabTexture, lerp(sceneUVs.rg,reflect(float3(sceneUVs.rg,0.0),normalDirection).rg,lerp(0.0,(-0.2),_RefractionIntensity))).rgb*_MainColor.rgb);
				//


				half3 ref_tex = lerp(node_7067,lerp(node_7067,lerp( _MainTex_var.rgb, (_MainTex_var.rgb*_MainColor.rgb), _MainColorAffectTexture ),_MainTex_var.a),_TextureIntesnity);

				#if N_F_MC_ON

					half3 SPECMode_Sel = lerp( (ref_tex* MCapOutP), ( ref_tex + (MCapOutP * _SPECIN) ), _SPECMODE);

					half3 RTD_TEX_COL_REF = SPECMode_Sel;

				#else

					half3 RTD_TEX_COL_REF = ref_tex * MCapOutP;

				#endif

                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);

                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);

                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));

                #if N_F_NLASOBF_ON
					float3 lightColor = lerp(0,_LightColor0.rgb,isFrontFace);
				#else
					float3 lightColor = _LightColor0.rgb;
				#endif

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
				#ifdef DIRECTIONAL_COOKIE
					#if !defined(UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS)
					#define DLCOO(input, worldPos) unityShadowCoord2 lightCoord = mul(unity_WorldToLight, unityShadowCoord4(worldPos, 1)).xy
				#else
					#define DLCOO(input, worldPos) unityShadowCoord2 lightCoord = input._LightCoord
				#endif
					DLCOO(i, i.posWorld.xyz);
					lightfo = tex2D(_LightTexture0, lightCoord).w;
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

				fixed attenuation = 1; 
				fixed lightfos = smoothstep(0, _LightFalloffSoftness ,lightfo);

				#if N_F_SON_ON

					float3 node_76 = mul( unity_WorldToObject, float4((i.posWorld.rgb-objPos.rgb),0) ).xyz.rgb.rgb;
					half RTD_SON_VCBSON_OO = lerp( _SmoothObjectNormal, (_SmoothObjectNormal*(1.0 - i.vertexColor.r)), _VertexColorRedControlSmoothObjectNormal );
					half3 RTD_SON_ON_OTHERS = lerp(normalDirection,mul( unity_ObjectToWorld, float4(float3((_XYZPosition.r+(_XYZHardness*node_76.r)),(_XYZPosition.g+(_XYZHardness*node_76.g)),(_XYZPosition.b+(_XYZHardness*node_76.b))),0) ).xyz.rgb,RTD_SON_VCBSON_OO);
				
					half3 RTD_SON = RTD_SON_ON_OTHERS;

					half3 RTD_SNorm_OO = lerp( 1.0, RTD_SON_ON_OTHERS, _ShowNormal );
					half3 RTD_SON_CHE_1 = RTD_SNorm_OO;

				#else
					
					half3 RTD_SON = normalDirection;
					half3 RTD_SON_CHE_1 = 1;

				#endif

				#if N_F_RELGI_ON

					half3 RTD_GI_ST_Sli = (RTD_SON*_GIShadeThreshold);

					float node_2183 = 0;
					float node_8383 = 0.01;

					half3 RTD_GI_FS_OO = lerp( RTD_GI_ST_Sli, float3(smoothstep( float2(node_2183,node_2183), float2(node_8383,node_8383), (RTD_SON.rb*_GIShadeThreshold) ),0.0), _GIFlatShade );
				
				#else

					half3 RTD_GI_FS_OO = RTD_SON;

				#endif

				#if N_F_SCT_ON

					half4 _ShadowColorTexture_var = tex2D(_ShadowColorTexture,TRANSFORM_TEX(i.uv0, _ShadowColorTexture));
					half3 RTD_SCT_ON = lerp(_ShadowColorTexture_var.rgb,(_ShadowColorTexture_var.rgb*_ShadowColorTexture_var.rgb),_ShadowColorTexturePower);

					half3 RTD_SCT = RTD_SCT_ON;

				#else

					half3 RTD_SCT = 1;

				#endif

				#if N_F_PT_ON

					float2 node_405 = RTD_VD_Cal;
					half4 _PTexture_var = tex2D(_PTexture,TRANSFORM_TEX(node_405, _PTexture));
					half RTD_PT_ON = lerp((1.0 - _PTexturePower),1.0,_PTexture_var.r);

					half RTD_PT = RTD_PT_ON;

				#else

					half RTD_PT = 1;

				#endif


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_OverallShadowColor = float4(GammaToLinearSpace(_OverallShadowColor.rgb), _OverallShadowColor.a);
				#endif

				half3 RTD_OSC = (_OverallShadowColor.rgb*_OverallShadowColorPower);
				//


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_SelfShadowColor = float4(GammaToLinearSpace(_SelfShadowColor.rgb), _SelfShadowColor.a);
				#endif

				half3 node_1860 = ((_SelfShadowColor.rgb*_SelfShadowColorPower)*RTD_OSC*RTD_SCT*RTD_PT);
				//


                half3 node_6694 = (_LightIntensity+lightColor.rgb);

				half3 RTD_LAS = lerp(node_1860,(node_1860+node_6694),_LightAffectShadow);


				//
				#ifndef UNITY_COLORSPACE_GAMMA
					_HighlightColor = float4(GammaToLinearSpace(_HighlightColor.rgb), _HighlightColor.a);
				#endif

				half3 RTD_HL = (_HighlightColor.rgb*_HighlightColorPower+_PointSpotlightIntensity);
				//


                float4 node_6613_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_6613_p = lerp(float4(float4(lightColor.rgb,0.0).zy, node_6613_k.wz), float4(float4(lightColor.rgb,0.0).yz, node_6613_k.xy), step(float4(lightColor.rgb,0.0).z, float4(lightColor.rgb,0.0).y));
                float4 node_6613_q = lerp(float4(node_6613_p.xyw, float4(lightColor.rgb,0.0).x), float4(float4(lightColor.rgb,0.0).x, node_6613_p.yzx), step(node_6613_p.x, float4(lightColor.rgb,0.0).x));
                float node_6613_d = node_6613_q.x - min(node_6613_q.w, node_6613_q.y);
                float node_6613_e = 1.0e-10;
                half3 node_6613 = float3(abs(node_6613_q.z + (node_6613_q.w - node_6613_q.y) / (6.0 * node_6613_d + node_6613_e)), node_6613_d / (node_6613_q.x + node_6613_e), node_6613_q.x);

				half RTD_LVLC = saturate(node_6613.b);

				#if N_F_GLO_ON

					#if N_F_GLOT_ON

						float node_5992_ang = _GlossTextureRotate;
						float node_5992_spd = 1.0;
						float node_5992_cos = cos(node_5992_spd*node_5992_ang);
						float node_5992_sin = sin(node_5992_spd*node_5992_ang);
						float2 node_5992_piv = float2(0.5,0.5);

						half3 RTD_GT_FL_Sli = lerp(viewDirection,halfDirection,_GlossTextureFollowLight);
						half3 node_2832 = reflect(RTD_GT_FL_Sli,normalDirection);

						half3 RTD_GT_FOR_OO = lerp( node_2832, mul( unity_WorldToObject, float4(node_2832,0) ).xyz.rgb, _GlossTextureFollowObjectRotation );
						half2 node_9280 = RTD_GT_FOR_OO.rg;

						half2 node_5992 = (mul(float2((-1*node_9280.r),node_9280.g)-node_5992_piv,float2x2( node_5992_cos, -node_5992_sin, node_5992_sin, node_5992_cos))+node_5992_piv); 
						half2 node_8759 = (node_5992*0.5+0.5); 

						half4 _GlossTexture_var = tex2Dlod(_GlossTexture,float4(TRANSFORM_TEX( lerp(node_8759,RTD_VD_Cal,_PSGLOTEX) , _GlossTexture),0.0,_GlossTextureSoftness));
						half RTD_GT_ON = _GlossTexture_var.r;

						half3 RTD_GT = RTD_GT_ON;

					#else

						half RTD_GLO_MAIN_Sof_Sil = lerp(0.1,1.0,_GlossSoftness);
						half RTD_NDOTH = max(0,dot(halfDirection,normalDirection));
						half RTD_GLO_MAIN = smoothstep( 0.1, RTD_GLO_MAIN_Sof_Sil, pow(RTD_NDOTH,exp2(lerp(-2,15,_Glossiness))) );

						half3 RTD_GT = RTD_GLO_MAIN;

					#endif

					float node_9345 = 0.0;
					half3 RTD_GLO_I_Sil = lerp(float3(node_9345,node_9345,node_9345),RTD_GT,_GlossIntensity);
					half4 _MaskGloss_var = tex2D(_MaskGloss,TRANSFORM_TEX(i.uv0, _MaskGloss));
					half3 RTD_GLO_MAS = lerp(RTD_HL,lerp(RTD_HL,(_GlossColor.rgb*_GlossColorPower),RTD_GLO_I_Sil),_MaskGloss_var.r);

					half3 RTD_GLO = RTD_GLO_MAS;

				#else

					half3 RTD_GLO = RTD_HL;

				#endif

				#if N_F_RL_ON

					float node_4353 = 0.0;
					float node_3687 = 0.0;


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_RimLightColor = float4(GammaToLinearSpace(_RimLightColor.rgb), _RimLightColor.a);
					#endif

					half3 RTD_RL_LARL_OO = lerp( _RimLightColor.rgb, lerp(float3(node_3687,node_3687,node_3687),_RimLightColor.rgb,lightColor.rgb), _LightAffectRimLightColor );
					//


					half RTD_RL_S_Sli = lerp(1.7,0.29,_RimLightSoftness);
					half3 RTD_RL_MAIN = lerp(float3(node_4353,node_4353,node_4353),(RTD_RL_LARL_OO*_RimLightColorPower),smoothstep( 1.71, RTD_RL_S_Sli, pow(1.0-max(0,dot(normalDirection, viewDirection)),(1.0 - _RimLightUnfill)) ));
					half3 RTD_RL_IL_OO = lerp(RTD_GLO,(RTD_GLO+RTD_RL_MAIN),_RimLightInLight);

					half3 RTD_RL_CHE_1 = RTD_RL_IL_OO;

				#else

					half3 RTD_RL_CHE_1 = RTD_GLO;

				#endif

				#if N_F_CLD_ON

					half3 RTD_CLD_CLDFOR_OO = lerp( _CustomLightDirection.rgb, mul( unity_ObjectToWorld, float4(_CustomLightDirection.rgb,0) ).xyz.rgb, _CustomLightDirectionFollowObjectRotation );
					half3 RTD_CLD_CLDI_Sli = lerp(lightDirection,RTD_CLD_CLDFOR_OO,_CustomLightDirectionIntensity);
					half3 RTD_CLD = RTD_CLD_CLDI_Sli;

				#else

					half3 RTD_CLD = lightDirection;

				#endif

				half3 RTD_ST_SS_AVD_OO = lerp( RTD_CLD, viewDirection, _SelfShadowShadowTAtViewDirection );
				half RTD_NDOTL = 0.5*dot(RTD_ST_SS_AVD_OO,RTD_SON)+0.5;

				half3 RTD_ST_OFF_OTHERS = (RTD_RL_CHE_1*RTD_SON_CHE_1*lightColor.rgb);

				#if N_F_ST_ON

					float node_208 = 1.0; 
					half node_4736 = 1.0; 
					float node_7419 = 1.0;
					half node_3187 = 0.22; 


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_ShadowTColor = float4(GammaToLinearSpace(_ShadowTColor.rgb), _ShadowTColor.a);
					#endif

					half4 _ShadowT_var = tex2D(_ShadowT,TRANSFORM_TEX(i.uv0, _ShadowT)); 
					half3 node_338 = ((_ShadowTColor.rgb*_ShadowTColorPower)*RTD_SCT*RTD_PT*RTD_OSC);
					//


					half RTD_ST_H_Sli = lerp(0.0,0.22,_ShadowTHardness);
					half3 RTD_ST_IS_ON = lerp(float3(node_4736,node_4736,node_4736),lerp(node_338,float3(node_7419,node_7419,node_7419),smoothstep( RTD_ST_H_Sli, node_3187, (_ShowInAmbientLightShadowThreshold*_ShadowT_var.r) )),_ShadowTIntensity);

					#if N_F_STIAL_ON

						float node_932 = 1.0;
						half3 RTD_ST_ALI_Sli = lerp(float3(node_932,node_932,node_932),RTD_ST_IS_ON,_ShowInAmbientLightShadowIntensity);
						half3 RTD_STIAL_ON = lerp(RTD_ST_ALI_Sli,float3(node_208,node_208,node_208),clamp((RTD_LVLC*8.0),0,1));

						half3 RTD_STIAL = RTD_STIAL_ON;

					#else

						half3 RTD_STIAL = 1;

					#endif

					#if N_F_STIS_ON

						half3 RTD_ST_IS = lerp(1,RTD_ST_IS_ON,_ShowInAmbientLightShadowIntensity);

					#else

						half3 RTD_ST_IS = 1;

					#endif

					half RTD_ST_LFAST_OO = lerp(lerp( RTD_NDOTL, (lightfos*RTD_NDOTL), _LightFalloffAffectShadowT ) , 1 , _STIL );
					half RTD_ST_In_Sli = lerp(node_4736,smoothstep( RTD_ST_H_Sli, node_3187, ((_ShadowT_var.r*(1.0 - _ShadowTShadowThreshold))*(RTD_ST_LFAST_OO*_ShadowTLightThreshold)*0.01) ),_ShadowTIntensity);
					half3 RTD_ST_ON = lerp((lerp(node_338,(node_338+node_6694),_LightAffectShadow)*RTD_LVLC),RTD_ST_OFF_OTHERS,RTD_ST_In_Sli);


					half3 RTD_ST = RTD_ST_ON;

				#else

					half3 RTD_ST = RTD_ST_OFF_OTHERS;
					half3 RTD_STIAL = 1;
					half3 RTD_ST_IS = 1;

				#endif

				half RTD_SS_SV = 1.0;

				#if N_F_SS_ON
 
					half RTD_SS_SSH_Sli = lerp(0.3,1.0,_SelfShadowHardness);
					half RTD_SS_VCGCSSS_OO = lerp( _SelfShadowThreshold, (_SelfShadowThreshold*(1.0 - i.vertexColor.g)), _VertexColorGreenControlSelfShadowThreshold );
					half RTD_SS_SST = smoothstep( RTD_SS_SSH_Sli, 1.0, (RTD_NDOTL*lerp(7,RTD_SS_VCGCSSS_OO,_SelfShadowThreshold)) );
					half RTD_SS_SSABLSS_OO = lerp( RTD_SS_SST, lerp(RTD_SS_SST,RTD_SS_SV,C_SS()), _SelfShadowAffectedByLightShadowStrength );
					half RTD_SS_ON = lerp(RTD_SS_SV,(RTD_SS_SSABLSS_OO*attenuation),_SelfShadowIntensity);

					half RTD_SS = RTD_SS_ON;

				#else

					half RTD_SS_OFF = lerp(RTD_SS_SV,attenuation,_SelfShadowIntensity);

					half RTD_SS = RTD_SS_OFF;

				#endif

				half3 RTD_R_OFF_OTHERS = (RTD_TEX_COL_REF*lerp((RTD_LAS*RTD_LVLC*RTD_ST_IS),RTD_ST,RTD_SS));

				#if N_F_R_ON

				half3 RTD_FR_OFF_OTHERS = Ref( viewReflectDirection , _ReflectionRoughtness );

					#if N_F_FR_ON

						half2 node_8431 = reflect(viewDirection,normalDirection).rg;
						half2 node_4207 = (float2(node_8431.r,(-1*node_8431.g))*0.5+0.5);
						half4 _FReflection_var = tex2Dlod(_FReflection,float4(TRANSFORM_TEX(node_4207, _FReflection),0.0,_ReflectionRoughtness));
						fixed3 RTD_FR_ON = _FReflection_var.rgb;

						half3 RTD_FR = RTD_FR_ON;

					#else

						half3 RTD_FR = RTD_FR_OFF_OTHERS;

					#endif

					half4 _MaskReflection_var = tex2D(_MaskReflection,TRANSFORM_TEX(i.uv0, _MaskReflection));
					half3 RTD_R_MAS = lerp(RTD_R_OFF_OTHERS, RTD_FR ,_MaskReflection_var.r);
					half3 RTD_R_ON = lerp(RTD_R_OFF_OTHERS,RTD_R_MAS,_ReflectionIntensity);

					half3 RTD_R = RTD_R_ON;

				#else

					half3 RTD_R = RTD_R_OFF_OTHERS;
				
				#endif

				#if N_F_RELGI_ON

					float node_3622 = 0.0;
					float node_7998 = 1.0;

					half3 RTD_SL_OFF_OTHERS = (AL_GI( lerp(float3(node_3622,node_3622,node_3622),float3(node_7998,node_7998,node_7998),RTD_GI_FS_OO) )*_EnvironmentalLightingIntensity);

				#else

					half3 RTD_SL_OFF_OTHERS = 0;

				#endif

				#if N_F_SL_ON

					half3 RTD_SL_HC_OO = lerp( 1.0, RTD_TEX_COL_REF, _SelfLitHighContrast );
					half4 _MaskSelfLit_var = tex2D(_MaskSelfLit,TRANSFORM_TEX(i.uv0, _MaskSelfLit));


					//
					#ifndef UNITY_COLORSPACE_GAMMA
						_SelfLitColor = float4(GammaToLinearSpace(_SelfLitColor.rgb), _SelfLitColor.a);
					#endif

					half3 RTD_SL_MAS = lerp(RTD_SL_OFF_OTHERS,((_SelfLitColor.rgb*RTD_TEX_COL_REF*RTD_SL_HC_OO)*_SelfLitPower),_MaskSelfLit_var.r);
					//


					half3 RTD_SL_ON = lerp(RTD_SL_OFF_OTHERS,RTD_SL_MAS,_SelfLitIntensity);

					half3 RTD_SL = RTD_SL_ON;

					half3 RTD_R_SEL = lerp(RTD_R,lerp(RTD_R,RTD_TEX_COL_REF*_TEXMCOLINT,_MaskSelfLit_var.r),_SelfLitIntensity);
					half3 RTD_SL_CHE_1 = RTD_R_SEL;

				#else

					half3 RTD_SL = RTD_SL_OFF_OTHERS;
					half3 RTD_SL_CHE_1 = RTD_R;

				#endif

				#if N_F_RL_ON

					half3 RTD_RL_ON = lerp((RTD_SL_CHE_1+RTD_RL_MAIN),RTD_SL_CHE_1,_RimLightInLight);
					half3 RTD_RL = RTD_RL_ON;

				#else
				
					half3 RTD_RL = RTD_SL_CHE_1;

				#endif

				 #if N_F_D_ON

					float node_7145 = 0.0;
					half RTD_D_HAR_Sli = clamp(_DepthEdgeHardness,_DepthEdgeHardness,(1.0-0.001));
					half3 RTD_D_ON = (RTD_RL+lerp((_DepthColor.rgb*_DepthColorPower),float3(node_7145,node_7145,node_7145),smoothstep( RTD_D_HAR_Sli, 1.0, saturate((sceneZ-partZ)/_Depth) )));

					half3 RTD_D = RTD_D_ON;

				#else

					half3 RTD_D = RTD_RL;

				#endif

				half3 RTD_CA_OFF_OTHERS = ((RTD_TEX_COL_REF*RTD_SL*RTD_STIAL)+RTD_D)*lightfos;

				#if N_F_CA_ON

					half3 RTD_CA_ON = lerp(RTD_CA_OFF_OTHERS,dot(RTD_CA_OFF_OTHERS,float3(0.3,0.59,0.11)),(1.0 - _Saturation));
					half3 RTD_CA = RTD_CA_ON;

				#else

					half3 RTD_CA = RTD_CA_OFF_OTHERS;

				#endif

				float3 finalColor = RTD_CA;

                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;

            }

            ENDCG

        }

    }

	CustomEditor "RealToon.GUIInspector.RealToonShaderGUI"
}