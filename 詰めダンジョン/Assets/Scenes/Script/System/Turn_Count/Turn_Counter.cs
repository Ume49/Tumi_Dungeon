using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Counter : MonoBehaviour
{
    public int turn_limit;

    [SerializeField] Process_StateMachine statemachine;
    [SerializeField] Process_StateMachine.State past_state;

    private void Start() {
    }

    private void Update() {
        // �v���C���[���ҋ@�ȊO�̍s����������ꍇ�ɃJ�E���^�[������������

        if (past_state == statemachine.state) return;

        // ���݂̃X�e�[�g���^�[���ŏ��A�����O�̃X�e�[�g���^�[���Ō�̏ꍇ�̂ݏ���
        if (statemachine.state != Process_StateMachine.State.Input_Check) return;
        if (statemachine.state != Process_StateMachine.State.Enemy_Act) return;

        // �J�E���^����
        turn_limit--;
    }

    private void LateUpdate() {
        past_state = statemachine.state;
    }
}
