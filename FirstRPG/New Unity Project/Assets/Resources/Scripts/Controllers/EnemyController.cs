using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class EnemyController : BaseController
{
    public float _currentHp;
    public float _maxHp;
    public float _atkDmg;
    public float _searchRange = 10f;
    public float _atkRange = 2.5f;
    public Vector3 destPos;
    public Vector3 initLook;
    public Vector3 initPos;
    public GameObject target;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _atkRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _searchRange);
    }
    public override void Init()
    {
        base.Init();
        _MoveSpeed = 5f;
        target = GameObject.Find("Player");
        destPos = gameObject.transform.position;
        initPos = gameObject.transform.position;
        initLook = transform.forward;
    }
    protected override void UpdateAnimation()
    {
        if (_State == CreatureState.Idle)
        {
            _animator.Play("Idle");
        }
        else if (_State == CreatureState.Moving)
        {
            _animator.Play("Moving");
        }
        else if (_State == CreatureState.Skill)
        {
            _animator.Play("Atk");
        }
        else if (_State == CreatureState.Dead)
        {
            _animator.Play("Dead");
        }
    }
    protected override void UpdateController()
    {
        base.UpdateController();
    }
    private void FixedUpdate()
    {
        if (_currentHp <= 0)
        {
            State = CreatureState.Dead;
            return;
        }
        Move();
    }
    private void Move()
    {
        Vector3 moveDir = destPos - transform.position;
        if (moveDir != Vector3.zero)
            transform.forward = moveDir.normalized;
        if (moveDir.magnitude < _MoveSpeed * Time.deltaTime)
        {
            // 도착
            State = CreatureState.Idle;
            transform.forward = initLook;
            return;
        }
        else if (moveDir.magnitude < _atkRange)
        {
            // 사거리 내
            return;
        }
        else if (moveDir.magnitude < _searchRange || destPos == initPos)
        {
            // 시야 내 or 복귀중
            transform.position += moveDir.normalized * _MoveSpeed * Time.deltaTime;
            if (destPos != initPos)
                destPos = target.transform.position;
        }
        else
        {
            // 시야 밖 -> 복귀로 전환
            destPos = initPos;
            //Debug.Log("else");
        }
    }
    protected override void UpdateIdle()
    {
        Vector3 targetDist = target.transform.position - transform.position;
        if (Vector3.Magnitude(targetDist) > _searchRange || Vector3.Magnitude(targetDist) <= _MoveSpeed * Time.deltaTime)
        {
            transform.forward = Vector3.forward;
            State = CreatureState.Idle;
        }
        else if (Vector3.Magnitude(targetDist) <= _searchRange)
        {
            destPos = target.transform.position;
            State = CreatureState.Moving;
        }
    }

    protected override void UpdateMoving()
    {
        Vector3 moveDir = destPos - transform.position;
        float dist = moveDir.magnitude;
        //Debug.Log(dist);
        if (destPos == initPos && dist < _atkRange)
        {
            //Debug.Log("reached");
            State = CreatureState.Idle;
            return;
        }
        else if (destPos != initPos && dist < _atkRange)
        {
            //Debug.Log("To ATK");
            State = CreatureState.Skill;
        }
        else if (dist < _searchRange)
        {
            transform.forward = moveDir.normalized;
        }
        else
        {
            destPos = initPos;
        }
    }

    protected override void UpdateSkill()
    {
        Vector3 moveDir = destPos - transform.position;

        // 도착 여부 체크
        float dist = moveDir.magnitude;
        if (dist < _atkRange)
        {
            transform.forward = moveDir.normalized;
            destPos = target.transform.position;
            State = CreatureState.Skill;
        }
        else if (dist < _searchRange)
        {
            //Debug.Log("To Moving");
            destPos = target.transform.position;
            State = CreatureState.Moving;
        }
        else
        {
            destPos = initPos;
            State = CreatureState.Moving;
        }
    }

    protected override void UpdateDead()
    {
        Destroy(gameObject, 1f);
    }
    protected void checkAtk()
    {
        Vector3 boxCenter = transform.position;
        Vector3 boxHalfSize = new Vector3(5f, 5f, 5f);  // 캐스트할 박스 크기의 절반 크기. 이렇게 하면 가로 2 세로 2 높이 2의 크기의 공간을 캐스트한다.
        Vector3 direction = Vector3.up;
        RaycastHit[] hits = Physics.BoxCastAll(boxCenter, boxHalfSize, direction);    // BoxCastAll은 찾아낸 충돌체를 배열로 반환한다.
        foreach (var hit in hits)
        {
            // 여기 name or tag 비교해서 player가 atk당하는거 구현
            Debug.Log(hit.collider.gameObject.name);
        }
    }
    public void gothit(int dmg)
    {
        //Debug.Log($"gothit{dmg}");
        _currentHp -= dmg;
        if (_currentHp <= 0)
            State = CreatureState.Dead;
        // Todo : Dmg 메시지 프리팹 만들기
        // Todo : hpbar만들거면 슬라이더 값 줄이기
    }
}
