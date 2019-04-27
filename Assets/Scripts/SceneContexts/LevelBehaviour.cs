using Assets;
using UnityEngine;

public class LevelBehaviour : MonoBehaviour
{
    [SerializeField]
    private int levelIndex;

    private SceneHandler sceneHandler;

    public void ExitToMenu() => sceneHandler.GoToMainMenu();

    public void GameWon() => sceneHandler.GoToWin();

    public void GameLost() => sceneHandler.GoToLost();

    public void NextLevel() => sceneHandler.GoToLevel(levelIndex + 1);

    private void Awake() => sceneHandler = new SceneHandler();
}
