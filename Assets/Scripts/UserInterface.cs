using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    public void Restart()
    {
        GameControlScript.instance.Level = 1;
    }
}
