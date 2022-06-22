using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// このステージでのすべての行動履歴
public class History_Stocker : MonoBehaviour
{
    List<OneTurnHistory> histories;

    ///<summary>履歴閲覧用オブジェクトを返す</summary>
    public OneTurnHistory[] histroy_view{
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
}
