using System.Collections.Generic;
using UnityEngine;

public class EnemyAction_Operator : MonoBehaviour {
    public Queue<IAction> actions;
    private IAction current_action;
    [SerializeField] private Process_StateMachine state;

    private void Awake() {
        actions = new Queue<IAction>();
    }

    private void OnEnable() {
        // キューに中身が最初からない場合はステートを変更して処理をスキップ
        if (actions.Count <= 0) {
            // ステートを次のものへ
            state++;
            return;
        }

        // キューから先頭のオブジェクトを受け取る
        current_action = actions.Dequeue();
    }

    private void Update() {
        // 処理呼び出し
        bool flag = current_action._update();

        if (flag) {
            if (actions.Count > 0) {
                // 現在の処理が終了し、まだ予約された行動が残っている場合は次の行動を取り出し
                current_action = actions.Dequeue();
            }
            else {
                // 現在の処理が終了した時点で、全ての処理が終了している場合はステートを変更
                state++;
            }
        }
    }
}