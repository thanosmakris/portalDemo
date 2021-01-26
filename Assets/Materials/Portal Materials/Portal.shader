Shader "Custom/Portal"
{
    SubShader
    {
        ZWrite Off
        ColorMask 0
        Cull Off

        Stencil{
			Ref 1
			Comp always
			Pass replace
		}
        
        Pass
        {
        }
    }
}