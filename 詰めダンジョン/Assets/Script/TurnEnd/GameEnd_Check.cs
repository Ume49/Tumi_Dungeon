using UnityEngine;

public class GameEnd_Check : ITE_Process {
    [SerializeField] private Turn_Counter turn;
    [SerializeField] private StageEnd stage_end;

    public override void Execute() {
        if (turn.turn_limit > 0) return;
        // ターンが残っておらず、ここまで辿り着いたならゲームオーバー
        stage_end.GameOver();
    }
}