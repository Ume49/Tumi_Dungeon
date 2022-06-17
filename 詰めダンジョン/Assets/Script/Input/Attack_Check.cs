using UnityEngine;

public class Attack_Check : MonoBehaviour {
    [SerializeField] Transform player;
    [SerializeField] Process_StateMachine stateMachine;

    // プレイヤーとの紐づけで取得できるやつら
    Player_Action_Controller command_controller;
    Attack attack_script;
    Front player_front;
    CurrentPosition_OnMap player_pos;

    void Awake() {
        command_controller = player.GetComponent<Player_Action_Controller>();
        attack_script      = player.GetComponent<Attack>();
        player_front       = player.GetComponent<Front>();
        player_pos         = player.GetComponent<CurrentPosition_OnMap>();
    }

    private void Update() {
        if (Input.GetButtonDown("A")) {
            // 攻撃コマンド作成
            command_controller.command=new Command_Attack(player, player_front.direction);

            // 次のステートへ遷移
            stateMachine.state++;
        }
    }
}