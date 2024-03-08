using UnityEngine;

namespace Tank1990
{
	[RequireComponent (typeof(Rigidbody2D))]
	public class MovementComponent : MonoBehaviour
	{
		[SerializeField] 
		private float _speed = 10f;
		private Rigidbody2D _rigidbody2d;
		protected Extensions _extensions;
		
		
		public virtual void Initialize()
		{
			_rigidbody2d = GetComponent<Rigidbody2D>();
			_extensions = GetComponent<Extensions>();
			_extensions.Initialize();
		}
		public virtual void Move(Vector2 direction)
		{
			_rigidbody2d.velocity = _extensions.LimitDirectionOfMovement(direction);
			_rigidbody2d.velocity = _rigidbody2d.velocity.normalized * _speed;
			Rotate(direction);
		}
		protected virtual void Rotate(Vector3 direction)
		{
			transform.eulerAngles = _extensions.GetAngleOfRotationFromDirection(direction);
		}
		
	}
}
