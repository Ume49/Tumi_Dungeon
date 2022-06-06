using UnityEngine;

public class Attack_Check : MonoBehaviour {
    [SerializeField] private Player_Action_Controller attack_controller;
    [SerializeField] private Attack attack_script;
    [SerializeField] private Front player_front;
    [SerializeField] private Process_StateMachine stateMachine;

    private void Update() {
        if (Input.GetButtonDown("A")) {
            // 攻撃予約
            attack_controller.current_action = Player_Action_Controller.Action.Attack;

            // 攻撃方向を決定しておく
            attack_script.SetAttack_Info(player_front.direction);

            // ステート変更
            stateMachine.state = Process_StateMachine.State.Player_Act;
        }
    }
}