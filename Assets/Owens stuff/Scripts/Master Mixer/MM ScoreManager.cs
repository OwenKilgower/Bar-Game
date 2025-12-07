using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MMScoreManager : MonoBehaviour
{
    private float leftCupAccuracy = 0f;
    private float rightCupAccuracy = 0f;

    public GameObject leftCup;
    public GameObject rightCup;

    public GameObject goalCompleteUI;
    public GameObject goalFailedUI;

    public string nextScene = "Next Scene fr";

    public float spawnDelay = 0.1f;
    private float nextSpawnTime = 0f;
    private float currentAmount = 0f;

    private bool resultTriggered = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnDelay;
            currentAmount += 1f;
            Debug.Log("Current Amount = " + currentAmount);
        }
        
        if (!resultTriggered && currentAmount >= 100f)
        {
            resultTriggered = true;   
            if (leftCupAccuracy >= 35f && rightCupAccuracy >= 35f)
                StartCoroutine(Success());
            else
                StartCoroutine(Failure());
        }
    }

    public void AddLeftScore()
    {
        leftCupAccuracy += 1f;
        Debug.Log("Left cup hit");
    }

    public void AddRightScore()
    {
        rightCupAccuracy += 1f;
        Debug.Log("Right cup hit");
    }

    public void FunctionGlassBroken()
    {
        StartCoroutine(GlassBroken());
    }
    IEnumerator Success()
    {
        if (goalCompleteUI)
            goalCompleteUI.SetActive(true);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator Failure()
    {
        if (goalFailedUI)
            goalFailedUI.SetActive(true);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextScene);
    }
    IEnumerator GlassBroken()
    {
        if (goalFailedUI)
            goalFailedUI.SetActive(true);

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(nextScene);
    }
}
