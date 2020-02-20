using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsefulReferences : MonoBehaviour
{
    public static UsefulReferences instance;
    public GameObject trap;

    void Awake()
    {
        UsefulReferences.instance = this;
    }
}
