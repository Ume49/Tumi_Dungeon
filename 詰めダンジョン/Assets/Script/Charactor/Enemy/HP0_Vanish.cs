using UnityEngine;

public class HP0_Vanish : MonoBehaviour {
    [SerializeField] private Charactor_Paramater param;
    [SerializeField] CurrentPosition_OnMap position;
    [SerializeField] MAP map;

    private void Reset() {
        param = GetComponent<Charactor_Paramater>();
        position = GetComponent<CurrentPosition_OnMap>();
        map = Resources.FindObjectsOfTypeAll<MAP>()[0];
    }

    private void Update() {
        if (param.hp <= 0) {
            Vanish();
        }
    }

    // ���ŏ���
    private void Vanish() {
        // �}�b�v�ォ��폜
        map.dynamic_object_map[position.index.x, position.index.y] = null;

        // �V�[���ォ��폜
        Destroy(this.gameObject);
    }
}