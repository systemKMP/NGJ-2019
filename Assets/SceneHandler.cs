namespace Assets
{
    using System.IO;
    using UnityEngine.SceneManagement;
    using Debug = UnityEngine.Debug;

    public class SceneHandler
    {
        public void GoToMainMenu()
        {
            Debug.Log("Go to main menu");

            SceneManager.LoadScene(Path.Combine("MainMenu"));
        }

        public void GoToLevel(int levelIndex)
        {
            Debug.Log($"Go to level {levelIndex}");

            SceneManager.LoadScene($"Level_{levelIndex}");
        }

        public void GoToWin()
        {
            Debug.Log("Go to win screen");

            SceneManager.LoadScene("GameWon");
        }

        public void GoToLost()
        {
            Debug.Log("Go to lost screen");

            SceneManager.LoadScene("GameLost");
        }
    }
}
