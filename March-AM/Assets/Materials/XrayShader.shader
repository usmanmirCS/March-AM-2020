Shader "Custom/XrayShader"
{
    Subshader
	{
		Tags {"Queue" = "Transparent+1"} //3001

		Pass {Blend Zero One}	//Make see through
	}
}
