using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tank1990
{
    public class PauseCanvasScript : MonoBehaviour
    {
        [SerializeField]
        private Button _exitButton;
        [SerializeField]
        private Button _resumeButton;
        private Canvas _canvas;

        private void Start()
        {
            _canvas = GetComponent<Canvas>();
        }

        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(OnResumeButtonClick);
            _exitButton.onClick.AddListener(OnExitButtonClick);
        }


        private void OnDisable()
        {
            _resumeButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }

        private void OnResumeButtonClick()
        {
            HiddenOrShowCanvas();
        }

        private void OnExitButtonClick()
        {
            GameManager.GameState = GameState.NotActive;
            SceneManager.LoadScene(0);
        }

        public void HiddenOrShowCanvas()
        {
            _canvas.enabled = _canvas.enabled == true ? false : true;
            GameManager.GameState = GameManager.GameState == GameState.Pause ? GameState.Play : GameState.Pause;
            if (_canvas.enabled == true)
                AudioManager.PlayMusic("pause");
        }
    }
}