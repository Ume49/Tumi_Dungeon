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

    [SerializeField] State state_data;
    [SerializeField] History_Stocker history; 

    // 対応するステートのときのみ有効化されていて欲しいスクリプトたち
    [SerializeField] List<MonoBehaviour> input_check_script;

    [SerializeField] List<MonoBehaviour> player_act_script;

    [SerializeField] List<MonoBehaviour> enemy_judge_script;

    [SerializeField] List<MonoBehaviour> enemy_act_script;
    [SerializeField] List<MonoBehaviour> turn_end_script;

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


        // ターン終了->開始の瞬間を捉えたいので過去のステートを保存
        var past_state=state_data;

        // 現在のステートと対応するものだけ有効化
        switch (state_data) {
            case State.Input_Check:
                foreach(var w in input_check_script){
                    w.enabled=true;
                }
                break;

            case State.Player_Act:
                foreach(var w in player_act_script){
                    w.enabled=true;
                }
                break;

            case State.Enemy_Judge:
                foreach(var w in enemy_judge_script){
                    w.enabled=true;
                }
                break;

            case State.Enemy_Act:
                foreach(var w in enemy_act_script){
                    w.enabled=true;
                }
                break;
            case State.Turn_End:
                turn_end_script.ForEach(x => x.enabled = true);
                break;
        }

        // ターンの最初を観測したら、このターンの履歴を入れる枠を作成
        if(past_state==State.Turn_End && state_data==State.Input_Check){
            history.Make_NewTurn_History();
        }
    }
}