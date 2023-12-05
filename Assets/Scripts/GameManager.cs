using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //public static GameManager instance;

    //private void Awake()
    //{
    //    if(instance != null && instance != this)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //    else
    //    {
    //        instance = this; 
    //        DontDestroyOnLoad(this.gameObject);
    //    }
    //}

    public void loadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}
