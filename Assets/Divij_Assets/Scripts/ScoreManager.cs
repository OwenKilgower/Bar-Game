using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Divij_Assets.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        public int score = 0;
        public int scoreTarget = 22;

        [SerializeField] public string nextScene = "Next Scene fr";

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
