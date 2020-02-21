using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public void Restart()
    {
        GameControlScript.instance.Level = 1;
        UsefulReferences.instance.restartButton.SetActive(false);
        GameControlScript.instance.gameOver = false;
    }

    public void Next()
    {
        GameControlScript.instance.Level++;
        UsefulReferences.instance.nextButton.SetActive(false);
        GameControlScript.instance.gameOver = false;
    }
}
