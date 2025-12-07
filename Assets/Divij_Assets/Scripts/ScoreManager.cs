using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Divij_Assets.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        public int score = 0;
        public int scoreTarget = 100;

        [SerializeField] public string nextScene = "Next Scene fr";

        public TextMeshProUGUI totalScoreText;
        public TextMeshProUGUI countdownText;

        public float youFailedTime = 15f;
        private float timer;


        private void Start()
        {
            timer = youFailedTime;
        }
        


        private void Update()
        {
            totalScoreText.text = "Total Score: " + score;

            timer -= Time.deltaTime;

            if (countdownText != null)
            {
                countdownText.text = "Time: " + Mathf.RoundToInt(timer);
            }

            if (timer <= 0f)
            {
                SceneManager.LoadScene(nextScene);
            }
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
