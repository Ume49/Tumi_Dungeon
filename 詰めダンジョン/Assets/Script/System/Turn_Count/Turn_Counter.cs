using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Counter : MonoBehaviour
{
    public int turn_limit;

    [SerializeField] Process_StateMachine statemachine;
    [SerializeField] Process_StateMachine.State past_state;

    public void turn_decrement() {
        turn_limit--;
    }
}
