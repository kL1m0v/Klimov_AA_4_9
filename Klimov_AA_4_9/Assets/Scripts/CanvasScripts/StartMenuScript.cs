using Tank1990;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    [SerializeField]
    private Button _buttonStartGame;
     [SerializeField]
    private Button _buttonSettings;
     [SerializeField]
    private Button _buttonExit;
    private Canvas _startMenuCanvas;
    [SerializeField]
    private Canvas _settingsCanvas;

    public Button ButtonStartGame { get => _buttonStartGame; set => _buttonStartGame = value; }
    public Button ButtonSettings { get => _buttonSettings; set => _buttonSettings = value; }
    public Button ButtonExit { get => _buttonExit; set => _buttonExit = value; }

    private void OnEnable()
    {
        ButtonStartGame.onClick.AddListener(OnNewGameButtonClick);
        ButtonSettings.onClick.AddListener(OnSettingsButtonClick);
        ButtonExit.onClick.AddListener(OnExitButtonClick);
        _startMenuCanvas = GetComponent<Canvas>();
        
    }

    private void OnDisable()
   {
        ButtonStartGame.onClick.RemoveAllListeners();
        ButtonSettings.onClick.RemoveAllListeners();
        ButtonExit.onClick.RemoveAllListeners();
        _startMenuCanvas = GetComponent<Canvas>();
    }

    private void OnNewGameButtonClick()
    {
        SceneManager.LoadScene(1);
        AudioManager.PlayMusic("levelstarting");
    }

    private void OnSettingsButtonClick()
    {
        _settingsCanvas.enabled = true;
        _startMenuCanvas.enabled = false;
    }


    private void OnExitButtonClick()
    {
       #if UNITY_EDITOR
       EditorApplication.ExitPlaymode();
       #elif UNITY_STANDALONE_WIN
        Application.Quit();
       #endif
    }
}
