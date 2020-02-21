using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameControlScript : MonoBehaviour
{
    public static GameControlScript instance;

    public bool gameOver;

    private int _level;

    public bool IsLastLevel()
    {
        return levelPrefabs.Length == Level;
    }

    public int Level
    {
        get => _level;

        set
        {
            // Return if the requested level doesn't exist
            if (levelPrefabs.Length < value)
                return;

            _level = value;

            // Destroy old level and instantiate a new one
            Destroy(GameObject.FindGameObjectWithTag("Level"));
            Instantiate(levelPrefabs[_level - 1]);
        }
    }

    GameObject[] levelPrefabs;


    void Awake() => instance = this;

    void Start()
    {
        levelPrefabs = Resources.LoadAll("Levels").Cast<GameObject>().ToArray();
        Level = 1;
    }

    void Update()
    {
        Time.timeScale = gameOver ? 0 : 1;
    }
}
