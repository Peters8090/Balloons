using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    void Start() {
        transform.position += (Vector3)UsefulReferences.instance.levelElementsOffset;
        transform.SetParent(UsefulReferences.instance.sceneElementsRoot.transform);
    }
}
