using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Action_Controller : MonoBehaviour
{
    public enum Action
    {
        Null,
        CannotMove,
        Move,
        Attack
    }

    public Action current_action;

    [SerializeField] MonoBehaviour cannot_move_script;
    [SerializeField] MonoBehaviour move_script;
    [SerializeField] MonoBehaviour attack_script;

    private void OnEnable()
    {
        // とりあえず全部無効化
        cannot_move_script.enabled = false;
        move_script.enabled = false;
        attack_script.enabled = false;

        // 有効化された時にどの行動スクリプトを有効化するのか判断
        switch (current_action)
        {
            case Action.CannotMove:
                cannot_move_script.enabled = true;
                break;
            case Action.Move:
                move_script.enabled = true;
                break;
            case Action.Attack:
                attack_script.enabled = true;
                break;
        }
    }

    private void OnDisable()
    {
        // 全部無効化
        cannot_move_script.enabled = false;
        move_script.enabled = false;
        attack_script.enabled = false;
    }
}
