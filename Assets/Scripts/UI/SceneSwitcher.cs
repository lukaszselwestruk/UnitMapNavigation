using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] private string startScene;
        [SerializeField] private string sceneToLoad;
        private void Start()
        {
            SceneManager.LoadScene(startScene, LoadSceneMode.Additive);
            SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
        }
        

    }
}
