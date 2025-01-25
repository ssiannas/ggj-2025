using UnityEngine;
using UnityEngine.SceneManagement;

namespace ggj_2025
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;
        
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
            DontDestroyOnLoad(gameObject);
        }

        public void StartGame()
        {
            // start audio
            // load main scene
            SceneManager.LoadScene("SpyrosPlayground");
        }

        public void Quit()
        {
            Application.Quit();
        }
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
