using UnityEngine;
namespace Tank1990
{
	public class BotMovementComponent : MovementComponent
	{
		private Vector2 _direction = Vector2.down;
		public override void Initialize()
		{
			base.Initialize();
		}

		public override void Move(Vector2 direction)
		{
			base.Move(_direction);
		}

		protected override void Rotate(Vector3 direction)
		{
			base.Rotate(_direction);
		}
		
		public void ChangeDirection()
		{
			_direction = _extensions.GetRandomDirection();
		}
	}
}
