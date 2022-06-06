using UnityEngine;

public class HP0_Vanish : MonoBehaviour {
    [SerializeField] private Charactor_Paramater param;
    [SerializeField] Now_Position_onMap position;
    [SerializeField] MAP map;

    private void Reset() {
        param = GetComponent<Charactor_Paramater>();
        position = GetComponent<Now_Position_onMap>();
        map = Resources.FindObjectsOfTypeAll<MAP>()[0];
    }

    private void Update() {
        if (param.hp <= 0) {
            Vanish();
        }
    }

    // 消滅処理
    private void Vanish() {
        // マップ上から削除
        map.dynamic_object_map[position.index.x, position.index.y] = null;

        // シーン上から削除
        Destroy(this.gameObject);
    }
}