using UnityEngine.InputSystem;
using UnityEngine;

namespace Tank1990
{
	[RequireComponent(typeof(MovementComponent), (typeof(ShootingComponent)), (typeof(AnimationComponent)))]
	public class InputComponent : MonoBehaviour
	{
		[SerializeField]
		private InputAction _moveInput;
		
        public InputAction MoveInput { get => _moveInput; }

        public void Initialize()
		{
			MoveInput.Enable();
		}
		private void OnDisable()
		{
			MoveInput.Disable();
		}
	}
}
