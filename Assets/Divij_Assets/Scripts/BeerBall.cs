using UnityEngine;

namespace Divij_Assets.Scripts
{
    public class BeerBall : MonoBehaviour
    {
        public int amount = 5;

        public float lifeTime = 5f;

        public GameObject collectEffect;

        private void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        public void OnCollected()
        {
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, transform.rotation);
            
            }

            Destroy(gameObject);
        }
    


    }
}
