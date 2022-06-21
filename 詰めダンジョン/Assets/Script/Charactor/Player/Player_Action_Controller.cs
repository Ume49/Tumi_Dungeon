using UnityEngine;
using System.Collections.Generic;

public class Player_Action_Controller : MonoBehaviour {

    public enum Action {
        CannotMove,
        Move,
        Attack
    }
    
    // Inspectorから変な操作をされたくないので見せない
    [System.NonSerialized] public IAction current_action;
    public ICommand command;

    [SerializeField] Move move_script;
    [SerializeField] Attack attack_script;
    [SerializeField] Process_StateMachine stateMachine;
    [SerializeField] Turn_Counter turn_counter;
    [SerializeField] CurrentPosition_OnMap player_pos;

    void OnEnable()
    {
        // エラーチェック
        if(command==null){
            stateMachine++;

            // そもそもInput_Checkを通した上でプレイヤーにコマンドが投げられていないという状況はバグくさいので、エラーログで通知
            #if UNITY_EDITOR
                Debug.LogError("プレイヤーのコマンドがNullです。"+"\nattatched object:"+this.gameObject.name);
            #endif

            return;
        }

        // コマンド取り出しと、そこから今回のアクションの決定・設定をする
        switch(command.id){
            case ICommand.ID.Move:
                var move_cmd=(Command_Move)command;
                
                // 目的地を現在地+方向ベクトルで算出
                Vector2Int destination= player_pos.index+Direciton_Table.Direction_To_Table(move_cmd.direction);

                move_script.SetDestination(destination);

                current_action=move_script;
            break;
            case ICommand.ID.Attack:
                var attack_cmd=(Command_Attack)command;

                attack_script.SetAttack_Info(attack_cmd.direction);

                current_action = attack_script;
            break;
        }
    }

    void Update() {
        // アクションの更新関数呼び出し あと結果受け取り
        bool action_result = current_action._update();

        // 今回ステートでの処理が終了したら追加処理
        if (action_result) {

            // エネミーの処理へ
            stateMachine++;
        }
    }

    void Reset() {
        stateMachine = Resources.FindObjectsOfTypeAll<Process_StateMachine>()[0];
        turn_counter = Resources.FindObjectsOfTypeAll<Turn_Counter>()[0];
    }
}