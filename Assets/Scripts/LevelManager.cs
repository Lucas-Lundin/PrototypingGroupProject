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

        SceneManager.LoadScene(LM.currentLevel + 1);
        LM.currentLevel += 1;
    }

    public static void Reload()
    {
        SceneManager.LoadSceneAsync(GetInstance().currentLevel);
    }
}
