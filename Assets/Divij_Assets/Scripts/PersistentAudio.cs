using UnityEngine;

public class PersistentAudio : MonoBehaviour
{
    public void  Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
