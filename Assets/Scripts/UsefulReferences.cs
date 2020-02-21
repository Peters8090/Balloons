using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsefulReferences : MonoBehaviour
{
    public static UsefulReferences instance;

    public Vector2 levelElementsOffset = Vector2.zero;
    public GameObject sceneElementsRoot;
    public GameObject trap;

    void Awake() => instance = this;
}
