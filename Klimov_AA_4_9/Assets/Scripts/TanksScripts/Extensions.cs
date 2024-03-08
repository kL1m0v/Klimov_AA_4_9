using System.Collections.Generic;
using UnityEngine;

namespace Tank1990
{
	public class Extensions : MonoBehaviour
	{
		private Vector2 direction = Vector2.down;
		private Vector3 _angle;
		private Dictionary<DirectionType, Vector2> _directionMovement;
		private Dictionary<DirectionType, Vector3> _directionsRotation;

		public void Initialize()
		{
			_directionMovement = new()
			{
				{DirectionType.Up, new Vector2(0, 1)},
				{DirectionType.Down, new Vector2(0, -1)},
				{DirectionType.Left, new Vector2(-1, 0)},
				{DirectionType.Right, new Vector2(1, 0)}
			};
			_directionsRotation = new()
			{
				{DirectionType.Up, new Vector3(0, 0, 0)},
				{DirectionType.Down, new Vector3(0, 0, 180)},
				{DirectionType.Left, new Vector3(0, 0, 90)},
				{DirectionType.Right, new Vector3(0, 0, 270)}
			};
		}

		public Vector2 LimitDirectionOfMovement(Vector2 inputDirection)
		{
			if (inputDirection.x != 0 && inputDirection.y != 0)
			{
				return direction;
			}
			if (inputDirection.x != 0 && inputDirection.y == 0)
			{
				direction = new Vector2(inputDirection.x, 0);
				return direction;
			}
			if (inputDirection.x == 0 && inputDirection.y != 0)
			{
				direction = new Vector2(0, inputDirection.y);
				return direction;
			}
			return default;
		}

		public Vector3 GetAngleOfRotationFromDirection(Vector3 inputDirection)
		{
			if (inputDirection.x > 0 && inputDirection.y == 0)
			{
				_angle = _directionsRotation[DirectionType.Right];
				return _angle;
			}
			if (inputDirection.x < 0 && inputDirection.y == 0)
			{
				_angle = _directionsRotation[DirectionType.Left];
				return _angle;
			}
			if (inputDirection.x == 0 && inputDirection.y > 0)
			{
				_angle = _directionsRotation[DirectionType.Up];
				return _angle;
			}
			if (inputDirection.x == 0 && inputDirection.y < 0)
			{
				_angle = _directionsRotation[DirectionType.Down];
				return _angle;
			}
			return _angle;
		}

		public Vector2 GetRandomDirection()
		{
			while(true)
			{
				Vector2 dir = _directionMovement[(DirectionType)Random.Range(0, _directionMovement.Count)];
				if (direction != dir)
				{
					direction = dir;
					return dir;
				}
			}
		}
	}
}