using UnityEngine;

public class Attack : IAction {
    [SerializeField] Direction current_direction;
    [SerializeField] Charactor_Paramater attack_param;
    [SerializeField] CurrentPosition_OnMap current_index_position;
    [SerializeField] MAP map;
    [SerializeField] Check_PositionInMap position_check;
    [SerializeField] History_Stocker history;

    public void SetAttack_Info(Direction d) {
        current_direction = d;

        Damage();
    }

    public override bool _update() {
        return true;
    }

    // �ΏۂɃ_���[�W��^���鏈��
    void Damage() {
        // ����������W���v�Z
        Vector2Int target_position = current_index_position.value + Direciton_Table.Direction_To_Pos(current_direction);

        // �͈͊O�Q�ƃK�[�h
        if(position_check.DynamicObject_Map(target_position)) return;

        // ���W����U����^����I�u�W�F�N�g���擾
        Transform target_transform = map.dynamic_object_map[target_position.x, target_position.y];

        // �k���Q�ƃK�[�h
        if(target_transform==null) return;

        var target_param = target_transform.GetComponent<Charactor_Paramater>();

        int damage=CulcDamage.Culc(attack_param, target_param);

        // �_���[�W��^����
        target_param.Damage(damage);

        // �U���������̂ŗ������쐬
        history.Add(new History_Attack(target_transform, damage));
    }

    void Reset() {
        attack_param           = GetComponent<Charactor_Paramater>();
        current_index_position = GetComponent<CurrentPosition_OnMap>();

        map                    = Resources.FindObjectsOfTypeAll<MAP>()[0];
        position_check         = Resources.FindObjectsOfTypeAll<Check_PositionInMap>()[0];
    }
}