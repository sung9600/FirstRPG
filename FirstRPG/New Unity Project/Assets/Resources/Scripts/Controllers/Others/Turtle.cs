using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : EnemyController
{
    // Start is called before the first frame update
    public override void Init()
    {
        base.Init();
        _atkRange = 2.5f;
        _atkDmg = 10f;
        _currentHp = 10;
        _maxHp = 10;
    }
}
