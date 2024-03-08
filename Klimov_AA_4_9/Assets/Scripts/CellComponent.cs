using UnityEngine;

namespace Tank1990
{
	public class CellComponent : MonoBehaviour, IDestructible
	{
		[SerializeField]
		private bool _isDestructible;
		[SerializeField]
		protected bool _isPassableForProjectiles;
		private BoxCollider2D _boxCollider2D;

		public bool IsDestructible { get => _isDestructible; }
		public bool IsPassableForProjectiles { get => _isPassableForProjectiles; }
		
		private void Start()
		{
			_boxCollider2D = GetComponent<BoxCollider2D>();
		}
		
		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.TryGetComponent<ProjectileComponent>(out ProjectileComponent projectileComponent))
			{
				if(IsPassableForProjectiles)
					_boxCollider2D.isTrigger = true;
				else if(IsDestructible)
					DestroyMyself();
			}
		}
		private void OnTriggerExit2D(Collider2D other)
		{
			_boxCollider2D.isTrigger = false;
		}

        public void DestroyMyself()
        {
            gameObject.SetActive(false);
			Destroy(gameObject);
        }
    }
}
