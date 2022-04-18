using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneLoader : ISceneLoader
    {
        public void LoadScene(string sceneName) => 
            SceneManager.LoadScene(sceneName);

        public void ReloadScene() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        public void Exit() => 
            Application.Quit();
    }
}