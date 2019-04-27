using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class GameOverBehaviour : MonoBehaviour
{
    private SceneHandler sceneHandler;

    private void Awake() => sceneHandler = new SceneHandler();

    public void GoToMenu() => sceneHandler.GoToMainMenu();
}
