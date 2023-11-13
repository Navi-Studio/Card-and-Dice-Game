//RealToonGUI(Lite)
//MJQStudioWorks
//2021

#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System;

namespace RealToon.GUIInspector
{
    public class RealToonShaderGUI_Lite : ShaderGUI
    {

        #region foldout bools variable

        static bool ShowTextureColor;
        static bool ShowNormalMap;
        static bool ShowTransparency;
        static bool ShowMatCap;
        static bool ShowOutline;
        static bool ShowSelfLit;
        static bool ShowGloss;
        static bool ShowShadow;
        static bool ShowLighting;
        static bool ShowFReflection;
        static bool ShowRimLight;
        static bool ShowSeeThrough;
        static bool ShowDisableEnable;
        static bool ShowUI = true;

        static string ShowUIString = "Hide UI";

        #endregion

        #region Variables

        string shader_name;
        string shader_type;
        bool del_skw = false;
        static bool aruskw = false;

        #endregion

        #region Material Properties Variables

        MaterialProperty _DoubleSided;

        MaterialProperty _MainTex;
        MaterialProperty _MainColor;
        MaterialProperty _MainColorAffectTexture;
        MaterialProperty _MVCOL;
        MaterialProperty _MCIALO;
        MaterialProperty _EnableTextureTransparent;

        MaterialProperty _MCapIntensity;
        MaterialProperty _MCap;
        MaterialProperty _SPECMODE;
        MaterialProperty _SPECIN;
        MaterialProperty _MCapMask;

        MaterialProperty _NormalMap;
        MaterialProperty _NormalMapIntensity;

        MaterialProperty _Opacity;
        MaterialProperty _TransparentThreshold;
        MaterialProperty _AffectShadow;
        MaterialProperty _MaskTransparency;

        MaterialProperty _OutlineWidth;
        MaterialProperty _OutlineWidthControl;
        MaterialProperty _OutlineExtrudeMethod;
        MaterialProperty _OutlineOffset;
        MaterialProperty _OutlineZPostionInCamera;
        MaterialProperty _DoubleSidedOutline;
        MaterialProperty _VertexColorBlueAffectOutlineWitdh;
        MaterialProperty _OutlineWidthAffectedByViewDistance;
        MaterialProperty _FarDistanceMaxWidth;
        MaterialProperty _OutlineColor;
        MaterialProperty _MixMainTexToOutline;
        MaterialProperty _LightAffectOutlineColor;

        MaterialProperty _SelfLitIntensity;
        MaterialProperty _SelfLitColor;
        MaterialProperty _SelfLitPower;
        MaterialProperty _TEXMCOLINT;
        MaterialProperty _SelfLitHighContrast;
        MaterialProperty _MaskSelfLit;

        MaterialProperty _Glossiness;
        MaterialProperty _GlossSoftness;
        MaterialProperty _GlossColor;
        MaterialProperty _GlossColorPower;
        MaterialProperty _MaskGloss;

        MaterialProperty _GlossTexture;
        MaterialProperty _GlossTextureSoftness;
        MaterialProperty _PSGLOTEX;
        MaterialProperty _GlossTextureFollowObjectRotation;
        MaterialProperty _GlossTextureFollowLight;

        MaterialProperty _OverallShadowColor;
        MaterialProperty _OverallShadowColorPower;
        MaterialProperty _SelfShadowShadowTAtViewDirection;

        MaterialProperty _HighlightColor;
        MaterialProperty _HighlightColorPower;

        MaterialProperty _SelfShadowThreshold;
        MaterialProperty _VertexColorGreenControlSelfShadowThreshold;
        MaterialProperty _SelfShadowHardness;
        MaterialProperty _SelfShadowRealTimeShadowColor;
        MaterialProperty _SelfShadowRealTimeShadowColorPower;

        MaterialProperty _SmoothObjectNormal;
        MaterialProperty _VertexColorRedControlSmoothObjectNormal;
        MaterialProperty _XYZPosition;
        MaterialProperty _XYZHardness;
        MaterialProperty _ShowNormal;

        MaterialProperty _ShadowColorTexture;
        MaterialProperty _ShadowColorTexturePower;

        MaterialProperty _ShadowT;
        MaterialProperty _ShadowTLightThreshold;
        MaterialProperty _ShadowTShadowThreshold;
        MaterialProperty _ShadowTColor;
        MaterialProperty _ShadowTColorPower;
        MaterialProperty _ShadowTHardness;
        MaterialProperty _STIL;
        MaterialProperty _LightFalloffAffectShadowT;

        MaterialProperty _PTexture;
        MaterialProperty _PTexturePower;

        MaterialProperty _DirectionalLightIntensity;
        MaterialProperty _PointSpotlightIntensity;
        MaterialProperty _LightFalloffSoftness;
        MaterialProperty _ReduceShadowPointLight;
        MaterialProperty _ReduceShadowSpotDirectionalLight;

        MaterialProperty _CustomLightDirectionIntensity;
        MaterialProperty _CustomLightDirectionFollowObjectRotation;
        MaterialProperty _CustomLightDirection;

        MaterialProperty _FReflectionIntensity;
        MaterialProperty _FReflection;
        MaterialProperty _FReflectionRoughtness;
        MaterialProperty _RefMetallic;
        MaterialProperty _MaskFReflection;

        MaterialProperty _RimLightUnfill;
        MaterialProperty _RimLightColor;
        MaterialProperty _RimLightColorPower;
        MaterialProperty _LightAffectRimLightColor;
        MaterialProperty _RimLightSoftness;
        MaterialProperty _RimLightInLight;

        MaterialProperty _RefVal;
        MaterialProperty _Oper;
        MaterialProperty _Compa;

        MaterialProperty _L_F_MC;
        MaterialProperty _L_F_NM;
        MaterialProperty _L_F_O;
        MaterialProperty _L_F_SL;
        MaterialProperty _L_F_GLO;
        MaterialProperty _L_F_GLOT;
        MaterialProperty _L_F_SS;
        MaterialProperty _L_F_SON;
        MaterialProperty _L_F_SCT;
        MaterialProperty _L_F_ST;
        MaterialProperty _L_F_PT;
        MaterialProperty _RELG;
        MaterialProperty _L_F_UOAL;
        MaterialProperty _L_F_CLD;
        MaterialProperty _L_F_FR;
        MaterialProperty _L_F_RL;
        MaterialProperty _L_F_HPSS;
        MaterialProperty _ZWrite;

        #endregion

        #region List of SFKW

        enum SFKW
        {
            L_F_MC_ON,
            L_F_NM_ON,
            L_F_O_ON,
            L_F_SL_ON,
            L_F_GLO_ON,
            L_F_GLOT_ON,
            L_F_SS_ON,
            L_F_SON_ON,
            L_F_SCT_ON,
            L_F_ST_ON,
            L_F_PT_ON,
            L_F_UOAL_ON,
            L_F_RELGI_ON,
            L_F_CLD_ON,
            L_F_FR_ON,
            L_F_RL_ON,
            L_F_HPSS_ON
        }

        #endregion

        #region TOTIPS

