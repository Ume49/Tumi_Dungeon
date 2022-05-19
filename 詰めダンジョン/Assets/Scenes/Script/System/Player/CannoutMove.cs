using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 動けないときの処理
public class CannoutMove : MonoBehaviour
{
    [SerializeField] Process_StateMachine stateMachine;

    void Update()
    {
        Debug.Log("その先は壁だ");

        // 入力待機させる
        stateMachine.state = Process_StateMachine.State.Input_Check;
    }
}
