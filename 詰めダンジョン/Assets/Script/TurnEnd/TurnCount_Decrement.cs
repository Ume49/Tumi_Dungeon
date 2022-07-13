using UnityEngine;

public class TurnCount_Decrement : ITE_Process {
    [SerializeField] private Turn_Counter turn;

    public override void Execute() {
        // 残り手数を減少させる
        turn--;
    }
}