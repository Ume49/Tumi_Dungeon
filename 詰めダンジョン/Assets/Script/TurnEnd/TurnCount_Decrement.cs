using UnityEngine;

public class TurnCount_Decrement : ITE_Process {
    [SerializeField] private Turn_Counter turn;

    public override void Execute() {
        // �c��萔������������
        turn--;
    }
}