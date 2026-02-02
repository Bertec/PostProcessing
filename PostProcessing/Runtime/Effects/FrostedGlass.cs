using System;
using UnityEngine;

namespace UnityEngine.Rendering.PostProcessing
{
    // Add this effect in a Volume profile (PostProcessVolume) like any other.
    // It does not modify the image; it only publishes the current context.source texture globally.
    [Serializable]
    [PostProcess(typeof(FrostedGlassRenderer), PostProcessEvent.AfterStack, "Bertec/Frosted Glass")]
    public sealed class FrostedGlass : PostProcessEffectSettings
    {
        // No user parameters needed.
        public override bool IsEnabledAndSupported(PostProcessRenderContext context)
        {
            return enabled.value;
        }
    }

    public sealed class FrostedGlassRenderer : PostProcessEffectRenderer<FrostedGlass>
    {
        static readonly int SceneCopyTexArray = Shader.PropertyToID("_SceneCopyTexArray");
        static readonly int SceneCopyTex      = Shader.PropertyToID("_SceneCopyTex");
        static readonly int SceneCopyTex_TexelSize = Shader.PropertyToID("_SceneCopyTex_TexelSize");

        public override void Render(PostProcessRenderContext context)
        {
            var cmd = context.command;

            // Bind the same identifier under both names.
            // - If it's actually a Tex2DArray in this frame, _SceneCopyTexArray sampling will work.
            // - If it's actually a Tex2D, the fallback shader that samples _SceneCopyTex will work.
            cmd.SetGlobalTexture(SceneCopyTexArray, context.source);
            cmd.SetGlobalTexture(SceneCopyTex, context.source);

            cmd.SetGlobalVector(SceneCopyTex_TexelSize, new Vector4(
                1f / Mathf.Max(1, context.width),
                1f / Mathf.Max(1, context.height),
                context.width,
                context.height
            ));
        }
    }
}