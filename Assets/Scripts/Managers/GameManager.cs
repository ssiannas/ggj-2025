using UnityEngine;
using UnityEngine.SceneManagement;

namespace ggj_2025
{
    public class GameManager : MonoBehaviour
    {
        private const string GameScene = "SpyrosPlayground";
        
        [SerializeField] private GMChannel gmChannel;
        
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
            
            if (gmChannel is null)
            {
                throw new System.Exception("GM Channel not assigned");
            }
            
            gmChannel.OnGameStart += StartGame;
            gmChannel.OnGameQuit += Quit;
        }
        
        public void LoadTutorial()
        {
            SceneManager.LoadScene("Tutorial");
        }
        
        private void StartGame()
        {
            // start audio
            // load main scene
            SceneManager.LoadScene(GameScene);
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