        string[] TOTIPS =
        {

        //Double Sided [0]
        "Make the other side of a plane object or face visible." ,

        //Texture [1]
        "Main or base texture." , 

        //Main Color [2]
        "Main or base color." ,

        //Mix Vertex Color [3]
        "Mix or show vertex color." ,

        //Main Color in Ambient Light Only [4]
        "Put the 'Main/Base Color' into ambient light." ,

        //Highlight Color [5]
        "Highlight color." ,

        //Highlight Color Power [6]
        "'Highlight Color' power or intensity." ,

        //Enable Texture Transparent [7]
        "This will enable 'Main/Base Texture' alpha/transparent." ,

        //Intensity [8] [MatCap]
        "MatCap intensity." ,

        //MatCap [9] [MatCap]
        "MatCap texture." ,

        //Specualar Mode [10] [MatCap]
        "Turn MatCap into specular." ,

        //Specular Power [11] [MatCap]
        "Specular intensity or power." ,

        //Mask MatCap [12] [MatCap]
        "Mask MatCap.\n\nUse a Black and White texture map.\nWhite means visible matcap while Black is not." ,

        //Opacity [13] [Transparency]
        "Transparent - Opaque" ,

        //Transparent Threshold [14] 
        "'Main/Base Texture' transparency threshold." ,

        //Affect Shadow [15]
        "Transparency affect shadow." ,

        //Mask Transparency [16] [Transparency]
        "Mask Transparency.\n\nWhite means opaque while Black means transparent." ,

        //Normal Map [17]
        "Normal Map." ,

        //Normal Map Intensity [18]
        "'Normal Map' intensity." ,

        //Width [19] [Outline] [Default]
        "Outline main width." ,

        //Width Control [20] [Outline] [Default]
        "Controls the 'Outline Width' using texture Map.\n\nUse a Black and White texture map.\nWhite means 1 while Black means 0.\nThis will not work if the Outline main width value is 0." ,

        //Outline Extrude Method [21] [Default]
        "Outline Extrude Methods.\n\nNormal - The outline extrusion will be based on normal direction.\n\nOrigin - The outline extrusion will be based on the center of the object." ,

        //Outline Offset [22] [Default]
        "Outline XYZ position." ,

        //Outline Z Position In Camera [23] [Outline] [Default]
        "Adjust the outline Z position in camera space." ,

        //Double Sided Outline [24] [Default]
        "Show the front side of the outline.\n\nUseful for plane object.\n'Outline Z Position In Camera' option is needed to be adjust to show the object." ,

        //Color [25] [Outline] [Default]
        "Outline color." ,

        //Mix Main Texture To Outline [26] [Default]
        "Mix 'Main/Base Texture' to oultine." ,

        //Light Affect Outline Color [27] [Default]
        "Light (Brightness and Color) affect Outline color." ,

        //Outline Width Affected By View Distance [28] [Default]
        "'Outline Width' affected by view distance." ,

        //Far Distance Max Width [29] [Outline] [Default]
        "The maximum 'Outline Width' limit when moving far from the object." ,

        //Vertex Color Blue Affect Outline Width [30] [Outline] [Default]
        "'Vertex Color Blue' will affect the Outline Width.\n\n*This will not work if the Outline main width value is 0.\n*Blue means 1 while Black mean 0." ,

        //Intensity [31] [SelfLit]
        "'Self Lit' intensity." ,

        //Color [32] [SelfLit]
        "Self Lit color" ,

        //Power [33] [SelfLit]
        "'Self Lit Color' power or intensity." ,

        //Texture and Main Color Intensity [34] [SelfLit]
        "'Main/Base Texture' and 'Main/Base Color' intensity.\n\nAdjust this if the 'Main/Base Texture' and 'Main/Base Color' is too strong or too bright for Self Lit." ,

        //High Contrast [35] [SelfLit]
        "Turn Self Lit into high contrast colors and mix 'Base/Main Texture' twice." ,

        //Mask Self Lit [36]
        "Mask Self Lit.\n\nUse a Black and White texture map.\nWhite means visible Self Lit while Black is not." ,

        //Glossiness [37]
        "Glossiness." ,

        //Softness [38] [Gloss]
        "The softness of the gloss." ,

        //Color [39] [Gloss]
        "Gloss color" ,

        //Power [40] [Gloss]
        "'Gloss Color' power or intensity." ,

        //Mask Gloss [41]
        "Mask Gloss.\n\nWhite means visible Gloss while black is not." ,

        //Gloss Texture [42]
        "A Black and White or Grayscale texture to be used as gloss.\n\nWhite means gloss while Black is not." ,

        //Softness [43] [Gloss Texture]
        "The softness of the 'Gloss Texture'." ,

        //Pattern Style [44] [Gloss Texture]
        "Turn 'Gloss Texture' into pattern style." ,

        //Follow Object Rotation [45] [Gloss Texture]
        "'Gloss Texture' will follow the object local rotation." ,

        //Follow Light [46] [Gloss Texture]
        "'Gloss Texture' will follow the light direction or position." ,

        //Overall Shadow Color [47]
        "Overall shadow color.\n\nThis will affect Realtime Shadow, Self Shadow/Shade and ShadowT." ,

        //Overall Shadow Color Power [48]
        "'Overall shadow Color' power or intensity." ,

        //Self Shadow & ShadowT At View Direction [49]
        "'Self Shadow' and 'ShadowT' follow your view or camera view direction." ,

        //Threshold [50] [Self Shadow]
        "The amount of 'Self Shadow/Shade' on the object." ,

        //Vertex Color Green Control Self Shadow Threshold [51]
        "Controls 'Self Shadow Threshold' by using vertex color Green." ,

        //Hardness [52] [Self Shadow]
        "'Self Shadow/Shade' hardness." ,

        //Self Shadow & Real Time Shadow Color [53]
        "'Self Shadow and Real Time Shadow Color'.\n\nBefore you set/change this, Set 'Overall Shadow Color' to White." ,

        //Self Shadow & Real Time Shadow Color Power [54]
        "'Self Shadow and Real Time Shadow Color' power or intensity." ,

        //Smooth Object Normal [55]
        "The amount of smooth object normal." ,

        //Vertex Color Red Control Smooth Object Normal [56]
        "'Vertex color Red' controls the amount of smooth object normal.\n\n*Red means 1 while Black means 0." ,

        //XYZ Position [57] [Smooth Object Normal]
        "Normal's XYZ positions." ,

        //XYZ Hardness [58] [Smooth Object Normal]
        "Normal's XYZ hardness.\n\nHigher value is better." ,

        //Show Normal [59] [Smooth Object Normal]
        "Show the normal of the object." ,

        //Shadow Color Texture [60]
        "A texture to color shadow.\n\nThis includes (RealTime Shadow, Self Shadow/Shade and ShadowT.\nYou can also use your 'Main/Base Texture' and adjust 'Power' to make it dark." ,

        //Power [61] [Shadow Color Texture]
        "How strong or dark the 'Shadow Color Texture'." ,

        //ShadowT [62]
        "ShadowT or Shadow Texture, shadows in texture form.\n\nUse Black or Gray and White Flat, Gradient and Smooth texture map.\nGray and White affected by light while Black is not.\n\nFor more info and how to use and make ShadowT texture maps, see 'Video Tutorials' and 'User Guide.pdf' at the bottom of this RealToon inspector.",

        //Light Threshold [63] [ShadowT]
        "The amount of light." ,

        //Shadow Threshold [64] [ShadowT]
        "The amount of ShadowT." ,

        //Hardness [65] [ShadowT]
        "'ShadowT' hardness." ,

        //Color [66] [ShadowT]
        "'ShadowT' color." ,

        //Color Power [67] [ShadowT]
        "'ShadowT' color power or intensity.",

        //Ignore Light [68] [ShadowT]
        "'ShadowT' ignore direction light or light position.",

        //Light Falloff Affect ShadowT [69]
        "'Point light' and 'Spot Light' light falloff affect 'ShadowT'." ,

        //PTexture [70]
        "A Black and White texture to be used as pattern for shadow.\n\nBlack means pattern while White is nothing.\nThis will not be visible if the shadow color is Black.",

        //Power [71] [PTexture]
        "How strong or dark the pattern is." ,

        //Directional Light Intensity [72] [Lighting]
        "Directional Light intensity received on the object." ,

        //Point and Spot Light Intensity [73] [Lighting]
        "Point and Spot light intensity received on the object." ,

        //Receive Environmental Ligthing and GI [74] [Lighting]
        "Turn on or off receive 'Environmental Ligthing' or 'GI'." ,

        //Use Old Ambient Light [75] [Lighting]
        "Use the old unity ambient light." ,

        //Light Falloff Softness [76] [Lighting]
        "How soft is the point and spot light light falloff." ,

        //Intensity [77] [Custom Light Direction]
        "The amount of custom light direction." ,

        //Custom Light Direction [78] [Custom Light Direction]
        "XYZ light position." ,

        //Follow Object Rotation [79] [Custom Light Direction]
        "'Custom Light Direction' follow object rotation." ,

        //Intensity [80] [Reflection]
        "The amount reflection visibility." ,

        //FReflection [81]
        "A texture to be used as reflection." ,

        //Roughtness [82] [Reflection]
        "'Reflection' roughtness." ,
        
        //Metallic [83] [Reflection]
        "The amount of reflection metallic look." ,
        
        //Mask Reflection [84]
        "Mask Reflection.\n\nWhite means visible relfection while Black means reflection not visible." ,

        //Unfill [85] [Rim Light]
        "Unfill 'Rim Light' on the object." ,

        //Softness [86] [Rim Light]
        "'Rim Light' softness." ,

        //Light Affect Rim Light [87] [Rim Light]
        "Light (Brightness and Color) affect 'Rim Light'." ,

        //Color [88] [Rim Light]
        "'Rim Light' color." ,

        //Color Power [89] [Rim Light]
        "'Rim Light Color' power or intensity." ,

        //Rim Light In Light [90]
        "'Rim Light' will be visible in light only." ,

        //ID [91] [See Through]
        "ID or reference value." ,

        //Set A [92] [See Through]
        "'A' The see through object while 'B' is the object to be seen through A'." ,

        //Set B [93] [See Through]
        "'A' The see through object while 'B' is the object to be seen through A'." ,

        //Hide Point & Spot Light Shadow [94]
        "Hide received 'Point and Spot Light' shadows on the object." ,

        //ZWrite [95] [Transparency]
        "Turn on or off ZWrite." ,

        //Automatic Remove Unused Shader Keywords [96]
        "Remove unused shader keywords automatically in all materials with Realtoon Shader. This will take effect once this enabled and when the RealToon Inspector shown. Disable this if you experience too slow Inspector.\n\n(Warning: This will also remove stored previous shaders shader keywords.)",

    };

