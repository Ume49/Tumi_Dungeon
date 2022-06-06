using UnityEngine;

public class TurnCount_Decrement : ITE_Process {
    [SerializeField] private Turn_Counter turn;

    public override void Execute() {
        // c‚èè”‚ğŒ¸­‚³‚¹‚é
        turn--;
    }
}