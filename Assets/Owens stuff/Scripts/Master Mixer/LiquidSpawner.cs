using UnityEngine;

public class LiquidSpawner : MonoBehaviour
{
    public GameObject liquidBall;
    public Transform liquidSpawner;
    private void SpawnPrefabAtObject()
    {
        if (liquidSpawner != null && liquidBall != null)
        {
            Instantiate(liquidBall, liquidSpawner.position, liquidSpawner.rotation);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space));
        {
            SpawnPrefabAtObject();
        }
    }
    
}
