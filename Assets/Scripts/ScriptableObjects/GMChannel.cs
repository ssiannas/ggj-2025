using UnityEngine;
using UnityEngine.Events;

namespace ggj_2025
{
    // Channel to be used with the GameManager
    [CreateAssetMenu(fileName = "GMChannel", menuName = "Scriptable Objects/GMChannel")]
    public class GMChannel : ScriptableObject
    {
        public UnityAction OnGameStart;
        public UnityAction OnGameEnd;
        public UnityAction OnGamePause;
        public UnityAction OnGameResume;
        public UnityAction OnGameQuit;
        
        
        public void GameStart()
        {
            if (OnGameStart == null)
            {
                throw new System.Exception("No Game Manager Assigned");
            }
            OnGameStart?.Invoke();
        }
        
        public void GameEnd()
        {
            if (OnGameEnd == null)
            {
                throw new System.Exception("No Game Manager Assigned");
            }
            OnGameEnd?.Invoke();
        }
        
        public void GamePause()
        {
            if (OnGamePause == null)
            {
                throw new System.Exception("No Game Manager Assigned");
            }
            OnGamePause?.Invoke();
        }
        
        public void GameResume()
        {
            if (OnGameResume == null)
            {
                throw new System.Exception("No Game Manager Assigned");
            }
            OnGameResume?.Invoke();
        }
        
        public void GameQuit()
        {
            if (OnGameQuit == null)
            {
                throw new System.Exception("No Game Manager Assigned");
            }
            OnGameQuit?.Invoke();
        }
    }
}
