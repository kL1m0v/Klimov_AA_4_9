using UnityEngine;
using UnityEngine.Events;

namespace Tank1990
{
	public class SpawnManager : MonoBehaviour
	{
		
		[SerializeField]
		private Transform[] _spawnPointsOfBots;
		[SerializeField]
		private Transform _spawnPointsOfPlayer;
		[SerializeField]
		private GameObject _botPrefab;
		[SerializeField]
		private GameObject _playerPrefab;
		public UnityEvent OnEndGame;
		private byte _playersHp;
		private byte _botsHp;
		private byte _countOfBotsPerGame;
		private byte _maxBotsInGame;
		private byte _numberOfBotsKilled;
		
		public void SetInitialSettings(byte PlayerHP, byte NumberOfBots, byte BotsHP)
		{
			_playersHp = PlayerHP;
			_maxBotsInGame = NumberOfBots;
			_botsHp = BotsHP;
			InitialSpawn();
			SpawnPlayer();
		}
	
		private void InitialSpawn()
		{
			byte counter = 0;
			foreach(Transform transform in _spawnPointsOfBots)
			{
				counter++;
				CreateNewBot(transform.position, transform.rotation);
				if(counter == _maxBotsInGame)
					return;
			}
			// for(int i = 0; i <= 0; i++)
			// {
			// 	CreateNewBot(_spawnPointsOfBots[i].transform.position, _spawnPointsOfBots[i].transform.rotation);
			// }
		}

		private void SpawnPlayer()
		{
			GameObject player = Instantiate(_playerPrefab, _spawnPointsOfPlayer.transform.position, _spawnPointsOfPlayer.transform.rotation);
			player.GetComponent<PlayerManager>().Health = _playersHp;
		}

		private void SpawnNewBot()
		{
			if(_countOfBotsPerGame < _maxBotsInGame)
			{
				Transform transform = _spawnPointsOfBots[Random.Range(0, _spawnPointsOfBots.Length)];
				CreateNewBot(transform.position, transform.rotation);
			}	
		}

		private GameObject CreateNewBot(Vector3 position, Quaternion rotation)
		{
			GameObject bot = Instantiate(_botPrefab, position, rotation);
			bot.GetComponent<BotManager>().OnDeath.AddListener(SpawnNewBot);
			bot.GetComponent<BotManager>().OnDeath.AddListener(IncrementDeathCounter);
			bot.GetComponent<TankManager>().Health = _botsHp;
			bot.SetActive(true);
			_countOfBotsPerGame++;
			return bot;
		}

		private void IncrementDeathCounter()
		{
			_numberOfBotsKilled++;
			if(_numberOfBotsKilled == _maxBotsInGame)
			{
				OnEndGame?.Invoke();
			}
		}
	}
}
