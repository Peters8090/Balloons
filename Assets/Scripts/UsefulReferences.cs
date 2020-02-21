using UnityEngine;
using UnityEngine.UI;

public class UsefulReferences : MonoBehaviour
{
    public static UsefulReferences instance;

    public Vector2 levelElementsOffset = Vector2.zero;
    public GameObject sceneElementsRoot;
    public GameObject trap;

    public GameObject restartButton;
    public GameObject nextButton;

    void Awake() => instance = this;
}
