using UnityEngine;

public class Under_Checker : MonoBehaviour {
    [SerializeField] private MAP map;
    [SerializeField] private Now_Position_onMap index_position;

    // �����m�F
    public Static_Object_Tag.Kind Check() {

        // �����̃I�u�W�F�N�g��Transform���擾
        var under_obj_transform = map.static_object_map[index_position.index.x, index_position.index.y];

        // ��Ȃ�Null��Ԃ�
        if (under_obj_transform == null) return Static_Object_Tag.Kind.Null;

        // �����ɓ��B�ł��Ă鎞�_�Œ��g������̂ŁA������擾���ĕԂ�
        return under_obj_transform.GetComponent<Static_Object_Tag>().value;
    }

    private void Reset() {
        map = Resources.FindObjectsOfTypeAll<MAP>()[0];

        index_position = GetComponent<Now_Position_onMap>();
    }
}