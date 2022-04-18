using Services;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUiHandler : MonoBehaviour
{
    private const string GameScene = "Game";
    
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _exitBtn;

    private ISceneLoader _sceneLoader;

    public void Construct(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;

        SubscribeOnEvents();
    }

    private void SubscribeOnEvents()
    {
        _playBtn.onClick.AddListener(Play);
        _exitBtn.onClick.AddListener(Exit);
    }

    private void Play() => 
        _sceneLoader.LoadScene(GameScene);

    private void Exit() => 
        _sceneLoader.Exit();
}