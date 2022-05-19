using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 動けないときの処理
public class CannoutMove : IAction
{
    [SerializeField] Process_StateMachine stateMachine;

    public override void _update()
    {
        Debug.Log("その先は壁だ");

        // 入力待機させる
        stateMachine.state = Process_StateMachine.State.Input_Check;
    }
}
