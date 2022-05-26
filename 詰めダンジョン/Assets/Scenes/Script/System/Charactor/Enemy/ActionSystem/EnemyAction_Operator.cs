using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction_Operator : MonoBehaviour
{
    public Queue<IAction> actions;

    [SerializeField] private IAction current_action;
    [SerializeField] Process_StateMachine state;

    private void OnEnable()
    {
        // キューから先頭のオブジェクトを受け取る
        current_action = actions.Dequeue();
    }

    void Update()
    {
        // 処理呼び出し
        bool flag = current_action._update();

        if (flag)
        {
            if (actions.Count > 0)
            {
                // 現在の処理が終了し、まだ予約された行動が残っている場合は次の行動を取り出し
                current_action = actions.Dequeue();
            }
            else
            {
                // 現在の処理が終了した時点で、すべての処理が終了している場合はステートを変更
                state.Set_NextState();
            }
        }
    }
}
