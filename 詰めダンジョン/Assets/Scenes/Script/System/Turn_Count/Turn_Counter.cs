using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Counter : MonoBehaviour
{
    public int turn_limit;

    [SerializeField] Process_StateMachine statemachine;
    [SerializeField] Process_StateMachine.State past_state;

    private void Start() {
    }

    private void Update() {
        // プレイヤーが待機以外の行動を取った場合にカウンターを減少させる

        if (past_state == statemachine.state) return;

        // 現在のステートがターン最初、かつ直前のステートがターン最後の場合のみ処理
        if (statemachine.state != Process_StateMachine.State.Input_Check) return;
        if (statemachine.state != Process_StateMachine.State.Enemy_Act) return;

        // カウンタ減少
        turn_limit--;
    }

    private void LateUpdate() {
        past_state = statemachine.state;
    }
}
