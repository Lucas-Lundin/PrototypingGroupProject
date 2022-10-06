using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    [SerializeField] private int currentLevel;
    void Awake()
    {
        if( instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public static LevelManager GetInstance()
    {
        return instance;
    }

    public static void LoadNext()
    {
        var LM = GetInstance();
        if (LM.currentLevel < SceneManager.sceneCount)
        {
            SceneManager.LoadSceneAsync(LM.currentLevel + 1);
        }
        else
        {
            //win!
        }
    }

    public static void Reload()
    {
        SceneManager.LoadSceneAsync(GetInstance().currentLevel);
    }
}
