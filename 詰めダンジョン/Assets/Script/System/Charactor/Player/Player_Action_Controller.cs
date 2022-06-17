using UnityEngine;
using System.Collections.Generic;

public class Player_Action_Controller : MonoBehaviour {

    public enum Action {
        CannotMove,
        Move,
        Attack
    }
    
    [System.NonSerialized] public IAction current_action;
    public ICommand command;

    [SerializeField] IAction move_script;
    [SerializeField] IAction attack_script;
    [SerializeField] Process_StateMachine stateMachine;
    [SerializeField] Turn_Counter turn_counter;

    void OnEnable()
    {
        if(command==null){
            stateMachine++;

            // そもそもInput_Checkを通した上でプレイヤーにコマンドが投げられていないという状況はバグくさいので、エラーログで通知
            #if UNITY_EDITOR
                Debug.LogError("プレイヤーのコマンドがNullです。"+"\nattatched object:"+this.gameObject.name);
            #endif

            return;
        }

        // コマンド取り出しと、そこから今回のアクションの決定・設定をする
        // TODO: caseごとにコマンドをダウンキャストしてアクションに専用の設定をする
        switch(command.id){
            case ICommand.ID.Move:
                current_action = move_script;
            break;
            case ICommand.ID.Attack:
                current_action = attack_script;
            break;
        }
    }

    private void Update() {
        bool action_result = false;

        // アクションの更新関数呼び出し あと結果受け取り
        action_result = current_action._update();

        // 今回ステートでの処理が終了したら追加処理
        if (action_result) {
            if (current_action == Action.CannotMove) {
                // 動けなかった時は入力に戻る
                stateMachine.state = Process_StateMachine.State.Input_Check;
            }
            else {
                // プレイヤーの一連の処理が終わったのでエネミーの処理に入る
                stateMachine++;
            }
        }
    }

    private void Reset() {
        stateMachine = Resources.FindObjectsOfTypeAll<Process_StateMachine>()[0];
        turn_counter = Resources.FindObjectsOfTypeAll<Turn_Counter>()[0];
    }
}