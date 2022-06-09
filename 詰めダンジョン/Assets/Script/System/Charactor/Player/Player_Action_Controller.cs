using UnityEngine;

public class Player_Action_Controller : MonoBehaviour {

    public enum Action {
        CannotMove,
        Move,
        Attack
    }

    public Action current_action;

    [SerializeField] private IAction cannot_move_script;
    [SerializeField] private IAction move_script;
    [SerializeField] private IAction attack_script;
    [SerializeField] private Process_StateMachine stateMachine;
    [SerializeField] private Turn_Counter turn_counter;

    private void Update() {
        bool action_result = false;

        // ステートに合わせて専用の更新関数呼び出し
        switch (current_action) {
            case Action.Move:
                action_result = move_script._update();
                break;

            case Action.CannotMove:
                action_result = cannot_move_script._update();
                break;

            case Action.Attack:
                action_result = attack_script._update();
                break;
        }

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