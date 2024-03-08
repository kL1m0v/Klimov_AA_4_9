using System.Collections;
using UnityEngine;

namespace Tank1990
{
	[RequireComponent(typeof(MovementComponent), (typeof(ShootingComponent)), (typeof(AnimationComponent)))]
	public class BotManager : TankManager
	{
		[SerializeField]
		private float _delayBetweenChangeDirection = 2f;
		private BotMovementComponent _botMovementComponent;
		[HideInInspector]
		
		
		private void Start()
		{
			Initialize();
		}
		protected override void Initialize()
		{
			base.Initialize();
			_botMovementComponent = GetComponent<BotMovementComponent>();
			_botMovementComponent.Initialize();
			isMoved = true;
			SideType = SideType.Enemy;
			StartCoroutine(UpdateDirection());
		}
		

		protected override void Update() 
		{
			if(GameManager.GameState == GameState.Play)
			{
				_shootingComponent.Shoot();
			}
		}
		
		protected override void FixedUpdate() 
		{
			if(GameManager.GameState == GameState.Play)
			{
				base.FixedUpdate();
				_animationComponent.OnMove(isMoved);
				_botMovementComponent.Move(transform.up);
			}
		}

		private void OnCollisionEnter2D(Collision2D other) 
		{
			if(other.gameObject.TryGetComponent<CellComponent>(out CellComponent cellComponent))
			{
				if(cellComponent.IsDestructible == true)
					return;
				else
				_botMovementComponent.ChangeDirection();
			}
		}
		
		private IEnumerator UpdateDirection()
		{
			while(gameObject.activeSelf == true)
			{
				yield return new WaitForSeconds(_delayBetweenChangeDirection); 
				_botMovementComponent.ChangeDirection();
			}
		}

		public override void DoDamage()
		{
			base.DoDamage();
			_botMovementComponent.ChangeDirection();
		}

		public override void DestroyMyself()
        {
            base.DestroyMyself();
			AudioManager.PlaySFX("fexplosion");
        }

    }
}
