using System.Collections.Generic;
using UnityEngine;
using System;

public class Process_StateMachine : MonoBehaviour
{
    public enum State : int
    {
        Input_Check,    // 入力確�?
        Player_Act,     // プレイヤーキャラの行動
        Enemy_Judge,    // エネミーの行動決�?
        Enemy_Act       // エネミーの行動
    }

    [SerializeField] State state_data;

    [Header("ス�?ートによって有効化状態を管�?するスクリプト")]
    [SerializeField]
    List<MonoBehaviour> input_check_script;
    [SerializeField]
    List<MonoBehaviour> player_act_script;
    [SerializeField]
    List<MonoBehaviour> enemy_judge_script;
    [SerializeField]
    List<MonoBehaviour> enemy_act_script;


    public State state
    {
        get
        {
            return state_data;
        }
        set
        {
            state_data = value;

            Switch();
        }
    }

    public void Set_NextState()
    {
        state = (State)((int)(state_data + 1) % 4);
    }



    private void Start()
    {
        Switch();
    }

    // 現在のス�?ートと対応するもの�?け有効�?
    void Switch()
    {
        // 現在のス�?ートに対応したもの以外�?�て無効�?
        Action<List<MonoBehaviour>> all_disenable = x => { foreach (var w in x) { w.enabled = false; } };

        // 一旦全部無効�?
        all_disenable(input_check_script);
        all_disenable(player_act_script);
        all_disenable(enemy_judge_script);
        all_disenable(enemy_act_script);

        // 現在のス�?ートと対応するもの�?け有効�?
        switch (state_data)
        {
            case State.Input_Check:
                input_check_script.ForEach(x => x.enabled = true);
                break;
            case State.Player_Act:
                player_act_script.ForEach(x => x.enabled = true);
                break;
            case State.Enemy_Judge:
                enemy_judge_script.ForEach(x => x.enabled = true);
                break;
            case State.Enemy_Act:
                enemy_act_script.ForEach(x => x.enabled = true);
                break;
        }
    }
}
