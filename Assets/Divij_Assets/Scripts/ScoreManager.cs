using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Divij_Assets.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        public int score = 0;
        public int scoreTarget = 100;

        [SerializeField] public string nextScene = "Next Scene fr";

        public TextMeshProUGUI totalScoreText;


        private void Update()
        {
            totalScoreText.text = "Total Score: " + score;
        }

        private void Awake()
        {
            Instance = this;
        }


        public void AddPoints(int amount)
        {
            score += amount;
        

            if (score >= scoreTarget)
            {
                OnTargetReached();
            }
        }

        private void OnTargetReached()
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
