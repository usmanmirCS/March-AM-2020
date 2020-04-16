Shader "Custom/InvisibleMask"
{
    SubShader
    {
		tags {"Queue" = "Transparent+1"} //render after all transparent objects 3001

		Pass { Blend Zero One}		// Make objects behind in higher render queue see through
    }
}
