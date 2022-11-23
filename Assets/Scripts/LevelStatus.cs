using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStatus : MonoBehaviour
{
    private static LevelStatus _instance;
    public static LevelStatus Instance { get { return _instance; } }

    public static HashSet<string> CompleteLevels = new HashSet<string>();

    public static readonly HashSet<string> TutorialLevels = new HashSet<string>()
    {
        "Level1-1",
        "Level1-2",
        "Level1-3",
        "Level1-4",
        "Level2-1",
        "Level3-1",
        "Level4-1",
        "Level5-1",
        "Level6-1",
        "Level7-1",
        "Level8-1"
    };

    public static readonly List<string> levelList = new List<string>()
    {
        "Level1-1", "Level1-2", "Level1-3", "Level1-4",
        "Level2-1", "Level2-2", "Level2-3",
        "Level3-1", "Level3-2", "Level3-3",
        "Level4-1", "Level4-2", "Level4-3",
        "Level5-1", "Level5-2", "Level5-3",
        "Level6-1", "Level6-2", "Level6-3",
        "Level7-1", "Level7-2", "Level7-3",
        "Level8-1",
    };

    void Awake()
    {
        //Initialize instance
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public static void ChangeLevelStatus()
    {
        if (Instance)
        {
            string level = SceneManager.GetActiveScene().name;
            //Debug.Log(level);
            if (!CompleteLevels.Contains(level))
            {
                CompleteLevels.Add(level);
            }
        }
        else
        {
            Debug.Log("Not valid instance");
        }
    }
}
