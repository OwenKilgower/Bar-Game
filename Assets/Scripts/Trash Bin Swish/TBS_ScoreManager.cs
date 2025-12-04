using UnityEngine;
using UnityEngine.SceneManagement;

public class TBS_ScoreManager : MonoBehaviour
{
    
    public int score = 0;
    public int scoreTarget = 3;
    
    [SerializeField] public string nextScene = "Next Scene fr";

    protected void goalscored()
    {
        score += 1;
        
        Debug.Log("score: " + score);
        
        if (score >= scoreTarget)
        {
            OnTargetReached();
        }
    }
    
    protected void OnTargetReached()
    {
        SceneManager.LoadScene(nextScene);
    }
}
