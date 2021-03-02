using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class PlayerController : BaseController
{
    Coroutine _coSkill;
    [SerializeField]
    public float camAngle = 0f;
    public Transform camArm;
    public Transform[] bulletPos = new Transform[5];
    public Vector3 lookForward;
    public Vector3 lookRight;
    public Vector3 moveDir;
    //public float JumpForce=10f;
    //public bool _IsJumping = false;
    Vector2 moveInput;
    Vector3 movement;

    Rigidbody rb;
    public override void Init()
    {
        camArm = GameObject.Find("CameraPivot").transform;
        //Camera.main.transform.position = transform.position + new Vector3(0, 3.0f, -10f);
        //rb = GetComponent<Rigidbody>();
        _MoveSpeed = 15f;
        base.Init();
    }
    protected override void UpdateController()
    {
        lookForward = new Vector3(camArm.forward.x, 0f, camArm.forward.z).normalized;
        lookRight = new Vector3(camArm.right.x, 0f, camArm.right.z).normalized;
        GetDirInput();
        GetAtkInput();
        //Move();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void GetDirInput()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (moveInput.magnitude != 0)
            State = CreatureState.Moving;
        else
            State = CreatureState.Idle;
        movement.Set(moveInput.x, 0, moveInput.y);
        movement = movement.normalized * _MoveSpeed * Time.deltaTime;
        //Debug.Log(movement);
        //rb.MovePosition(transform.position + movement);
    }
    void GetAtkInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetBool("Shoot", true);
            State = CreatureState.Skill;
            _coSkill = StartCoroutine("CoStartShootArrow");
        }
    }
    private void Move()
    {
        if (moveInput.magnitude != 0)
        {
            moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
            if (moveDir != Vector3.zero)
                transform.forward = moveDir;
            transform.position += moveDir * Time.deltaTime * _MoveSpeed;
        }
    }
    protected override void UpdateAnimation()
    {
        if (_State == CreatureState.Idle)
        {
            _animator.Play("Idle");
        }
        else if (_State == CreatureState.Moving)
        {
            _animator.Play("Run");
        }
        else if (_State == CreatureState.Skill)
        {
            //_animator.Play("Shoot");
        }
    }
    IEnumerator CoStartShootArrow()
    {
        GameObject arrowFront = GameManager.Resource.Instantiate("Creature/Others/Arrow", GameObject.Find("Others").transform);
        GameObject arrowLeft60 = GameManager.Resource.Instantiate("Creature/Others/Arrow", GameObject.Find("Others").transform);
        GameObject arrowLeft30 = GameManager.Resource.Instantiate("Creature/Others/Arrow", GameObject.Find("Others").transform);
        GameObject arrowRight60 = GameManager.Resource.Instantiate("Creature/Others/Arrow", GameObject.Find("Others").transform);
        GameObject arroRight30 = GameManager.Resource.Instantiate("Creature/Others/Arrow", GameObject.Find("Others").transform);
        arrowFront.transform.position = bulletPos[0].position;
        arrowFront.transform.rotation = bulletPos[0].rotation;
        arrowLeft30.transform.position = bulletPos[1].position;
        arrowLeft30.transform.rotation = bulletPos[1].rotation;
        arrowLeft60.transform.position = bulletPos[2].position;
        arrowLeft60.transform.rotation = bulletPos[2].rotation;
        arroRight30.transform.position = bulletPos[3].position;
        arroRight30.transform.rotation = bulletPos[3].rotation;
        arrowRight60.transform.position = bulletPos[4].position;
        arrowRight60.transform.rotation = bulletPos[4].rotation;
        yield return new WaitForSeconds(0.2f);
        _animator.SetBool("Shoot", false);
        // 대기 시간
        yield return new WaitForSeconds(0.3f);
        State = CreatureState.Idle;
        _coSkill = null;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.transform.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
    }
}
