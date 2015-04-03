Shader "3I/WaveShader" {
		Properties{
			_Width ("Width", float) = 1
			_Height ("Height", float) = 1
			_Hps ("Hps", float) = 10
			_MaxHps ("MaxHps", float) = 10
			_Ratio ("Ratio", float) = 1.7777
			_Red ("Red", float) = 0
			_Green ("Green", float) = 0
			_Blue ("Blue", float) = 0
		}
        SubShader {
            Pass {

    CGPROGRAM

    #pragma vertex vert
    #pragma fragment frag
    #include "UnityCG.cginc"
	
	// Variables
	// la largeur
	float _Width;
	// la hauteur
	float _Height;
	// la vie
	float _Hps;
	// la vie maximum
	float _MaxHps;
	// le ratio pour l'affichage
	float _Ratio;
	// le rouge
	float _Red;
	// le vert
	float _Green;
	// le bleu
	float _Blue;

    struct v2f {
        float4 pos : SV_POSITION;
        float3 color : COLOR0;
    };

    v2f vert (appdata_base v)
    {
        v2f o;
 		float4 projecPivot = mul (UNITY_MATRIX_MVP, float4(0, 0, 0, 1));
        o.pos = projecPivot + float4(v.vertex.x / _Ratio * _Width * (_Hps / _MaxHps), v.vertex.y * _Height, v.vertex.z, 0);
        
        // couleur de la barre de vie
        o.color = float3(_Red * (_Hps / _MaxHps), _Green * (_Hps / _MaxHps), _Blue * (_Hps / _MaxHps));
        
        return o;
    }

    half4 frag (v2f i) : COLOR
    {
        return half4 (i.color, 1);
    }
    ENDCG

            }
        }
        Fallback "VertexLit"
    }