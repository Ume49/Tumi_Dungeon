using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// このステージでのすべての行動履歴
public class History_Stocker : MonoBehaviour
{
    List<OneTurnHistory> histories;

    ///<summary>履歴閲覧用オブジェクトを返す</summary>
    public OneTurnHistory[] history_view{
        get{
            return histories.ToArray();
        }
    }

    void Awake()
    {
        // Unityの方でシリアライズされないので明示的にインスタンス作成
        histories=new List<OneTurnHistory>();
    }

    void Start()
    {
        Make_NewTurn_History();
    }

    // このターンの履歴を記録する箱を作る
    public void Make_NewTurn_History()
    {
        histories.Add(new OneTurnHistory());
    }

    public void Add(IHistory new_history)
    {
        histories[histories.Count - 1].Add(new_history);
    }

    /// <summary>
    /// 1ターン分の履歴オブジェクトを返す 返した分はこっちのコンテナから削除される、Stack.Popみたいな挙動
    /// </summary>
    /// <returns>成功したらtrue、失敗したらfalse</returns>
    public bool tryPop(out OneTurnHistory out_history){
        // 1個もないなら処理を終了
        if(histories.Count <= 0){
            out_history = null;
            return false;
        }

        // 末尾のインデックス
        int last_id = histories.Count-1;

        var last_OTH=histories[last_id];

        histories.RemoveAt(last_id);

        out_history = last_OTH;

        return true;
    }
}
