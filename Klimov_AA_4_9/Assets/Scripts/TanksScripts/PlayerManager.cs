using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tank1990
{
	[RequireComponent(typeof(InputComponent))]
	public class PlayerManager : TankManager
	{
		private MovementComponent _movementComponent;
		private InputComponent _inputComponent;
		private Vector3 _startingSpawnPoint;
		private SubfaceAnimator _subfaceAnimator;
		private bool _isImmortal = false;
		[SerializeField]
		private float _timeOfImmortality = 2f;

		private void Start()
		{
			Initialize();
			_startingSpawnPoint = transform.position;
			_subfaceAnimator = GetComponentInChildren<SubfaceAnimator>();
			_subfaceAnimator.Initialize();
		}
		protected override void Initialize()
		{
			base.Initialize();
			_inputComponent = GetComponent<InputComponent>();
			_inputComponent.Initialize();
			_movementComponent = GetComponent<MovementComponent>();
			_movementComponent.Initialize();
			SideType = SideType.Player;
		}
		protected override void Update()
		{
			if(GameManager.GameState == GameState.Play)
			{
				if (Keyboard.current.spaceKey.wasPressedThisFrame) _shootingComponent.Shoot();
			}
			
		}
		protected override void FixedUpdate()
		{
			if(GameManager.GameState == GameState.Play)
			{
				base.FixedUpdate();
				_movementComponent.Move(_inputComponent.MoveInput.ReadValue<Vector2>());
			}
		}

		protected override void CheckMovement()
		{
			if (_inputComponent.MoveInput.ReadValue<Vector2>() == Vector2.zero)
			{
				isMoved = false;
			}
			else
			{
				isMoved = true;
			}
		}
		public override void DoDamage()
		{
			if (!_isImmortal)
			{
				base.DoDamage();
				AudioManager.PlaySFX("eexplosion");
				Respawn();
				_isImmortal = true;
				if(gameObject.activeSelf != false)
					StartCoroutine(Immortal());
			}
		}
		private void Respawn()
		{
			transform.position = _startingSpawnPoint;
		}
		
		private IEnumerator Immortal()
		{
			
			while(_isImmortal)
			{
				_subfaceAnimator.PlayAnimationImmortality(true);
				yield return new WaitForSeconds(_timeOfImmortality);
				_isImmortal = false;
			}
			_subfaceAnimator.PlayAnimationImmortality(false);
		}
    }
}
