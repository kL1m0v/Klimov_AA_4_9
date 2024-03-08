using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Tank1990
{
    public class SettingCanvasScript : MonoBehaviour
    {
        [SerializeField]
        private SettingScriptableObject _settings;
        [SerializeField]
        private Slider _soundVolumeSlider;
        [SerializeField]
        private TMP_InputField _playersHpInputField;
        [SerializeField]
        private TMP_InputField _botsHpInputField;
        [SerializeField]
        private TMP_InputField _numberOfBotsInputField;
        [SerializeField]
        private Canvas _startMenuCanvas;
        [SerializeField]
        private Canvas _settingsCanvas;
        [SerializeField]
        private Button _backButton;

        private void Start()
        {
            _playersHpInputField.text = _settings.PlayersHP.ToString();
            _botsHpInputField.text = _settings.BotsHP.ToString();
            _numberOfBotsInputField.text = _settings.NumberOfBots.ToString();
        }

        private void OnEnable()
        {
            _soundVolumeSlider.onValueChanged.AddListener(OnValueChangedSlider);
            _playersHpInputField.onEndEdit.AddListener(OnEndEditPlayersHpInputField);
            _botsHpInputField.onEndEdit.AddListener(OnEndEditBotsHpInputField);
            _numberOfBotsInputField.onEndEdit.AddListener(OnEndEditNumbersOfBotsInputField);
            _backButton.onClick.AddListener(OnClickBackButton);
        }



        private void OnValueChangedSlider(float volume)
        {
            _settings.SoundVolume = volume;
        }

        private void OnEndEditPlayersHpInputField(string hp)
        {
            byte.TryParse(hp, out byte result);
            _settings.PlayersHP = result;
        }

        private void OnEndEditBotsHpInputField(string hp)
        {
            byte.TryParse(hp, out byte result);
            _settings.BotsHP = result;
        }

        private void OnEndEditNumbersOfBotsInputField(string number)
        {
            byte.TryParse(number, out byte result);
            _settings.NumberOfBots = result;
        }

        private void OnClickBackButton()
        {
            _startMenuCanvas.enabled = true;
            _settingsCanvas.enabled = false;
        }

    }
}
