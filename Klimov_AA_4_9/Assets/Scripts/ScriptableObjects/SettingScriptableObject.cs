using UnityEngine;

namespace Tank1990
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Settings")]
    public class SettingScriptableObject : ScriptableObject
    {
        [SerializeField]
        private float _soundVolume = 0.5f;
        [SerializeField]
        private byte _playersHP = 3;
        [SerializeField]
        private byte _botsHP = 1;
        [SerializeField]
        private byte _numberOfBots = 6;

        public float SoundVolume { get => _soundVolume; set => _soundVolume = value; }
        public byte PlayersHP { get => _playersHP; set => _playersHP = value; }
        public byte BotsHP { get => _botsHP; set => _botsHP = value; }
        public byte NumberOfBots { get => _numberOfBots; set => _numberOfBots = value; }
    }
}
