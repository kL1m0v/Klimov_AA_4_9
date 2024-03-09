using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tank1990
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private SettingScriptableObject _settings;
         private SpawnManager _spawnManager;
        [SerializeField]
        private PauseCanvasScript _pauseMenuCanvas;
        [SerializeField]
        private EndGameCanvasScript _EndGameCanvas;
        private static GameState _gameState = GameState.NotActive;

        public static GameState GameState { get => _gameState; set => _gameState = value; }

        private void Start()
        {
            _spawnManager = GetComponent<SpawnManager>();
            _spawnManager.OnEndGame.AddListener(FinishGame);
            SetInitialSettings();
            StartCoroutine(StartingGame());
            PlayerManager player = FindObjectOfType<PlayerManager>();
            player.OnDeath.AddListener(FinishGame);
            HeadquartersScript baseScript = FindObjectOfType<HeadquartersScript>();
            baseScript.OnDeath.AddListener(FinishGame);
        }
        

        private void Update()
        {
            if(Keyboard.current.escapeKey.wasPressedThisFrame && _gameState != GameState.NotActive)
            {
                PauseGame();
            }
        }

        private void OnDisable()
        {
            _spawnManager.OnEndGame.RemoveAllListeners();
        }

        private void SetInitialSettings()
        {
            _spawnManager.SetInitialSettings(_settings.PlayersHP, _settings.NumberOfBots, _settings.BotsHP);
            AudioListener.volume = _settings.SoundVolume;
        }

        private IEnumerator StartingGame()
        {
            yield return new WaitForSeconds(4.3f);
            _gameState = GameState.Play;
        }

        private void PauseGame()
        {
            _pauseMenuCanvas.HiddenOrShowCanvas();
        }
        private void FinishGame()
        {
            _EndGameCanvas.ShowCanvas();
            GameState = GameState.NotActive;
        }

        
    }
}
