using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyController
{
    public override void Init()
    {
        base.Init();
        _atkRange = 2.5f;
    }
}
