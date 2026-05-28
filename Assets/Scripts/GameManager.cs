using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool isLevelFinished = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void LevelFinished()
    {
        isLevelFinished = true;
    }

    public bool IsLevelFinished()
    {
        return isLevelFinished;
    }

}