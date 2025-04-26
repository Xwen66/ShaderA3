using UnityEngine;

namespace ShadowVR.Demo
{
    public class CameraController : MonoBehaviour
    {
        [Header("Panning Settings")]
        public Vector3 startPosition = new Vector3(0, 3, -5);
        public Vector3 endPosition = new Vector3(0, 3, 5);
        public float panDuration = 5f;
        public bool pingPong = true;
        
        private float currentTime;
        private bool reversing;
        
        private void Start()
        {
            transform.position = startPosition;
            transform.LookAt(Vector3.zero);
        }
        
        private void Update()
        {
            // Update time
            if (!reversing)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= panDuration && pingPong)
                {
                    currentTime = panDuration;
                    reversing = true;
                }
            }
            else
            {
                currentTime -= Time.deltaTime;
                if (currentTime <= 0)
                {
                    currentTime = 0;
                    reversing = false;
                }
            }
            
            // Calculate position
            float t = currentTime / panDuration;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            
            // Always look at center
            transform.LookAt(Vector3.zero);
        }
    }
}