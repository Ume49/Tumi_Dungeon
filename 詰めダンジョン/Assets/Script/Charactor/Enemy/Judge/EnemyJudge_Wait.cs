using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJudge_Wait : IEnemyJudgeComponent
{
    public override bool _judge()
    {
        // なにもしない
        return true;
    }
}