using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tank1990
{
    public class EndGameCanvasScript : MonoBehaviour
    {
        [SerializeField]
        private Button _exitButton;
        private Canvas _canvas;

        private void Start()
        {
            _canvas = GetComponent<Canvas>();
        }
        private void OnEnable()
        {
            _exitButton.onClick.AddListener(OnExitButtonClick);
        }


        private void OnDisable()
        {
            _exitButton.onClick.RemoveAllListeners();
        }

        private void OnExitButtonClick()
        {
            GameManager.GameState = GameState.NotActive;
            SceneManager.LoadScene(0);
        }

        public void ShowCanvas()
        {
            _canvas.enabled = true;
        }
    }
}
