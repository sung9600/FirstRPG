using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyController
{
    public override void Init()
    {
        base.Init();
        _atkRange = 2.5f;
        _atkDmg = 10f;
        _currentHp = 10;
        _maxHp = 10;
    }
}
