using System.Collections;
using UnityEngine;

namespace Tank1990
{
	public class ShootingComponent : MonoBehaviour
	{
		[SerializeField]
		private GameObject _projectilePrefab;
		[SerializeField]
		private float _delayBetweenShots = 2f;
		private Muzzle _muzzle;
		private bool _canShoot = true;
		private TankManager _tankManager;
		public void Initialize()
		{
			_muzzle = GetComponentInChildren<Muzzle>();
			_tankManager = GetComponent<TankManager>();
		}
		public void Shoot()
		{
			if(_canShoot)
			{
				GameObject projectile = Instantiate(_projectilePrefab, _muzzle.transform.position, _muzzle.transform.rotation);
				projectile.GetComponent<ProjectileComponent>().SideType = _tankManager.SideType;
				_canShoot = false;
				StartCoroutine(Reload());
			}
		}
		private IEnumerator Reload()
		{
			yield return new WaitForSeconds(_delayBetweenShots);
			_canShoot = true;
		}
	}
}
