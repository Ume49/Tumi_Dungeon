using UnityEngine;

public class Attack : IAction {
    [SerializeField] private Direction current_direction;
    [SerializeField] private Charactor_Paramater param;
    [SerializeField] private Now_Position_onMap current_index_position;

    public void SetAttack_Info(Direction d) {
    }

    // �ΏۂɃ_���[�W��^���鏈��
    private void Damage() {
        // ����������W���v�Z
        Vector2Int target_position = current_index_position.index + Direciton_Table.Direction_To_Table(current_direction);


    }

    public override bool _update() {
        return true;
    }
}