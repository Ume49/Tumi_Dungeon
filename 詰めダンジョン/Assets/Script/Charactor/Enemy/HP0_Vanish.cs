using UnityEngine;

public class HP0_Vanish : MonoBehaviour, ISingletonAttach
{
    [SerializeField] private Charactor_Paramater param;
    [SerializeField] CurrentPosition_OnMap position;
    [SerializeField] MAP map;
    [SerializeField] History_Stocker history;

    private void Reset() {
        param    = GetComponent<Charactor_Paramater>();
        position = GetComponent<CurrentPosition_OnMap>();
    }

    public void Singleton_Attach(){
        map      = Resources.FindObjectsOfTypeAll<MAP>()[0];
        history  = Resources.FindObjectsOfTypeAll<History_Stocker>()[0];
    }

    void Update() {
        // 呼び出しのタイミングが雑なため、履歴オブジェクトが変になってしまうなど不都合が生じた場合は、ステートマシンとかで呼び出すこと
        if (param.hp <= 0) {
            Vanish();
        }
    }

    // 消滅処理
    private void Vanish() {
        // マップ上から削除
        map.dynamic_object_map[position.index.x, position.index.y] = null;

        // シーン上から削除
        // DestroyではなくSetActiveなのはUndo操作によって復活させる可能性があるため
        transform.gameObject.SetActive(false);

        // 死んだので履歴を投げる
        history.Add(new History_Deth(transform));
    }
}