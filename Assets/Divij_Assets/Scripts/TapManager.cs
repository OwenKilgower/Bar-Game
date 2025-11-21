using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{

    public GameObject beerBallPrefab;

    private List<GameObject> spawnerList = new List<GameObject>(4);

    [SerializeField] public float spawnDelay = 3f;
    [SerializeField] public float flowTime = 4f;






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
