using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiquidSpawner : MonoBehaviour
{
    //gameobjects linked in editor
    public GameObject liquidBall;
    public Transform liquidSpawner;
    
    //variables dictating the time between liquid balls spawning
    public float spawnDelay = 0.1f;
    private float nextSpawnTime = 0.1f;

    //variables dictating how many liquid balls are left
    private float amountLeft = 100f;
    private float currentAmount = 0f;

    private float leftCupAccuracy = 0f;
    private float rightCupAccuracy = 0f;
    
    public GameObject goalCompleteUI;
    public GameObject goalFailedUI;
    
    public string nextScene = "Next Scene fr";
    
    //function called to create a liquid ball
    private void SpawnPrefabAtObject()
    {
        if (liquidSpawner != null && liquidBall != null)
        {
            Instantiate(liquidBall, liquidSpawner.position, liquidSpawner.rotation);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextSpawnTime)
        {
            currentAmount += 1;
            if (currentAmount < amountLeft)
            {
                SpawnPrefabAtObject();
                nextSpawnTime = Time.time + spawnDelay;
            }
        }

        if (currentAmount == 100f)
        {
            if (leftCupAccuracy >= 35f && rightCupAccuracy >= 35f)
            {
                StartCoroutine(Success());
            }
            else
            {
                StartCoroutine(Failure());
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreTrigger"))
        {
            leftCupAccuracy += 1f;
        }
        else if (other.CompareTag("ScoreTrigger2"))
        {
            rightCupAccuracy += 1f;
        }
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
