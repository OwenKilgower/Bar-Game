using UnityEngine;

public class CoasterCounter : MonoBehaviour
{
    
    public ScoreManager scoreManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GlassPrefab"))
        {
            scoreManager.AddScore();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GlassPrefab"))
        {
            scoreManager.RemoveScore();
        }
    }
}
