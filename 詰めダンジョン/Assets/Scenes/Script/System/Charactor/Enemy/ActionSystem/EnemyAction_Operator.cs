using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction_Operator : MonoBehaviour
{
    public Queue<IAction> actions;

    [SerializeField] private IAction current_action;
    [SerializeField] Process_StateMachine state;

    private void OnEnable()
    {
        // �L���[����擪�̃I�u�W�F�N�g���󂯎��
        current_action = actions.Dequeue();
    }

    void Update()
    {
        // �����Ăяo��
        bool flag = current_action._update();

        if (flag)
        {
            if (actions.Count > 0)
            {
                // ���݂̏������I�����A�܂��\�񂳂ꂽ�s�����c���Ă���ꍇ�͎��̍s�������o��
                current_action = actions.Dequeue();
            }
            else
            {
                // ���݂̏������I���������_�ŁA���ׂĂ̏������I�����Ă���ꍇ�̓X�e�[�g��ύX
                state.Set_NextState();
            }
        }
    }
}
