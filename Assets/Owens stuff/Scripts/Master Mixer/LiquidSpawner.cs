using UnityEngine;

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
    }
}
