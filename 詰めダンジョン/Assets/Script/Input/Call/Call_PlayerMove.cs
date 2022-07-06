using UnityEngine;

public class Call_PlayerMove : MonoBehaviour 
{
    [SerializeField] Transform player;

    // playerから引っ張ってこれるもの
    CurrentPosition_OnMap    player_pos;
    Player_Action_Controller player_controller;

    // System
    [SerializeField] Movable_Checker        movable_Checker;
    [SerializeField] IndexToPos             indexToPos;
    [SerializeField] Process_StateMachine   state;
    
    void Awake() {
        // playerから引っ張ってくる
        player_pos        = player.GetComponent<CurrentPosition_OnMap>();
        player_controller = player.GetComponent<Player_Action_Controller>();
    }

    /// <summary>
    /// direction_input: 動く方向
    /// </summary>
    public void Call(Direction direction_input){
        {   // 移動先が実際に移動できる場所なのかチェック
            // 方向をベクトルに変換
            Vector2Int move_vec = Direciton_Table.Direction_To_Pos(direction_input);

            // 目的地を導出
            Vector2Int destination = move_vec + player_pos.value;

            // 移動できないなら処理を中断して終わり
            if(movable_Checker.Check(destination) != true){
                // TODO ビープ音流すとかの専用処理する
                #if UNITY_EDITOR
                Debug.Log("そっちには進めないよ！");
                #endif

                return;
            }
        }

        // 辿りつけたなら移動コマンド作成
        player_controller.command = new Command_Move(direction_input, player);

        // 行動を決定したのでステート遷移
        state++;
    }
}