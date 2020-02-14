using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}
