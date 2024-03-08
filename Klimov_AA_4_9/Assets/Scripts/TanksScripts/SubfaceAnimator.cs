using UnityEngine;

public class SubfaceAnimator : MonoBehaviour
{
	private Animator _animator;
	[SerializeField]
	
	public void Initialize()
	{
		_animator = GetComponent<Animator>();
	}

	public void PlayAnimationImmortality(bool play)
	{
		_animator.SetBool("isImmortal", play);
	}
}
