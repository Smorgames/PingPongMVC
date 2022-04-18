namespace Services
{
    public interface ISceneLoader
    {
        void LoadScene(string sceneName);
        void ReloadScene();
        void Exit();
    }
}