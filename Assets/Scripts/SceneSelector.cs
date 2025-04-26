using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

namespace ShadowVR.Demo
{
    public class SceneSelector : MonoBehaviour
    {
        private void Start()
        {
            CreateUI();
        }

        private void CreateUI()
        {
            // Create Canvas
            GameObject canvasObj = new GameObject("SceneSelectCanvas");
            Canvas canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();

            // Create panel
            GameObject panelObj = new GameObject("Panel");
            panelObj.transform.SetParent(canvasObj.transform, false);
            Image panel = panelObj.AddComponent<Image>();
            panel.color = new Color(0, 0, 0, 0.8f);
            RectTransform panelRect = panel.GetComponent<RectTransform>();
            panelRect.anchorMin = new Vector2(0, 0);
            panelRect.anchorMax = new Vector2(1, 1);
            panelRect.offsetMin = new Vector2(10, 10);
            panelRect.offsetMax = new Vector2(-10, -10);

            // Create vertical layout
            VerticalLayoutGroup layout = panelObj.AddComponent<VerticalLayoutGroup>();
            layout.padding = new RectOffset(10, 10, 10, 10);
            layout.spacing = 10;

            // Add scene buttons
            string[] sceneNames = new string[] 
            {
                "BakedLighting",
                "RealtimeLighting",
                "TexturedMaterials",
                "VertexShader",
                "FragmentShader",
                "PostProcessing",
                "CreativeShowcase"
            };

            foreach (string sceneName in sceneNames)
            {
                CreateSceneButton(sceneName, layout.transform);
            }
        }

        private void CreateSceneButton(string sceneName, Transform parent)
        {
            GameObject buttonObj = new GameObject(sceneName + "Button");
            buttonObj.transform.SetParent(parent, false);

            Button button = buttonObj.AddComponent<Button>();
            Image buttonImage = buttonObj.AddComponent<Image>();
            buttonImage.color = new Color(0.2f, 0.2f, 0.2f, 1);

            GameObject textObj = new GameObject("Text");
            textObj.transform.SetParent(buttonObj.transform, false);
            Text buttonText = textObj.AddComponent<Text>();
            buttonText.text = sceneName;
            buttonText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            buttonText.alignment = TextAnchor.MiddleCenter;
            buttonText.color = Color.white;

            RectTransform buttonRect = buttonObj.GetComponent<RectTransform>();
            buttonRect.sizeDelta = new Vector2(0, 50);

            RectTransform textRect = textObj.GetComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.offsetMin = Vector2.zero;
            textRect.offsetMax = Vector2.zero;

            string sceneNameCopy = sceneName;
            button.onClick.AddListener(() => LoadScene(sceneNameCopy));
        }

        private void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}