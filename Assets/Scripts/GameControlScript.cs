using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameControlScript : MonoBehaviour
{
    public static GameControlScript instance;

    private int _level;
    public int Level
    {
        get => _level;

        set
        {
            // Return if the requested level doesn't exist
            if (levelPrefabs.Length < value)
            {
                Level = 1;
                return;
            }

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
}
