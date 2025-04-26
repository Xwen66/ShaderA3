using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ShadowVR.Demo
{
    public class PostProcessingManager : MonoBehaviour
    {
        public Volume postProcessVolume;
        
        private Bloom bloom;
        private ChromaticAberration chromaticAberration;
        private ColorAdjustments colorAdjustments;
        
        [Header("Bloom Settings")]
        public float bloomIntensity = 1f;
        public float bloomThreshold = 0.9f;
        
        [Header("Chromatic Aberration")]
        public float aberrationIntensity = 0.5f;
        
        [Header("Color Grading")]
        public float saturation = 20f;
        public float contrast = 10f;
        
        private void Start()
        {
            // Get or create post process volume
            if (!postProcessVolume)
            {
                var volumeObject = new GameObject("Post Process Volume");
                postProcessVolume = volumeObject.AddComponent<Volume>();
                postProcessVolume.isGlobal = true;
                
                var profile = ScriptableObject.CreateInstance<VolumeProfile>();
                postProcessVolume.profile = profile;
                
                // Add effects
                bloom = profile.Add<Bloom>(true);
                chromaticAberration = profile.Add<ChromaticAberration>(true);
                colorAdjustments = profile.Add<ColorAdjustments>(true);
            }
            
            // Configure effects
            UpdateEffects();
        }
        
        private void UpdateEffects()
        {
            if (bloom != null)
            {
                bloom.intensity.value = bloomIntensity;
                bloom.threshold.value = bloomThreshold;
            }
            
            if (chromaticAberration != null)
            {
                chromaticAberration.intensity.value = aberrationIntensity;
            }
            
            if (colorAdjustments != null)
            {
                colorAdjustments.saturation.value = saturation;
                colorAdjustments.contrast.value = contrast;
            }
        }
        
        private void OnValidate()
        {
            UpdateEffects();
        }
    }
}