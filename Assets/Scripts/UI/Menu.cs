using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("SceneSwitcher", LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
