Shader "AR/InvisibleDepthMask"
{
    SubShader
    {
        Tags
        {
            "Queue" = "Geometry-1"
            "RenderType" = "Opaque"
        }

        ColorMask 0       // Do not write color
        ZWrite On         // Write to depth buffer
        ZTest LEqual
        Cull Back

        Pass { }
    }
}
