using UnityEngine;

namespace ggj_2025
{
    public class IndicatorController : MonoBehaviour
    {
        public GameObject P1Full;
        public GameObject P1Empty;
        public GameObject P2Full;
        public GameObject P2Empty;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            P1Empty.SetActive(false);
            P1Full.SetActive(true);
            P2Empty.SetActive(false);
            P2Full.SetActive(true);
        }

        public void SetActive(bool isFull, int playerIndex)
        {
            if (playerIndex == 0) {
                SetP1(isFull);
            } else {
                SetP2(isFull);
            }
        }
        
        public void SetP1(bool isFull)
        {
            P1Empty.SetActive(!isFull);
            P1Full.SetActive(isFull);
        }
        
        public void SetP2(bool isFull)
        {
            P2Empty.SetActive(!isFull);
            P2Full.SetActive(isFull);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
