using System.Collections.Generic;
using UnityEngine;

public class TurnEnd_Operator : MonoBehaviour {
    [SerializeField] private Process_StateMachine state;
    [SerializeField] private List<ITE_Process> once_process;

    private void OnEnable() {
        foreach (var w in once_process) { w.Execute(); }

        // �������S���I������̂ŃX�e�[�g�J��
        state++;
    }
}