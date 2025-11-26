using System.Collections;
using UnityEngine;

namespace Divij_Assets.Scripts
{
    public class TapSpawner : MonoBehaviour
    {
        public GameObject beerBallPrefab;
        public Transform spawnPoint;
        public float spawnInterval = 0.25f;
        public float initialSpeed = 1f;

        public ParticleSystem warningEffect;
        public float warningDelay = 1f;

        public Coroutine spawnCoroutine;

    


        public void StartFlow(float duration)
        {
            if (warningEffect != null && warningDelay > 0f)
            {
                warningEffect.Play();
                StartCoroutine(DelayedStart(duration, warningDelay));
            
            }

            else
            {
                BeginSpawning(duration);
            }
        }


        private IEnumerator DelayedStart(float duration,float delay)
        {
            yield return new WaitForSeconds(delay);

            BeginSpawning(duration);
        }

        private void BeginSpawning(float duration)
        {
            StopSpawning();
            spawnCoroutine = StartCoroutine(SpawnRoutine(duration));
        }
    

        public void StopFlow()
        {
            StopSpawning();

            if (warningEffect != null)
            {
                warningEffect.Stop();
            }
        }
    
    
        private void StopSpawning()
        {
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);

                spawnCoroutine = null;
            }
        }

        private IEnumerator SpawnRoutine(float duration)
        {
            float timer = 0f;

            while (timer < duration)
            {
                SpawnBall();

                yield return new WaitForSeconds(spawnInterval);

                timer += spawnInterval;
            }
        }

        private void SpawnBall()
        {
            GameObject go = Instantiate(beerBallPrefab, spawnPoint.position, spawnPoint.rotation);

            Rigidbody rb = go.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = spawnPoint.up * -initialSpeed;
            }
        }
    }
}
