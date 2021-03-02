using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : EnemyController
{
    // Start is called before the first frame update
    public override void Init()
    {
        base.Init();
        _atkRange = 1.5f;
    }
}
