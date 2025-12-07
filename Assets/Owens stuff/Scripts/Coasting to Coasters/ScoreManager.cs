using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    private float score = 0f;
    
    public GameObject goalCompleteUI;
    public GameObject goalFailedUI;
    public string nextScene = "Next Scene fr";
    
    private float amountLeft = 5f;
    private float currentAmount = 0f;

    public float delay = 1f;
    private float delayTime = 0f;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && currentAmount < amountLeft)
        {
            currentAmount += 1f;
            delayTime = Time.time + delay;
        }

        if (currentAmount == 5f && score > 3f && Time.time >= delayTime)
        {
            StartCoroutine(Success());
        }
        else if (currentAmount == 5f && score < 3f && Time.time >= delayTime)
        {
            StartCoroutine(Failure());
        }
    }

    public void AddScore()
    {
        score += 1f;
    }

    public void RemoveScore()
    {
        score -= 1f;
    }
    
    IEnumerator Success()
    {
        if (goalCompleteUI != null)
            goalCompleteUI.SetActive(true);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(nextScene);
    }

    private IEnumerator Failure()
    {
        if (goalFailedUI != null)
            goalFailedUI.SetActive(true);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(nextScene);
    }
}
