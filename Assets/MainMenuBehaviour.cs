using Assets;
using UnityEngine;
using UnityEngine.Assertions;

public class MainMenuBehaviour : MonoBehaviour
{
    private SceneHandler sceneHandler;

    public void Awake()
        => sceneHandler = new SceneHandler();

    public void ExitGame()
    {
        Debug.Log("Exit requested");

        Application.Quit(0);
    }

    public void NewGame()
    {
        Debug.Log("New game requested");

        Assert.IsNotNull(sceneHandler, "sceneHandler != null");

        sceneHandler.GoToLevel(1);
    }
}
