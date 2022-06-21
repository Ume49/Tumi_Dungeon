using UnityEngine;

public class Under_Checker : MonoBehaviour {
    [SerializeField] private MAP map;
    [SerializeField] private CurrentPosition_OnMap index_position;

    // 足元確認
    public Static_Object_Tag.Kind Check() {

        // 足元のオブジェクトのTransformを取得
        var under_obj_transform = map.static_object_map[index_position.index.x, index_position.index.y];

        // 空ならNullを返す
        if (under_obj_transform == null) return Static_Object_Tag.Kind.Null;

        // ここに到達できてる時点で中身があるので、それを取得して返す
        return under_obj_transform.GetComponent<Static_Object_Tag>().value;
    }

    private void Reset() {
        map = Resources.FindObjectsOfTypeAll<MAP>()[0];

        index_position = GetComponent<CurrentPosition_OnMap>();
    }
}