        #endregion

        #region TOTIPS for EnDisFeatures

        string[] TOTIPSEDF =
        {
        //MatCap [0]
        "MatCap or Material Capture.",

        //Normal Map [1]
        "Normal Map.",

        //Outline [2]
        "Outline.",

        //SelfLit [3]
        "Own light or Emission.",

        //Gloss [4]
        "Gloss.",

        //Gloss Texture [5]
        "Gloss in texture form.\n\nUse a Black and White texture map.\nWhite means gloss while Black is not.",

        //Self Shadow [6]
        "Self Shadow or Shade.",

        //Smooth Object Normal [7]
        "Smooth object normal or ignore object normal.",

        //Shadow Color Texture [8]
        "Color shadow using texture.",

        //ShadowT [9]
        "ShadowT or Shadow Texture, shadows in texture form.\n\nUse Black or Gray and White Flat, Gradient and Smooth texture map.\nGray and White affected by light while Black is not.\n\nFor more info and how to use and make ShadowT texture maps, see 'Video Tutorials' and 'User Guide.pdf' at the bottom of this RealToon inspector.",

        //PTexture [10]
        "PTexture or Pattern Texture.\n\nA Black and White texture to be used as pattern for shadow.\n\nBlack means pattern while White is nothing.\nThis will not be visible if the shadow color is Black.",

        //Custom Light Direction [11]
        "Custom light direction.",

        //FReflection [12]
        "FReflection or Fake Reflection.\n\nUse any texture or image as reflection.",

        //Rim Light [13]
        "Rim light or fresnel effect."

    };

        #endregion

        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            //This Material
            Material targetMat = materialEditor.target as Material;

            //Settings
            materialEditor.SetDefaultGUIWidths();

            //Content

            #region Shader Name Switch

            switch (targetMat.shader.name)
            {
                case "RealToon/Version 5/Lite/Default":
                    shader_name = "lite_d";
                    shader_type = "Default";
                    break;

                case "RealToon/Version 5/Lite/Fade Transparency":
                    shader_name = "lite_ft";
                    shader_type = "Fade Transperancy";
                    break;
                default:
                    shader_name = string.Empty;
                    shader_type = string.Empty;
                    break;
            }

            #endregion

            #region Material Properties


            _DoubleSided = ShaderGUI.FindProperty("_DoubleSided", properties);

            _MainTex = ShaderGUI.FindProperty("_MainTex", properties);
            _MainColor = ShaderGUI.FindProperty("_MainColor", properties);

            _MVCOL = ShaderGUI.FindProperty("_MVCOL", properties);

            _MCIALO = ShaderGUI.FindProperty("_MCIALO", properties);

            _MCapIntensity = ShaderGUI.FindProperty("_MCapIntensity", properties);
            _MCap = ShaderGUI.FindProperty("_MCap", properties);
            _SPECMODE = ShaderGUI.FindProperty("_SPECMODE", properties);
            _SPECIN = ShaderGUI.FindProperty("_SPECIN", properties);
            _MCapMask = ShaderGUI.FindProperty("_MCapMask", properties);

            if (shader_name == "lite_d")
            {
                _EnableTextureTransparent = ShaderGUI.FindProperty("_EnableTextureTransparent", properties);
                _Opacity = null;
                _AffectShadow = null;
                _MaskTransparency = null;
            }
            else if (shader_name == "lite_ft")
            {
                _EnableTextureTransparent = null;
                _Opacity = ShaderGUI.FindProperty("_Opacity", properties);
                _TransparentThreshold = ShaderGUI.FindProperty("_TransparentThreshold", properties);
                _AffectShadow = ShaderGUI.FindProperty("_AffectShadow", properties);
                _MaskTransparency = ShaderGUI.FindProperty("_MaskTransparency", properties);
            }

            _NormalMap = ShaderGUI.FindProperty("_NormalMap", properties);
            _NormalMapIntensity = ShaderGUI.FindProperty("_NormalMapIntensity", properties);

            if (shader_name == "lite_d")
            {
                _OutlineWidth = ShaderGUI.FindProperty("_OutlineWidth", properties);
                _OutlineWidthControl = ShaderGUI.FindProperty("_OutlineWidthControl", properties);
                _OutlineExtrudeMethod = ShaderGUI.FindProperty("_OutlineExtrudeMethod", properties);
                _OutlineOffset = ShaderGUI.FindProperty("_OutlineOffset", properties);
                _OutlineZPostionInCamera = ShaderGUI.FindProperty("_OutlineZPostionInCamera", properties);
                _DoubleSidedOutline = ShaderGUI.FindProperty("_DoubleSidedOutline", properties);
                _OutlineColor = ShaderGUI.FindProperty("_OutlineColor", properties);
                _MixMainTexToOutline = ShaderGUI.FindProperty("_MixMainTexToOutline", properties);
                _OutlineWidthAffectedByViewDistance = ShaderGUI.FindProperty("_OutlineWidthAffectedByViewDistance", properties);
                _FarDistanceMaxWidth = ShaderGUI.FindProperty("_FarDistanceMaxWidth", properties);
                _VertexColorBlueAffectOutlineWitdh = ShaderGUI.FindProperty("_VertexColorBlueAffectOutlineWitdh", properties);
                _LightAffectOutlineColor = ShaderGUI.FindProperty("_LightAffectOutlineColor", properties);

            }
            else if (shader_name == "lite_ft")
            {
                _OutlineWidth = null;
                _OutlineWidthControl = null;
                _OutlineExtrudeMethod = null;
                _OutlineOffset = null;
                _OutlineZPostionInCamera = null;
                _DoubleSidedOutline = null;
                _OutlineColor = null;
                _MixMainTexToOutline = null;
                _OutlineWidthAffectedByViewDistance = null;
                _FarDistanceMaxWidth = null;
                _LightAffectOutlineColor = null;
                _VertexColorBlueAffectOutlineWitdh = null;
            }

            _SelfLitIntensity = ShaderGUI.FindProperty("_SelfLitIntensity", properties);
            _SelfLitColor = ShaderGUI.FindProperty("_SelfLitColor", properties);
            _SelfLitPower = ShaderGUI.FindProperty("_SelfLitPower", properties);
            _TEXMCOLINT = ShaderGUI.FindProperty("_TEXMCOLINT", properties);
            _SelfLitHighContrast = ShaderGUI.FindProperty("_SelfLitHighContrast", properties);
            _MaskSelfLit = ShaderGUI.FindProperty("_MaskSelfLit", properties);

