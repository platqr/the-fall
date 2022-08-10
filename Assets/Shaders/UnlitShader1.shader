Shader "Unlit/UnlitShader1" {

  Properties {
    _Value ("Value", Float) = 1.0
  }

  SubShader {
    
    Tags { "RenderType"="Opaque" }

    Pass {
      CGPROGRAM
      #pragma vertex vert
      #pragma fragment frag

      #include "UnityCG.cginc"

      float _Value;

      struct MeshData { 
        float4 vertex : POSITION;
        float2 uv : TEXCOORD0;
      };

      struct Interpolators {
        float4 vertex : SV_POSITION;
        float2 uv : TEXCOORD0;
      };

      Interpolators vert (MeshData v) {
        Interpolators o;
        o.vertex = UnityObjectToClipPos(v.vertex);
        o.uv = TRANSFORM_TEX(v.uv, _MainTex);
        UNITY_TRANSFER_FOG(o,o.vertex);
        return o;
      }

      fixed4 frag (Interpolators i) : SV_Target {
        // sample the texture
        fixed4 col = tex2D(_MainTex, i.uv);
        // apply fog
        UNITY_APPLY_FOG(i.fogCoord, col);
        return col;
      }
      ENDCG
    }
  }
}
