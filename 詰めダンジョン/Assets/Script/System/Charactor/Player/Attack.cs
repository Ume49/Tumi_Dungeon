using UnityEngine;

public class Attack : IAction {
    [SerializeField] private Direction current_direction;
    [SerializeField] private Charactor_Paramater param;
    [SerializeField] private Now_Position_onMap current_index_position;
    [SerializeField] MAP map;

    public void SetAttack_Info(Direction d) {
        current_direction = d;

        Damage();
    }

    public override bool _update() {
        return true;
    }

    // �ΏۂɃ_���[�W��^���鏈��
    private void Damage() {
        // ����������W���v�Z
        Vector2Int target_position = current_index_position.index + Direciton_Table.Direction_To_Table(current_direction);

        // ���W����U����^����I�u�W�F�N�g���擾
        Transform target_transform = map.dynamic_object_map[target_position.x, target_position.y];

        // null����
        if (target_transform == null) { Debug.LogError("�U���Ώۂ����܂���I"); }

        var target_param = target_transform.GetComponent<Charactor_Paramater>();

        // �_���[�W��^����
        target_param.hp -= param.attak;
    }

    private void Reset() {
        param = GetComponent<Charactor_Paramater>();
        current_index_position = GetComponent<Now_Position_onMap>();

        map = Resources.FindObjectsOfTypeAll<MAP>()[0];
    }
}