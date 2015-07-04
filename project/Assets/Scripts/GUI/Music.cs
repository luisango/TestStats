using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 5)
        {
            Destroy(transform.gameObject);
        }
    }
}
