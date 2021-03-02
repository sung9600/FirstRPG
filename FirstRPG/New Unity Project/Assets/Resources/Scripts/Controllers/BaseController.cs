using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class BaseController : MonoBehaviour
{
	[SerializeField]
	protected CreatureState _State = CreatureState.Idle;
	protected Animator _animator;
	[SerializeField]
	protected float _MoveSpeed;
	[SerializeField]
	public virtual CreatureState State
	{
		get { return _State; }
		set
		{
			if (_State == value)
				return;

			_State = value;

			UpdateAnimation();
		}
	}
	protected virtual void UpdateAnimation()
    {

    }
	void Start()
	{
		Init();
	}

	public virtual void Init()
	{
		State = CreatureState.Idle;
		_animator = GetComponent<Animator>();
	}

	void Update()
	{
		UpdateController();
	}

	protected virtual void UpdateController()
	{
		switch (State)
		{
			case CreatureState.Idle:
				UpdateIdle();
				break;
			case CreatureState.Moving:
				UpdateMoving();
				break;
			case CreatureState.Skill:
				UpdateSkill();
				break;
			case CreatureState.Dead:
				UpdateDead();
				break;
		}
	}
	protected virtual void UpdateIdle()
	{
	}
	protected virtual void UpdateMoving()
	{
	}
	protected virtual void UpdateSkill()
	{

	}
	protected virtual void UpdateDead()
	{

	}
}
