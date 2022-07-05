using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Action_Executer : MonoBehaviour {
    Queue<ICommand> commands;
    IAction current_action;
    [SerializeField] Process_StateMachine state;

    public void AddCommandQueue(ICommand enemy_command){
        commands.Enqueue(enemy_command);
    }

    void Awake() {
        commands = new Queue<ICommand>();
    }

    void OnEnable() {
        // キューに中身が最初からない場合はステートを変更して処理をスキップ
        if (commands.Count <= 0) {
            // ステートを次のものへ
            state++;
            return;
        }

        SetNextAction(commands.Dequeue());
    }

    void Update() {
        // 処理呼び出し
        // 今回の処理が終わったかどうか受け取り
        bool is_update_end = current_action._update();

        // 処理が終わってないなら次のフレームも続けて処理する
        if(!is_update_end) return;

        if (commands.Count > 0) {
            // 現在の処理が終了し、まだ予約された行動が残っている場合は次の行動を取り出して処理続行
            SetNextAction(commands.Dequeue());
            return;
        }

        // ここに来た時点で処理は残ってないので、ステートを遷移させて処理終了
        state++;
    }

    // コマンドを実際の処理に変換する処理
    void SetNextAction(ICommand command) {
        // コマンドから情報を取り出して、行動クラスをセット
        switch(command.id){
            case ICommand.ID.Move:
            {
                var command_casted = (Command_Move)command;

                var move_component = command_casted.move_charactor.GetComponent<Move>();

                // 目的地計算
                var current_pos = command_casted.move_charactor.GetComponent<CurrentPosition_OnMap>();

                var destinatino_pos = current_pos.value + Direciton_Table.Direction_To_Table(command_casted.direction);

                move_component.SetDestination(destinatino_pos);


                current_action = move_component;
            }
                break;
            case ICommand.ID.Attack:
            {
                var command_casted = (Command_Attack)command;

                var attack_component=command_casted.attack_charactor.GetComponent<Attack>();

                attack_component.SetAttack_Info(command_casted.direction);

                current_action=attack_component;
            }
                break;
        }
    }
}
