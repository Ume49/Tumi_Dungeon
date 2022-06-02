using UnityEngine;

public class Move_Check : MonoBehaviour {
    [SerializeField] private Now_Position_onMap player_pos_index;
    [SerializeField] private Move player_move_script;
    [SerializeField] private Movable_Checker movable_Checker;
    [SerializeField] private Player_Action_Controller controller;
    [SerializeField] private IndexToPos indexToPos;
    [SerializeField] private Process_StateMachine stateMachine;

    private void Update() {
        var input_result = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // 何もないなら以降の処理はスキップ
        if (input_result.x == 0.0f && input_result.y == 0.0f) return;

        // 縦と横が同時に押されている場合もスキップ
        if (Mathf.Abs(input_result.x) == Mathf.Abs(input_result.y)) return;

        // *移動をセット

        // 方向添え字ベクトルを計算
        Vector2Int index_vec;

        {
            Direction current_direction;

            // 入力から方向を特定
            if (input_result.x == 1.0f)
                current_direction = Direction.RIGHT;
            else if (input_result.x == -1.0f)
                current_direction = Direction.LEFT;
            else if (input_result.y == 1.0f)
                current_direction = Direction.UP;
            else
                current_direction = Direction.DOWN;

            // 方向を添え字ベクトルに変換
            index_vec = Direciton_Table.Direction_To_Table(current_direction);
        }

        // 目的地を計算
        Vector2Int current_destination = index_vec + player_pos_index.index;

        // 目的地が侵入可能かどうかチェックして、コントローラーに行動予約
        if (movable_Checker.Check(current_destination)) {   // 行ける場合
            controller.current_action = Player_Action_Controller.Action.Move;

            // ワールド座標の目的地をセット
            player_move_script.SetDestination(current_destination);
        }
        else {   // 行けない場合
            controller.current_action = Player_Action_Controller.Action.CannotMove;
        }

        // 行動を決定したので次のステートをセット
        stateMachine.state = Process_StateMachine.State.Player_Act;
    }
}