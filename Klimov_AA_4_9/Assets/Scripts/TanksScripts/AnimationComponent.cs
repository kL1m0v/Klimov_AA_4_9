using UnityEngine;

public class AnimationComponent : MonoBehaviour
{
	private Animator _animator;
	
	public void Initialize()
	{
		_animator = GetComponent<Animator>();
	}
	
	public void OnMove(bool isMoved)
	{
		_animator.SetBool("isMove", isMoved);
	}
}
