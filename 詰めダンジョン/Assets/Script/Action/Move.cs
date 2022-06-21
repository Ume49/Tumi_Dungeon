using UnityEngine;

/// <summary>
/// 実際の座標上でもマップ上でも動かす
/// 動かしたい奴にアタッチする
/// </summary>
public class Move : IAction {
    [SerializeField] IndexToPos indexToPos;
    [SerializeField] DynamicMap_Move map_mover;
    [SerializeField] CurrentPosition_OnMap player_index_pos;
    [SerializeField] float speed;
    [SerializeField] Vector3 destination;
    [SerializeField] History_Stocker history;

    // 履歴作成用
    Vector2Int destination_onMap;
    Vector2Int past_pos_onMap;

    public void SetDestination(Vector2Int destination_index) {
        // 履歴作成用に目的地と出発地を保存
        destination_onMap = destination_index;
        past_pos_onMap    = player_index_pos.index;

        // 実際の移動に使う座標を決定
        destination = indexToPos.Get(destination_index);

        // マップ上での位置を変更
        map_mover.Move(player_index_pos.index, destination_index);

        // キャラクターが持っているインデックス座標を変更
        player_index_pos.index = destination_index;
    }

    public override bool _update() {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        // 目的地に到達してたら履歴を作成して処理を終了
        if(transform.position == destination){
            history.Add(new History_Move(transform, past_pos_onMap, destination_onMap));
            return true;
        }

        return false;
    }

    private void Reset() {
        player_index_pos = GetComponent<CurrentPosition_OnMap>();

        indexToPos = Resources.FindObjectsOfTypeAll<IndexToPos>()[0];
        map_mover  = Resources.FindObjectsOfTypeAll<DynamicMap_Move>()[0];
    }
}