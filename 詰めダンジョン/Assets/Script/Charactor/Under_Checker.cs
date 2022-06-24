using UnityEngine;

public class Under_Checker : MonoBehaviour, ISingletonAttach, IBroComponent_Attach
{
    [SerializeField] MAP map;
    [SerializeField] CurrentPosition_OnMap index_position;

    // 足元確認
    public Static_Object_Tag.Kind Check() {

        // 足元のオブジェクトのTransformを取得
        var under_obj_transform = map.static_object_map[index_position.index.x, index_position.index.y];

        // 空ならNullを返す
        if (under_obj_transform == null) return Static_Object_Tag.Kind.Null;

        // ここに到達できてる時点で中身があるので、それを取得して返す
        return under_obj_transform.GetComponent<Static_Object_Tag>().value;
    }

    public void Singleton_Attach(){
        map = Resources.FindObjectsOfTypeAll<MAP>()[0];
    }

    public void Brother_Attach(){
        index_position = GetComponent<CurrentPosition_OnMap>();
    }
}