            _Glossiness = ShaderGUI.FindProperty("_Glossiness", properties);
            _GlossSoftness = ShaderGUI.FindProperty("_GlossSoftness", properties);
            _GlossColor = ShaderGUI.FindProperty("_GlossColor", properties);
            _GlossColorPower = ShaderGUI.FindProperty("_GlossColorPower", properties);
            _MaskGloss = ShaderGUI.FindProperty("_MaskGloss", properties);

            _GlossTexture = ShaderGUI.FindProperty("_GlossTexture", properties);
            _GlossTextureSoftness = ShaderGUI.FindProperty("_GlossTextureSoftness", properties);
            _PSGLOTEX = ShaderGUI.FindProperty("_PSGLOTEX", properties);
            _GlossTextureFollowObjectRotation = ShaderGUI.FindProperty("_GlossTextureFollowObjectRotation", properties);
            _GlossTextureFollowLight = ShaderGUI.FindProperty("_GlossTextureFollowLight", properties);

            _OverallShadowColor = ShaderGUI.FindProperty("_OverallShadowColor", properties);
            _OverallShadowColorPower = ShaderGUI.FindProperty("_OverallShadowColorPower", properties);
            _SelfShadowShadowTAtViewDirection = ShaderGUI.FindProperty("_SelfShadowShadowTAtViewDirection", properties);

            _HighlightColor = ShaderGUI.FindProperty("_HighlightColor", properties);
            _HighlightColorPower = ShaderGUI.FindProperty("_HighlightColorPower", properties);

            _SelfShadowThreshold = ShaderGUI.FindProperty("_SelfShadowThreshold", properties);
            _VertexColorGreenControlSelfShadowThreshold = ShaderGUI.FindProperty("_VertexColorGreenControlSelfShadowThreshold", properties);
            _SelfShadowHardness = ShaderGUI.FindProperty("_SelfShadowHardness", properties);

            if (shader_name == "lite_d")
            {
                _SelfShadowRealTimeShadowColor = ShaderGUI.FindProperty("_SelfShadowRealTimeShadowColor", properties);
                _SelfShadowRealTimeShadowColorPower = ShaderGUI.FindProperty("_SelfShadowRealTimeShadowColorPower", properties);
            }
            else if (shader_name == "lite_ft")
            {
                _SelfShadowRealTimeShadowColor = ShaderGUI.FindProperty("_SelfShadowColor", properties);
                _SelfShadowRealTimeShadowColorPower = ShaderGUI.FindProperty("_SelfShadowColorPower", properties);
            }

            _SmoothObjectNormal = ShaderGUI.FindProperty("_SmoothObjectNormal", properties);
            _VertexColorRedControlSmoothObjectNormal = ShaderGUI.FindProperty("_VertexColorRedControlSmoothObjectNormal", properties);
            _XYZPosition = ShaderGUI.FindProperty("_XYZPosition", properties);
            _XYZHardness = ShaderGUI.FindProperty("_XYZHardness", properties);
            _ShowNormal = ShaderGUI.FindProperty("_ShowNormal", properties);

            _ShadowColorTexture = ShaderGUI.FindProperty("_ShadowColorTexture", properties);
            _ShadowColorTexturePower = ShaderGUI.FindProperty("_ShadowColorTexturePower", properties);

            _ShadowT = ShaderGUI.FindProperty("_ShadowT", properties);
            _ShadowTLightThreshold = ShaderGUI.FindProperty("_ShadowTLightThreshold", properties);
            _ShadowTShadowThreshold = ShaderGUI.FindProperty("_ShadowTShadowThreshold", properties);
            _ShadowTColor = ShaderGUI.FindProperty("_ShadowTColor", properties);
            _ShadowTColorPower = ShaderGUI.FindProperty("_ShadowTColorPower", properties);
            _ShadowTHardness = ShaderGUI.FindProperty("_ShadowTHardness", properties);
            _STIL = ShaderGUI.FindProperty("_STIL", properties);
            _LightFalloffAffectShadowT = ShaderGUI.FindProperty("_LightFalloffAffectShadowT", properties);

            _PTexture = ShaderGUI.FindProperty("_PTexture", properties);
            _PTexturePower = ShaderGUI.FindProperty("_PTexturePower", properties);

            _DirectionalLightIntensity = ShaderGUI.FindProperty("_DirectionalLightIntensity", properties);
            _PointSpotlightIntensity = ShaderGUI.FindProperty("_PointSpotlightIntensity", properties);
            _LightFalloffSoftness = ShaderGUI.FindProperty("_LightFalloffSoftness", properties);

            _CustomLightDirectionIntensity = ShaderGUI.FindProperty("_CustomLightDirectionIntensity", properties);
            _CustomLightDirectionFollowObjectRotation = ShaderGUI.FindProperty("_CustomLightDirectionFollowObjectRotation", properties);
            _CustomLightDirection = ShaderGUI.FindProperty("_CustomLightDirection", properties);

            _FReflectionIntensity = ShaderGUI.FindProperty("_FReflectionIntensity", properties);
            _FReflection = ShaderGUI.FindProperty("_FReflection", properties);
            _FReflectionRoughtness = ShaderGUI.FindProperty("_FReflectionRoughtness", properties);
            _RefMetallic = ShaderGUI.FindProperty("_RefMetallic", properties);
            _MaskFReflection = ShaderGUI.FindProperty("_MaskFReflection", properties);

            _RimLightUnfill = ShaderGUI.FindProperty("_RimLightUnfill", properties);
            _RimLightColor = ShaderGUI.FindProperty("_RimLightColor", properties);
            _RimLightColorPower = ShaderGUI.FindProperty("_RimLightColorPower", properties);
            _LightAffectRimLightColor = ShaderGUI.FindProperty("_LightAffectRimLightColor", properties);
            _RimLightSoftness = ShaderGUI.FindProperty("_RimLightSoftness", properties);
            _RimLightInLight = ShaderGUI.FindProperty("_RimLightInLight", properties);

            _RefVal = ShaderGUI.FindProperty("_RefVal", properties);
            _Oper = ShaderGUI.FindProperty("_Oper", properties);
            _Compa = ShaderGUI.FindProperty("_Compa", properties);

            _L_F_MC = ShaderGUI.FindProperty("_L_F_MC", properties);

            _L_F_NM = ShaderGUI.FindProperty("_L_F_NM", properties);

            if (shader_name == "lite_d")
            {
                _L_F_O = ShaderGUI.FindProperty("_L_F_O", properties);
            }

            _L_F_SL = ShaderGUI.FindProperty("_L_F_SL", properties);
            _L_F_GLO = ShaderGUI.FindProperty("_L_F_GLO", properties);
            _L_F_GLOT = ShaderGUI.FindProperty("_L_F_GLOT", properties);
            _L_F_SS = ShaderGUI.FindProperty("_L_F_SS", properties);
            _L_F_SON = ShaderGUI.FindProperty("_L_F_SON", properties);
            _L_F_SCT = ShaderGUI.FindProperty("_L_F_SCT", properties);
            _L_F_ST = ShaderGUI.FindProperty("_L_F_ST", properties);
            _L_F_PT = ShaderGUI.FindProperty("_L_F_PT", properties);
            _RELG = ShaderGUI.FindProperty("_RELG", properties);
            _L_F_UOAL = ShaderGUI.FindProperty("_L_F_UOAL", properties);
            _L_F_CLD = ShaderGUI.FindProperty("_L_F_CLD", properties);
            _L_F_FR = ShaderGUI.FindProperty("_L_F_FR", properties);
            _L_F_RL = ShaderGUI.FindProperty("_L_F_RL", properties);

            if (shader_name == "lite_d")
            {
                _L_F_HPSS = ShaderGUI.FindProperty("_L_F_HPSS", properties);
                _ZWrite = null;
            }
            else if (shader_name == "lite_ft")
            {
                _L_F_HPSS = null;
                _ZWrite = ShaderGUI.FindProperty("_ZWrite", properties);
            }

            #endregion

            //UI

            #region UI

