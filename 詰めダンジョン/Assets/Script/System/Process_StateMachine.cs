using System;
using System.Collections.Generic;
using UnityEngine;

public class Process_StateMachine : MonoBehaviour {

    public enum State : int {
        Input_Check,    // 入力確認
        Player_Act,     // プレイヤーキャラの行動
        Enemy_Judge,    // エネミーの行動決定
        Enemy_Act,      // エネミーの行動
        Turn_End,       // ターン終了時処理  
        Count           // 末尾
    }

    [SerializeField] private State state_data;

    [Header("ステートによって有効化状態を管理するスクリプト")]
    [SerializeField]
    private List<MonoBehaviour> input_check_script;

    [SerializeField]
    private List<MonoBehaviour> player_act_script;

    [SerializeField]
    private List<MonoBehaviour> enemy_judge_script;

    [SerializeField]
    private List<MonoBehaviour> enemy_act_script;
    [SerializeField]
    List<MonoBehaviour> turn_end_script;

    public State state {
        get {
            return state_data;
        }
        set {
            state_data = value;

            Switch();
        }
    }

    public static Process_StateMachine operator ++(Process_StateMachine p) {
        // 次のステートをintで計算
        var state_int = (int)p.state_data;
        state_int = (++state_int) % (int)State.Count;

        // 型を戻して代入
        p.state_data = (State)state_int;

        // 変更を反映
        p.Switch();

        return p;
    }

    private void Start() {
        Switch();
    }

    // 現在のステートと対応するものだけ有効化する
    private void Switch() {
        // 現在のステートに対応したもの以外全て無効化
        Action<List<MonoBehaviour>> all_disenable = x => { foreach (var w in x) { w.enabled = false; } };

        // 一旦全部無効化
        all_disenable(input_check_script);
        all_disenable(player_act_script);
        all_disenable(enemy_judge_script);
        all_disenable(enemy_act_script);
        all_disenable(turn_end_script);

        // 現在のステートと対応するものだけ有効化
        switch (state_data) {
            case State.Input_Check:
                input_check_script.ForEach(x => x.enabled = true);
                break;

            case State.Player_Act:
                player_act_script.ForEach(x => x.enabled = true);
                break;

            case State.Enemy_Judge:
                enemy_judge_script.ForEach(x => x.enabled = true);
                break;

            case State.Enemy_Act:
                enemy_act_script.ForEach(x => x.enabled = true);
                break;
            case State.Turn_End:
                turn_end_script.ForEach(x => x.enabled = true);
                break;
        }
    }
}