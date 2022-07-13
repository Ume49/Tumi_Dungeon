using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Check : ITE_Process
{
    [SerializeField] StageEnd stage_end;
    [SerializeField] Under_Checker player_under_check;

    public override void Execute() {
        if (player_under_check.Check() == Static_Object_Tag.Kind.Goal) {
            // ゴールを踏んでたらゲームクリア
            stage_end.GameClear();
        }
    }
}
