using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Action_Controller : MonoBehaviour
{
    public enum Action
    {
        CannotMove,
        Move,
        Attack
    }

    public Action current_action;

    [SerializeField] IAction cannot_move_script;
    [SerializeField] IAction move_script;
    [SerializeField] IAction attack_script;

    private void Update()
    {
        // ステートに合わせて専用の更新関数呼び出し
        switch (current_action)
        {
            case Action.Move:
                move_script._update();
                break;
            case Action.CannotMove:
                cannot_move_script._update();
                break;
            case Action.Attack:
                attack_script._update();
                break;
        }
    }
}
