using UnityEngine;
using UnityEngine.Events;

namespace Tank1990
{
	[RequireComponent(typeof(MovementComponent), (typeof(ShootingComponent)), (typeof(AnimationComponent)))]
	
	public abstract class TankManager : MonoBehaviour, IDestructible
	{
		
		protected ShootingComponent _shootingComponent;
		protected AnimationComponent _animationComponent;
		public UnityEvent OnDeath;
		[SerializeField]
		private byte _health = 3;
		protected bool isMoved = false;
		protected SideType _sideType;

		public SideType SideType { get => _sideType; set => _sideType = value ; }
        public byte Health { get => _health; set => _health = value; }

        protected virtual void Initialize()
		{
			_shootingComponent = GetComponent<ShootingComponent>();
			_animationComponent = GetComponent<AnimationComponent>();
			_shootingComponent.Initialize();
			_animationComponent.Initialize();
		}
		protected virtual void Update(){}
		protected virtual void FixedUpdate()
		{
			CheckMovement();
			_animationComponent.OnMove(isMoved);
		}

		private void OnDisable()
		{
			OnDeath.RemoveAllListeners();
		}

		protected virtual void CheckMovement(){}

		public virtual void DestroyMyself()
		{
			OnDeath?.Invoke();
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
		
		public virtual void DoDamage()
		{
			Health--;
			CheckHealth();
		}
		
		private void CheckHealth()
		{
			if(Health <= 0)
			{
				DestroyMyself();
			}
		}
	}
}