            //Header
            Rect r_header = EditorGUILayout.BeginVertical("HelpBox");
            EditorGUILayout.LabelField("RealToon Lite 5.0.8", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("(" + shader_type + ")", EditorStyles.boldLabel);
            EditorGUILayout.EndVertical();

            if (ShowUI == true)
            {

                GUILayout.Space(20);


                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                //Light Blend

                #region Light Blend

                Rect r_lightblend = EditorGUILayout.BeginVertical("HelpBox");
                EditorGUILayout.LabelField("Light Blend Style: Traditional");
                EditorGUILayout.EndVertical();

                #endregion

                //Double Sided

                #region Double Sided

                Rect r_doublesided = EditorGUILayout.BeginVertical("HelpBox");
                materialEditor.ShaderProperty(_DoubleSided, new GUIContent(_DoubleSided.displayName, TOTIPS[0]));
                EditorGUILayout.EndVertical();

                #endregion

                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                GUILayout.Space(20);

                //Texture - Color

                #region Texture - Color

                Rect r_texturecolor = EditorGUILayout.BeginVertical("Button");
                ShowTextureColor = EditorGUILayout.Foldout(ShowTextureColor, "(Texture - Color)", true, EditorStyles.foldout);

                if (ShowTextureColor)
                {
                    GUILayout.Space(10);

                    materialEditor.ShaderProperty(_MainTex, new GUIContent(_MainTex.displayName, TOTIPS[1]));
                    materialEditor.ShaderProperty(_MainColor, new GUIContent(_MainColor.displayName, TOTIPS[2]));
                    materialEditor.ShaderProperty(_MVCOL, new GUIContent(_MVCOL.displayName, TOTIPS[3]));

                    GUILayout.Space(10);
                    materialEditor.ShaderProperty(_MCIALO, new GUIContent(_MCIALO.displayName, TOTIPS[4]));

                    GUILayout.Space(10);

                    materialEditor.ShaderProperty(_HighlightColor, new GUIContent(_HighlightColor.displayName, TOTIPS[5]));
                    materialEditor.ShaderProperty(_HighlightColorPower, new GUIContent(_HighlightColorPower.displayName, TOTIPS[6]));

                    GUILayout.Space(10);

                    if (shader_name != "lite_ft")
                    {
                        EditorGUI.BeginDisabledGroup(_MainTex.textureValue == null);
                        materialEditor.ShaderProperty(_EnableTextureTransparent, new GUIContent(_EnableTextureTransparent.displayName, TOTIPS[7]));
                        EditorGUI.EndDisabledGroup();
                    }
                    else
                    {
                        _EnableTextureTransparent = null;
                    }

                    ShowTextureColor = true;
                }

                EditorGUILayout.EndVertical();

                #endregion

                //MatCap

                #region MatCap

                if (_L_F_MC.floatValue == 1)
                {
                    EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                    Rect r_matcap = EditorGUILayout.BeginVertical("Button");
                    ShowMatCap = EditorGUILayout.Foldout(ShowMatCap, "(MatCap)", true, EditorStyles.foldout);

                    if (ShowMatCap)
                    {

                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_MCapIntensity, new GUIContent(_MCapIntensity.displayName, TOTIPS[8]));
                        materialEditor.ShaderProperty(_MCap, new GUIContent(_MCap.displayName, TOTIPS[9]));

                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_SPECMODE, new GUIContent(_SPECMODE.displayName, TOTIPS[10]));
                        EditorGUI.BeginDisabledGroup(_SPECMODE.floatValue == 0);
                        materialEditor.ShaderProperty(_SPECIN, new GUIContent(_SPECIN.displayName, TOTIPS[11]));
                        EditorGUI.EndDisabledGroup();

                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_MCapMask, new GUIContent(_MCapMask.displayName, TOTIPS[12]));

                    }

                    EditorGUILayout.EndVertical();
                }

                #endregion

                //Normal Map

                #region Normal Map

                if (_L_F_NM.floatValue == 1)
                {

                    EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                    Rect r_normalmap = EditorGUILayout.BeginVertical("Button");
                    ShowNormalMap = EditorGUILayout.Foldout(ShowNormalMap, "(Normal Map)", true, EditorStyles.foldout);

                    if (ShowNormalMap)
                    {
                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_NormalMap, new GUIContent(_NormalMap.displayName, TOTIPS[17]));

                        EditorGUI.BeginDisabledGroup(_NormalMap.textureValue == null);
                        materialEditor.ShaderProperty(_NormalMapIntensity, new GUIContent(_NormalMapIntensity.displayName, TOTIPS[18]));
                        EditorGUI.EndDisabledGroup();

                    }

