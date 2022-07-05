using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call_PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Process_StateMachine state;

    // プレイヤーとの紐づけで取得できる連中
    Player_Action_Controller    controller;
    Front                       player_front;
    CurrentPosition_OnMap       player_pos;

    void Awake() {
        controller      = player.GetComponent<Player_Action_Controller>();
        player_front    = player.GetComponent<Front>();
        player_pos      = player.GetComponent<CurrentPosition_OnMap>();
    }

    public void Call() {
        // 攻撃コマンド作成
        controller.command = new Command_Attack(player, player_front.direction);

        // 次のステートへ遷移させる
        state++;
    }
}
