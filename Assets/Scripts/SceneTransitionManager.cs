using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace ShadowVR.Demo
{
    public class SceneTransitionManager : MonoBehaviour
    {
        public float sceneDuration = 10f; // Duration to stay in each scene
        private string[] sceneNames = new string[]
        {
            "BakedLighting",
            "RealtimeLighting",
            "TexturedMaterials",
            "VertexShader",
            "FragmentShader",
            "PostProcessing",
            "CreativeShowcase"
        };

        private int currentSceneIndex = 0;

        private void Start()
        {
            StartCoroutine(TransitionScenes());
        }

        private IEnumerator TransitionScenes()
        {
            while (true)
            {
                // Load the current scene
                SceneManager.LoadScene(sceneNames[currentSceneIndex]);

                // Wait for the duration of the scene
                yield return new WaitForSeconds(sceneDuration);

                // Move to the next scene
                currentSceneIndex = (currentSceneIndex + 1) % sceneNames.Length;
            }
        }
    }
}