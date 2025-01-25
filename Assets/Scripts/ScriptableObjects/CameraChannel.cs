using UnityEngine;
using UnityEngine.Events;

namespace ggj_2025
{
    [CreateAssetMenu(fileName = "CameraChannel", menuName = "Scriptable Objects/CameraChannel")]
    public class CameraChannel : ScriptableObject
    {
        public UnityAction<float, float> OnCameraShake;
         
        public void CameraShake(float duration, float magnitude)
        {
            if (OnCameraShake == null)
            {
                throw new System.Exception("No Camera Shake Assigned");
            }
            OnCameraShake?.Invoke(duration, magnitude);
        }
    }
}
