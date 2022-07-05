using UnityEngine;

public class Move_Check : MonoBehaviour {
    [SerializeField] Transform player;
    [SerializeField] Movable_Checker movable_Checker;
    [SerializeField] IndexToPos indexToPos;
    [SerializeField] Process_StateMachine stateMachine;

    // playerから引っ張ってこれるやつら
    CurrentPosition_OnMap player_pos_index;
    Move player_move_script;
    Player_Action_Controller controller;

    void Awake() {
        player_move_script = player.GetComponent<Move>();
        player_pos_index   = player.GetComponent<CurrentPosition_OnMap>();
        controller         = player.GetComponent<Player_Action_Controller>();
    }

    void Update() {
        var input_result = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // 何もないなら以降の処理はスキップ
        if (input_result.x == 0.0f && input_result.y == 0.0f) return;

        // 縦と横が同時に押されている場合もスキップ
        if (Mathf.Abs(input_result.x) == Mathf.Abs(input_result.y)) return;

        // ここまでたどり着いているなら移動方向の計算をする
        // 以下それ用の処理

        Direction move_direction;

        // 入力から方向を特定
        if      (input_result.x == 1.0f)
            move_direction = Direction.RIGHT;
        else if (input_result.x == -1.0f)
            move_direction = Direction.LEFT;
        else if (input_result.y == 1.0f)
            move_direction = Direction.UP;
        else
            move_direction = Direction.DOWN;

        // *移動したい場所が実際に行ける場所なのかどうかチェックする
        
        // 方向を添え字ベクトルに変換
        Vector2Int index_vec = Direciton_Table.Direction_To_Table(move_direction);
    
        // 目的地を計算
        Vector2Int current_destination = index_vec + player_pos_index.value;

        // 目的地が侵入可能かどうか 侵入不可ならスキップ
        if (movable_Checker.Check(current_destination)!=true) {
            // TODO: ビープ音を流すとか、専用の処理をする
            Debug.Log("そっちには進めないよ！");
            return;
        }

        // すべての条件を満たしたならコマンドを作成
        controller.command = new Command_Move(move_direction, player);

        // 行動を決定したので次のステートに遷移
        stateMachine.state++;
    }
}