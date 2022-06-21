using UnityEngine;

public class Attack : IAction {
    [SerializeField] Direction current_direction;
    [SerializeField] Charactor_Paramater param;
    [SerializeField] CurrentPosition_OnMap current_index_position;
    [SerializeField] MAP map;
    [SerializeField] Check_PositionInMap position_check;
    
    public void SetAttack_Info(Direction d) {
        current_direction = d;

        Damage();
    }

    public override bool _update() {
        return true;
    }

    // 対象にダメージを与える処理
    void Damage() {
        // 方向から座標を計算
        Vector2Int target_position = current_index_position.index + Direciton_Table.Direction_To_Table(current_direction);

        // 範囲外参照ガード
        if(position_check.DynamicObject_Map(target_position)) return;

        // 座標から攻撃を与えるオブジェクトを取得
        Transform target_transform = map.dynamic_object_map[target_position.x, target_position.y];

        var target_param = target_transform.GetComponent<Charactor_Paramater>();

        // ダメージを与える
        target_param.Damage(param.attak);
    }

    void Reset() {
        param                  = GetComponent<Charactor_Paramater>();
        current_index_position = GetComponent<CurrentPosition_OnMap>();

        map                    = Resources.FindObjectsOfTypeAll<MAP>()[0];
        position_check         = Resources.FindObjectsOfTypeAll<Check_PositionInMap>()[0];
    }
}