                    EditorGUILayout.EndVertical();

                }

                #endregion

                //Transperancy

                #region Transperancy

                if (shader_name == "lite_ft")
                {
                    EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                    Rect r_transparency = EditorGUILayout.BeginVertical("Button");
                    ShowTransparency = EditorGUILayout.Foldout(ShowTransparency, "(Transparency)", true, EditorStyles.foldout);

                    if (ShowTransparency)
                    {
                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_Opacity, new GUIContent(_Opacity.displayName, TOTIPS[13]));
                        materialEditor.ShaderProperty(_TransparentThreshold, new GUIContent(_TransparentThreshold.displayName, TOTIPS[14]));

                        GUILayout.Space(10);
                        materialEditor.ShaderProperty(_AffectShadow, new GUIContent(_AffectShadow.displayName, TOTIPS[15]));

                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_MaskTransparency, new GUIContent(_MaskTransparency.displayName, TOTIPS[16]));

                    }

                    EditorGUILayout.EndVertical();
                }

                #endregion

                //Outline

                #region Outline

                if (shader_name == "lite_d")
                {
                    if (_L_F_O.floatValue == 1)
                    {

                        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                        Rect r_outline = EditorGUILayout.BeginVertical("Button");
                        ShowOutline = EditorGUILayout.Foldout(ShowOutline, "(Outline)", true, EditorStyles.foldout);


                        if (ShowOutline)
                        {
                            GUILayout.Space(10);

                            materialEditor.ShaderProperty(_OutlineWidth, new GUIContent(_OutlineWidth.displayName, TOTIPS[19]));

                            materialEditor.ShaderProperty(_OutlineWidthControl, new GUIContent(_OutlineWidthControl.displayName, TOTIPS[20]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_OutlineExtrudeMethod, new GUIContent(_OutlineExtrudeMethod.displayName, TOTIPS[21]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_OutlineOffset, new GUIContent(_OutlineOffset.displayName, TOTIPS[22]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_OutlineZPostionInCamera, new GUIContent(_OutlineZPostionInCamera.displayName, TOTIPS[23]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_DoubleSidedOutline, new GUIContent(_DoubleSidedOutline.displayName, TOTIPS[24]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_OutlineColor, new GUIContent(_OutlineColor.displayName, TOTIPS[25]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_MixMainTexToOutline, new GUIContent(_MixMainTexToOutline.displayName, TOTIPS[26]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_LightAffectOutlineColor, new GUIContent(_LightAffectOutlineColor.displayName, TOTIPS[27]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_OutlineWidthAffectedByViewDistance, new GUIContent(_OutlineWidthAffectedByViewDistance.displayName, TOTIPS[28]));
                            EditorGUI.BeginDisabledGroup(_OutlineWidthAffectedByViewDistance.floatValue == 0);
                            materialEditor.ShaderProperty(_FarDistanceMaxWidth, new GUIContent(_FarDistanceMaxWidth.displayName, TOTIPS[29]));
                            EditorGUI.EndDisabledGroup();

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_VertexColorBlueAffectOutlineWitdh, new GUIContent(_VertexColorBlueAffectOutlineWitdh.displayName, TOTIPS[30]));

                        }

                        EditorGUILayout.EndVertical();

                    }

                }

                #endregion

                //Self Lit

                #region SelfLit

                if (_L_F_SL.floatValue == 1)
                {

                    EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                    Rect r_selflit = EditorGUILayout.BeginVertical("Button");
                    ShowSelfLit = EditorGUILayout.Foldout(ShowSelfLit, "(Self Lit)", true, EditorStyles.foldout);

                    if (ShowSelfLit)
                    {

                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_SelfLitIntensity, new GUIContent(_SelfLitIntensity.displayName, TOTIPS[31]));

                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_SelfLitColor, new GUIContent(_SelfLitColor.displayName, TOTIPS[32]));
                        materialEditor.ShaderProperty(_SelfLitPower, new GUIContent(_SelfLitPower.displayName, TOTIPS[33]));

                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_TEXMCOLINT, new GUIContent(_TEXMCOLINT.displayName, TOTIPS[34]));

                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_SelfLitHighContrast, new GUIContent(_SelfLitHighContrast.displayName, TOTIPS[35]));

                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_MaskSelfLit, new GUIContent(_MaskSelfLit.displayName, TOTIPS[36]));

                    }

                    EditorGUILayout.EndVertical();

                }
                #endregion

                //Gloss

                #region Gloss

                if (_L_F_GLO.floatValue == 1)
                {
                    EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                    Rect r_gloss = EditorGUILayout.BeginVertical("Button");
                    ShowGloss = EditorGUILayout.Foldout(ShowGloss, "(Gloss)", true, EditorStyles.foldout);

                    if (ShowGloss)
                    {
                        GUILayout.Space(10);

                        EditorGUI.BeginDisabledGroup(_L_F_GLOT.floatValue == 1);
                        materialEditor.ShaderProperty(_Glossiness, new GUIContent(_Glossiness.displayName, TOTIPS[37]));
                        materialEditor.ShaderProperty(_GlossSoftness, new GUIContent(_GlossSoftness.displayName, TOTIPS[38]));
                        EditorGUI.EndDisabledGroup();

                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_GlossColor, new GUIContent(_GlossColor.displayName, TOTIPS[39]));
                        materialEditor.ShaderProperty(_GlossColorPower, new GUIContent(_GlossColorPower.displayName, TOTIPS[40]));

                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_MaskGloss, new GUIContent(_MaskGloss.displayName, TOTIPS[41]));

                        GUILayout.Space(10);

                        //Gloss Texture

                        #region Gloss Texture

                        if (_L_F_GLOT.floatValue == 1)
                        {

                            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                            Rect r_glosstexture = EditorGUILayout.BeginVertical("Button");
                            GUILayout.Label("Gloss Texture", EditorStyles.boldLabel);
                            EditorGUILayout.EndVertical();

                            if (_L_F_GLOT.floatValue == 1)
                            {
                                GUILayout.Space(10);

                                materialEditor.ShaderProperty(_GlossTexture, new GUIContent(_GlossTexture.displayName, TOTIPS[42]));

                                GUILayout.Space(10);
                                EditorGUI.BeginDisabledGroup(_GlossTexture.textureValue == null);
                                materialEditor.ShaderProperty(_GlossTextureSoftness, new GUIContent(_GlossTextureSoftness.displayName, TOTIPS[43]));

                                GUILayout.Space(10);

                                materialEditor.ShaderProperty(_PSGLOTEX, new GUIContent(_PSGLOTEX.displayName, TOTIPS[44]));

                                GUILayout.Space(10);

                                EditorGUI.BeginDisabledGroup(_PSGLOTEX.floatValue == 1);
                                materialEditor.ShaderProperty(_GlossTextureFollowObjectRotation, new GUIContent(_GlossTextureFollowObjectRotation.displayName, TOTIPS[45]));
                                materialEditor.ShaderProperty(_GlossTextureFollowLight, new GUIContent(_GlossTextureFollowLight.displayName, TOTIPS[46]));
                                EditorGUI.EndDisabledGroup();

                                EditorGUI.EndDisabledGroup();

                            }


                        }

                        #endregion


                    }

                    EditorGUILayout.EndVertical();

                }
                #endregion

                //Shadow

                #region Shadow

                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                Rect r_shadow = EditorGUILayout.BeginVertical("Button");
                ShowShadow = EditorGUILayout.Foldout(ShowShadow, "(Shadow)", true, EditorStyles.foldout);

                if (ShowShadow)
                {

                    GUILayout.Space(10);

                    materialEditor.ShaderProperty(_OverallShadowColor, new GUIContent(_OverallShadowColor.displayName, TOTIPS[47]));
                    materialEditor.ShaderProperty(_OverallShadowColorPower, new GUIContent(_OverallShadowColorPower.displayName, TOTIPS[48]));

                    GUILayout.Space(10);

                    materialEditor.ShaderProperty(_SelfShadowShadowTAtViewDirection, new GUIContent(_SelfShadowShadowTAtViewDirection.displayName, TOTIPS[49]));

                    //Self Shadow

                    #region Self Shadow

                    if (_L_F_SS.floatValue == 1)
                    {

                        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                        Rect r_selfshadow = EditorGUILayout.BeginVertical("Button");
                        GUILayout.Label("Self Shadow", EditorStyles.boldLabel);
                        EditorGUILayout.EndVertical();

                        if (_L_F_SS.floatValue == 1)
                        {

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_SelfShadowThreshold, new GUIContent(_SelfShadowThreshold.displayName, TOTIPS[50]));
                            materialEditor.ShaderProperty(_VertexColorGreenControlSelfShadowThreshold, new GUIContent(_VertexColorGreenControlSelfShadowThreshold.displayName, TOTIPS[51]));
                            materialEditor.ShaderProperty(_SelfShadowHardness, new GUIContent(_SelfShadowHardness.displayName, TOTIPS[52]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_SelfShadowRealTimeShadowColor, new GUIContent(_SelfShadowRealTimeShadowColor.displayName, TOTIPS[53]));
                            materialEditor.ShaderProperty(_SelfShadowRealTimeShadowColorPower, new GUIContent(_SelfShadowRealTimeShadowColorPower.displayName, TOTIPS[54]));

                        }

                    }
                    #endregion

                    //Smooth Object Normal

                    #region Smooth Object normal

                    if (_L_F_SON.floatValue == 1)
                    {

                        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                        if (_L_F_SS.floatValue == 0)
                        {
                            _L_F_SON.floatValue = 0;
                            targetMat.DisableKeyword("F_SS_ON");
                            _ShowNormal.floatValue = 0;
                        }

                        Rect r_smoothobjectnormal = EditorGUILayout.BeginVertical("Button");
                        GUILayout.Label("Smooth Object Normal", EditorStyles.boldLabel);
                        EditorGUILayout.EndVertical();

                        if (_L_F_SON.floatValue == 1)
                        {
                            GUILayout.Space(10);

                            materialEditor.ShaderProperty(_SmoothObjectNormal, new GUIContent(_SmoothObjectNormal.displayName, TOTIPS[55]));
                            materialEditor.ShaderProperty(_VertexColorRedControlSmoothObjectNormal, new GUIContent(_VertexColorRedControlSmoothObjectNormal.displayName, TOTIPS[56]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_XYZPosition, new GUIContent(_XYZPosition.displayName, TOTIPS[57]));
                            materialEditor.ShaderProperty(_XYZHardness, new GUIContent(_XYZHardness.displayName, TOTIPS[58]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_ShowNormal, new GUIContent(_ShowNormal.displayName, TOTIPS[59]));

                        }

                    }
                    #endregion

                    //Shadow Color Texture

                    #region Shadow Color Texture

                    if (_L_F_SCT.floatValue == 1)
                    {
                        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                        Rect r_shadowcolortexture = EditorGUILayout.BeginVertical("Button");
                        GUILayout.Label("Shadow Color Texture", EditorStyles.boldLabel);
                        EditorGUILayout.EndVertical();

                        if (_L_F_SCT.floatValue == 1)
                        {
                            GUILayout.Space(10);

                            materialEditor.ShaderProperty(_ShadowColorTexture, new GUIContent(_ShadowColorTexture.displayName, TOTIPS[60]));
                            materialEditor.ShaderProperty(_ShadowColorTexturePower, new GUIContent(_ShadowColorTexturePower.displayName, TOTIPS[61]));

                        }

                    }

                    #endregion

                    //ShadowT

                    #region ShadowT

                    if (_L_F_ST.floatValue == 1)
                    {
                        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                        Rect r_shadowt = EditorGUILayout.BeginVertical("Button");
                        GUILayout.Label("ShadowT", EditorStyles.boldLabel);
                        EditorGUILayout.EndVertical();

                        if (_L_F_ST.floatValue == 1)
                        {

                            GUILayout.Space(10);

                            materialEditor.ShaderProperty(_ShadowT, new GUIContent(_ShadowT.displayName, TOTIPS[62]));
                            materialEditor.ShaderProperty(_ShadowTLightThreshold, new GUIContent(_ShadowTLightThreshold.displayName, TOTIPS[63]));
                            materialEditor.ShaderProperty(_ShadowTShadowThreshold, new GUIContent(_ShadowTShadowThreshold.displayName, TOTIPS[64]));
                            materialEditor.ShaderProperty(_ShadowTHardness, new GUIContent(_ShadowTHardness.displayName, TOTIPS[65]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_ShadowTColor, new GUIContent(_ShadowTColor.displayName, TOTIPS[66]));
                            materialEditor.ShaderProperty(_ShadowTColorPower, new GUIContent(_ShadowTColorPower.displayName, TOTIPS[67]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_STIL, new GUIContent(_STIL.displayName, TOTIPS[68]));

                            GUILayout.Space(10);
                            materialEditor.ShaderProperty(_LightFalloffAffectShadowT, new GUIContent(_LightFalloffAffectShadowT.displayName, TOTIPS[69]));

                        }

                    }

                    #endregion

                    //Shadow PTexture

                    #region PTexture

                    if (_L_F_PT.floatValue == 1)
                    {
                        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                        Rect r_ptexture = EditorGUILayout.BeginVertical("Button");
                        GUILayout.Label("PTexture", EditorStyles.boldLabel);
                        EditorGUILayout.EndVertical();

                        if (_L_F_PT.floatValue == 1)
                        {
                            GUILayout.Space(10);

                            materialEditor.ShaderProperty(_PTexture, new GUIContent(_PTexture.displayName, TOTIPS[70]));
                            materialEditor.ShaderProperty(_PTexturePower, new GUIContent(_PTexturePower.displayName, TOTIPS[71]));
                        }

                    }

                    #endregion

                }

                EditorGUILayout.EndVertical();

                #endregion

                //Lighting

                #region Lighting

                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                Rect r_lighting = EditorGUILayout.BeginVertical("Button");
                ShowLighting = EditorGUILayout.Foldout(ShowLighting, "(Lighting)", true, EditorStyles.foldout);

                if (ShowLighting)
                {
                    GUILayout.Space(10);
                    materialEditor.ShaderProperty(_DirectionalLightIntensity, new GUIContent(_DirectionalLightIntensity.displayName, TOTIPS[72]));
                    materialEditor.ShaderProperty(_PointSpotlightIntensity, new GUIContent(_PointSpotlightIntensity.displayName, TOTIPS[73]));

                    GUILayout.Space(10);

                    materialEditor.ShaderProperty(_RELG, new GUIContent(_RELG.displayName, TOTIPS[74]));

                    EditorGUI.BeginDisabledGroup(_RELG.floatValue == 0);
                    materialEditor.ShaderProperty(_L_F_UOAL, new GUIContent(_L_F_UOAL.displayName, TOTIPS[75]));
                    EditorGUI.EndDisabledGroup();

                    GUILayout.Space(10);

                    materialEditor.ShaderProperty(_LightFalloffSoftness, new GUIContent(_LightFalloffSoftness.displayName, TOTIPS[76]));


                    //Custom Light Direction

                    #region Custom Light Direction

                    if (_L_F_CLD.floatValue == 1)
                    {

                        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                        EditorGUI.BeginDisabledGroup(_L_F_CLD.floatValue == 0);

                        Rect r_customlightdirection = EditorGUILayout.BeginVertical("Button");
                        GUILayout.Label("Custom Light Direction", EditorStyles.boldLabel);
                        EditorGUILayout.EndVertical();

                        if (_L_F_CLD.floatValue == 1)
                        {

                            GUILayout.Space(10);

                            materialEditor.ShaderProperty(_CustomLightDirectionIntensity, new GUIContent(_CustomLightDirectionIntensity.displayName, TOTIPS[77]));
                            materialEditor.ShaderProperty(_CustomLightDirection, new GUIContent(_CustomLightDirection.displayName, TOTIPS[78]));
                            materialEditor.ShaderProperty(_CustomLightDirectionFollowObjectRotation, new GUIContent(_CustomLightDirectionFollowObjectRotation.displayName, TOTIPS[79]));

                        }

                        EditorGUI.EndDisabledGroup();

                    }

                    #endregion
                }

                EditorGUILayout.EndVertical();

                #endregion

                //Reflection

                #region FReflection

                if (_L_F_FR.floatValue == 1)
                {

                    EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                    Rect r_freflection = EditorGUILayout.BeginVertical("Button");
                    ShowFReflection = EditorGUILayout.Foldout(ShowFReflection, "(Reflection)", true, EditorStyles.foldout);

                    if (ShowFReflection)
                    {

                        GUILayout.Space(10);

                        EditorGUI.BeginDisabledGroup(_FReflection.textureValue == null);
                        materialEditor.ShaderProperty(_FReflectionIntensity, new GUIContent(_FReflectionIntensity.displayName, TOTIPS[80]));
                        EditorGUI.EndDisabledGroup();

                        materialEditor.ShaderProperty(_FReflection, new GUIContent(_FReflection.displayName, TOTIPS[81]));

                        GUILayout.Space(10);

                        EditorGUI.BeginDisabledGroup(_FReflection.textureValue == null);
                        materialEditor.ShaderProperty(_FReflectionRoughtness, new GUIContent(_FReflectionRoughtness.displayName, TOTIPS[82]));
                        materialEditor.ShaderProperty(_RefMetallic, new GUIContent(_RefMetallic.displayName, TOTIPS[83]));
                        materialEditor.ShaderProperty(_MaskFReflection, new GUIContent(_MaskFReflection.displayName, TOTIPS[84]));
                        EditorGUI.EndDisabledGroup();

                        GUILayout.Space(10);

                    }

                    EditorGUILayout.EndVertical();

                }

                #endregion

                //Fresnel

                #region Rim Light

                if (_L_F_RL.floatValue == 1)
                {

                    EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                    Rect r_rimlight = EditorGUILayout.BeginVertical("Button");
                    ShowRimLight = EditorGUILayout.Foldout(ShowRimLight, "(Rim Light)", true, EditorStyles.foldout);

                    if (ShowRimLight)
                    {
                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_RimLightUnfill, new GUIContent(_RimLightUnfill.displayName, TOTIPS[85]));
                        materialEditor.ShaderProperty(_RimLightSoftness, new GUIContent(_RimLightSoftness.displayName, TOTIPS[86]));

                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_LightAffectRimLightColor, new GUIContent(_LightAffectRimLightColor.displayName, TOTIPS[87]));

                        GUILayout.Space(10);

                        materialEditor.ShaderProperty(_RimLightColor, new GUIContent(_RimLightColor.displayName, TOTIPS[88]));
                        materialEditor.ShaderProperty(_RimLightColorPower, new GUIContent(_RimLightColorPower.displayName, TOTIPS[89]));

                        GUILayout.Space(10);
                        materialEditor.ShaderProperty(_RimLightInLight, new GUIContent(_RimLightInLight.displayName, TOTIPS[90]));

                    }

                    EditorGUILayout.EndVertical();

                }

                #endregion

                //See Through

                #region See Through

                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                Rect r_seethrough = EditorGUILayout.BeginVertical("Button");
                ShowSeeThrough = EditorGUILayout.Foldout(ShowSeeThrough, "(See Through)", true, EditorStyles.foldout);

                if (ShowSeeThrough)
                {
                    GUILayout.Space(10);

                    materialEditor.ShaderProperty(_RefVal, new GUIContent(_RefVal.displayName, TOTIPS[91]));
                    materialEditor.ShaderProperty(_Oper, new GUIContent(_Oper.displayName, TOTIPS[92]));
                    materialEditor.ShaderProperty(_Compa, new GUIContent(_Compa.displayName, TOTIPS[93]));

                }

                EditorGUILayout.EndVertical();

                #endregion


                GUILayout.Space(20);

                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                //Disable/Enable Features

                #region Disable/Enable Features

                Rect r_disableenablefeature = EditorGUILayout.BeginVertical("Button");
                ShowDisableEnable = EditorGUILayout.Foldout(ShowDisableEnable, "(Disable/Enable Features)", true, EditorStyles.foldout);

                if (ShowDisableEnable)
                {
                    Rect r_mc = EditorGUILayout.BeginVertical("HelpBox");
                    materialEditor.ShaderProperty(_L_F_MC, new GUIContent(_L_F_MC.displayName, TOTIPSEDF[0]));
                    EditorGUILayout.EndVertical();

                    Rect r_nm = EditorGUILayout.BeginVertical("HelpBox");
                    materialEditor.ShaderProperty(_L_F_NM, new GUIContent(_L_F_NM.displayName, TOTIPSEDF[1]));
                    EditorGUILayout.EndVertical();

                    if (shader_name == "lite_d")
                    {
                        Rect r_co = EditorGUILayout.BeginVertical("HelpBox");

                        EditorGUI.BeginChangeCheck();

                        materialEditor.ShaderProperty(_L_F_O, new GUIContent(_L_F_O.displayName, TOTIPSEDF[2]));

                        if (EditorGUI.EndChangeCheck())
                        {
                            int f_o_int = (int)_L_F_O.floatValue;

                            foreach (Material m in materialEditor.targets)
                            {

                                switch (f_o_int)
                                {
                                    case 0:
                                        m.SetShaderPassEnabled("Always", false);
                                        break;
                                    case 1:
                                        m.SetShaderPassEnabled("Always", true);
                                        break;
                                    default:
                                        break;
                                }

                            }

                        }

                        EditorGUILayout.EndVertical();
                    }
                    else
                    {
                        _L_F_O = null;
                    }

                    Rect r_ca = EditorGUILayout.BeginVertical("HelpBox");
                    materialEditor.ShaderProperty(_L_F_SL, new GUIContent(_L_F_SL.displayName, TOTIPSEDF[3]));
                    EditorGUILayout.EndVertical();

                    Rect r_o = EditorGUILayout.BeginVertical("HelpBox");
                    materialEditor.ShaderProperty(_L_F_GLO, new GUIContent(_L_F_GLO.displayName, TOTIPSEDF[4]));
                    EditorGUILayout.EndVertical();

                    Rect r_sl = EditorGUILayout.BeginVertical("HelpBox");
                    materialEditor.ShaderProperty(_L_F_GLOT, new GUIContent(_L_F_GLOT.displayName, TOTIPSEDF[5]));
                    EditorGUILayout.EndVertical();

                    EditorGUI.BeginChangeCheck();

                    Rect r_glo = EditorGUILayout.BeginVertical("HelpBox");
                    materialEditor.ShaderProperty(_L_F_SS, new GUIContent(_L_F_SS.displayName, TOTIPSEDF[6]));
                    EditorGUILayout.EndVertical();

                    if (EditorGUI.EndChangeCheck())
                    {
                        int f_ss_int = (int)_L_F_SS.floatValue;
                        foreach (Material m in materialEditor.targets)
                        {
                            switch (f_ss_int)
                            {
                                case 0:
                                    m.DisableKeyword("L_F_SON_ON");
                                    _L_F_SON.floatValue = 0;
                                    break;
                                case 1:
                                    break;
                                default:
                                    break;
                            }
                        }

                    }

                    EditorGUI.BeginDisabledGroup(_L_F_SS.floatValue == 0);

                    Rect r_glot = EditorGUILayout.BeginVertical("HelpBox");
                    materialEditor.ShaderProperty(_L_F_SON, new GUIContent(_L_F_SON.displayName, TOTIPSEDF[7]));
                    EditorGUILayout.EndVertical();

                    EditorGUI.EndDisabledGroup();

                    Rect r_ss = EditorGUILayout.BeginVertical("HelpBox");
                    materialEditor.ShaderProperty(_L_F_SCT, new GUIContent(_L_F_SCT.displayName, TOTIPSEDF[8]));
                    EditorGUILayout.EndVertical();

                    Rect r_son = EditorGUILayout.BeginVertical("HelpBox");
                    materialEditor.ShaderProperty(_L_F_ST, new GUIContent(_L_F_ST.displayName, TOTIPSEDF[9]));
                    EditorGUILayout.EndVertical();

                    Rect r_sct = EditorGUILayout.BeginVertical("HelpBox");
                    materialEditor.ShaderProperty(_L_F_PT, new GUIContent(_L_F_PT.displayName, TOTIPSEDF[10]));
                    EditorGUILayout.EndVertical();

                    Rect r_st = EditorGUILayout.BeginVertical("HelpBox");
                    materialEditor.ShaderProperty(_L_F_CLD, new GUIContent(_L_F_CLD.displayName, TOTIPSEDF[11]));
                    EditorGUILayout.EndVertical();

                    Rect r_spt = EditorGUILayout.BeginVertical("HelpBox");
                    materialEditor.ShaderProperty(_L_F_FR, new GUIContent(_L_F_FR.displayName, TOTIPSEDF[12]));
                    EditorGUILayout.EndVertical();

                    Rect r_cld = EditorGUILayout.BeginVertical("HelpBox");
                    materialEditor.ShaderProperty(_L_F_RL, new GUIContent(_L_F_RL.displayName, TOTIPSEDF[13]));
                    EditorGUILayout.EndVertical();

                }

                EditorGUILayout.EndVertical();

                #endregion

                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                GUILayout.Space(10);

                if (shader_name == "lite_d")
                {
                    materialEditor.ShaderProperty(_L_F_HPSS, new GUIContent(_L_F_HPSS.displayName, TOTIPS[94]));
                }
                else if (shader_name == "lite_ft")
                {
                    materialEditor.ShaderProperty(_ZWrite, new GUIContent(_ZWrite.displayName, TOTIPS[95]));
                }

                GUILayout.Space(10);

                materialEditor.RenderQueueField();

                GUILayout.Space(10);

                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                GUILayout.Space(10);

                materialEditor.EnableInstancingField();
                aruskw = EditorGUILayout.Toggle(new GUIContent("Automatic Remove Unused Shader Keywords (Global)", TOTIPS[96]), aruskw);

                GUILayout.Space(10);

            }

            #region Automatic Remove UorOSKW
            if (aruskw == true)
            {
                foreach (Material m1 in materialEditor.targets)
                {
                    for (int x = 0; x < m1.shaderKeywords.Length; x++)
                    {
                        if (m1.shaderKeywords[x] != String.Empty)
                        {
                            for (int y = 0; y < Enum.GetValues(typeof(SFKW)).Length; y++)
                            {
                                if (m1.shaderKeywords[x] == Enum.GetValues(typeof(SFKW)).GetValue(y).ToString())
                                {
                                    del_skw = false;
                                    break;
                                }
                                else
                                {
                                    del_skw = true;
                                }
                            }

                            if (del_skw == true)
                            {
                                m1.DisableKeyword(m1.shaderKeywords[x]);
                                del_skw = false;
                            }

                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            #endregion

            //Footbar
            #region Footbar

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            Rect r_footbar = EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("| Video Tutorials |", "Toolbar"))
            {
                Application.OpenURL("www.youtube.com/playlist?list=PL0M1m9smMVPJ4qEkJnZObqJE5mU9uz6SY");
            }

            GUILayout.Space(5);

            if (GUILayout.Button("| RealToon (User Guide).pdf |", "Toolbar"))
            {
                Application.OpenURL(Application.dataPath + "/RealToon/RealToon (User Guide).pdf");
            }

            GUILayout.Space(5);

            if (GUILayout.Button("| " + ShowUIString + " (Global) |", "Toolbar"))
            {
                if (ShowUI == false)
                {
                    ShowUI = true;
                    ShowUIString = "Hide UI";
                }
                else
                {
                    ShowUI = false;
                    ShowUIString = "Show UI";
                }
            }

            EditorGUILayout.EndHorizontal();

            #endregion

            #endregion

        }

    }

}

#endif