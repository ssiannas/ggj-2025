using UnityEngine;
using UnityEngine.SceneManagement;

namespace ggj_2025
{
    public class GameManager : MonoBehaviour
    {
        private const string GameScene = "Level2";
        
        [SerializeField] private GMChannel gmChannel;
        [SerializeField] private AudioChannel audioChannel;
        
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

        private void Start()
        {
            audioChannel.PlayAudio("main_menu_theme");
        }
        
        public void LoadTutorial()
        {
            SceneManager.LoadScene("Tutorial");
        }
        
        private void StartGame()
        {
            // start audio
            // load main scene
            audioChannel.StopAudio("main_menu_theme");
            audioChannel.PlayAudio("main_theme");
            SceneManager.LoadScene(GameScene);
        }

        public void Quit()
        {
            Application.Quit();
        }


        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
