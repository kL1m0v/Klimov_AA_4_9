using UnityEngine;

namespace Tank1990
{
	public class ProjectileComponent : MonoBehaviour, IDestructible
	{
		[SerializeField]
		private float _speed;
		private Rigidbody2D _rigidbody2d;
		[SerializeField]
		private SideType _sideType;
		public SideType SideType { get => _sideType; set => _sideType = value; }

		private void Start()
		{
			_rigidbody2d = GetComponent<Rigidbody2D>();
		}
		
		private void FixedUpdate()
		{
			Move();
		}
		
		private void OnCollisionEnter2D(Collision2D other)
		{
			
			if (other.gameObject.TryGetComponent<CellComponent>(out CellComponent cellComponent))
			{
				if(!cellComponent.IsPassableForProjectiles)
				{
					DestroyMyself();
				}	
			}
			else if(other.gameObject.TryGetComponent<TankManager>(out TankManager tankManager))
			{
				if(tankManager.SideType != _sideType)
				{
					tankManager.DoDamage();
					DestroyMyself();
				}
			}
			else if(other.gameObject.TryGetComponent<ProjectileComponent>(out ProjectileComponent projectileComponent))
			{
				DestroyMyself();
			}
			else if(other.gameObject.TryGetComponent<HeadquartersScript>(out HeadquartersScript headquartersScript))
			{
				headquartersScript.OnDeath?.Invoke();
				DestroyMyself();
			}
		}
		
		private void Move()
		{
			_rigidbody2d.velocity = transform.up * _speed;
		}
		
		public void DestroyMyself()
		{
			gameObject.SetActive(false);
			Destroy(gameObject);
			AudioManager.PlaySFX("brickhit");
		}
		
	}
}


