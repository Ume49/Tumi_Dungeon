using UnityEngine;

public class GameEnd_Check : ITE_Process {
    [SerializeField] private Turn_Counter turn;
    [SerializeField] private StageEnd stage_end;

    public override void Execute() {
        if (turn.turn_limit > 0) return;
        // �^�[�����c���Ă��炸�A�����܂ŒH�蒅�����Ȃ�Q�[���I�[�o�[
        stage_end.GameOver();
    }
}