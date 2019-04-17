using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicapp : MonoBehaviour
{


    private static Musicapp instance = null;

    public static Musicapp Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } 
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
 // any other methods you need



