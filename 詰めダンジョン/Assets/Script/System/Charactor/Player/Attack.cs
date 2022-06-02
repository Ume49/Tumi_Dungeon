using UnityEngine;

public class Attack : IAction {
    [SerializeField] private Direction current_direction;
    [SerializeField] private Charactor_Paramater param;
    [SerializeField] private Now_Position_onMap current_index_position;

    public void SetAttack_Info(Direction d) {
    }

    // 対象にダメージを与える処理
    private void Damage() {
        // 方向から座標を計算
        Vector2Int target_position = current_index_position.index + Direciton_Table.Direction_To_Table(current_direction);


    }

    public override bool _update() {
        return true;
    }
}