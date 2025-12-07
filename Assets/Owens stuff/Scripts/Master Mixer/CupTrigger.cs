using UnityEngine;

public class CupTrigger : MonoBehaviour
{
    public enum CupSide { Left, Right }
    public CupSide cupSide;

    public MMScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Liquid"))
        {
            if (cupSide == CupSide.Left)
            {
                scoreManager.AddLeftScore();
            }
            else if (cupSide == CupSide.Right)
            {
                scoreManager.AddRightScore();
            }
        }
    }
}
