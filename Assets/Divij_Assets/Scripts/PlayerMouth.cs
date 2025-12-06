using System;
using UnityEngine;
using TMPro;

namespace Divij_Assets.Scripts
{
    public class PlayerMouth : MonoBehaviour
    {
    
        //Might add if feel9ng cool
        public GameObject scoreTextPrefab;

        


        private void Reset()
        {
            Collider collider = GetComponent<Collider>();
            if(collider != null)
            {
                collider.isTrigger = true;
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            BeerBall ball = other.GetComponent<BeerBall>();

            if (ball != null)
            {
                if (ScoreManager.Instance != null)
                {
                    ScoreManager.Instance.AddPoints(ball.amount);
                }
                
                ball.OnCollected();

                if (scoreTextPrefab != null)
                {
                    GameObject st = Instantiate(scoreTextPrefab, ball.transform.position, ball.transform.rotation);

                    ScoreText scoreText = st.GetComponent<ScoreText>();

                    if (scoreText != null)
                    {
                        scoreText.SetText("+" + ball.amount);
                    }
                }
            }
            
            
        
        }
    }
}
