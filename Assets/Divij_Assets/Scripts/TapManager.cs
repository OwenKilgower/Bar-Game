using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Divij_Assets.Scripts
{
    public class TapManager : MonoBehaviour
    {

        public GameObject beerBallPrefab;

        public List<TapSpawner> tapSpawners = new List<TapSpawner>(4);

        [SerializeField] public float spawnDelay = 3f;
        [SerializeField] public float flowTime = 4f;

        public bool avoidRepeat = true;

        private int lastIndex = -1;

        private Coroutine cycleCoroutine;

        private void OnValidate()
        {
            if (tapSpawners == null)
            {
                tapSpawners = new List<TapSpawner>(4);
            }
        }

        private void Start()
        {
            //tryna do it using children to autofiull but its kinda weird
            /* if (tapSpawners == null || tapSpawners.Count == 0)
        {
            TapSpawner found = GetComponentInChildren<TapSpawner>();

            if (found != null && found.Length > 0)
            {
                if (found != null) tapSpawners = new List<TapSpawner>(found);
            }
        }
        */

            if (tapSpawners == null || tapSpawners.Count == 0)
            {
                Debug.LogWarning("Add Ya Taps to the thingyu");
                return;
            }
        
            cycleCoroutine = StartCoroutine(CycleTaps());
        }

        private IEnumerator CycleTaps()
        {
            yield return new WaitForSeconds(1f);

            while (true)
            {
                int index = ChooseRandomTap();

                tapSpawners[index].StartFlow(flowTime);

                yield return new WaitForSeconds(flowTime);
            
                tapSpawners[index].StopFlow();

                yield return new WaitForSeconds(spawnDelay);


            }
        }

        private int ChooseRandomTap()
        {
            int idx;
            int tries = 0;

            do
            {
                idx = Random.Range(0, tapSpawners.Count);

                tries++;
            
            } while (avoidRepeat && idx == lastIndex);

            lastIndex = idx;
            return idx;
        }
    
    
    


        /*

     instantiate the balls

     Gotta randomise the flowing out of the balls somehow

     Gotta either randomise the tap spawn or assign each tap a value and then give an overall tap controller a tap spawn in time

     Make a list and use the Random.Range( start value ,  end vakue) to make it pick a random spawner to spawn the balls at.

     Maybe make a timer and a while loop that uses the random range method to activate random spawners at a certain spawn delay as well as
     using a flowTime to say how long the balls should be instantiated for

     Make a unity event on the spawners that plays a particle effect to show the player which tap is about to turn on, use the spawn script
     and assign each spawner a spawnValue when attached. Use the unity event to add the pointValue of the beerBalls to the players score counter
     Give some sort of visual feedback of the score going up, Just number for now but will assign uit to the drunk meter

     */
    }
}
