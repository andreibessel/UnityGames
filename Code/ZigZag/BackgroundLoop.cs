using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public static BackgroundLoop backgroundLoop;
    public void Awake()
    {
        if (backgroundLoop == null)
        {
            backgroundLoop = this;
        }else
        {
            if (gameObject != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
