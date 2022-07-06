using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class All_Trim : MonoBehaviour
{
    [SerializeField] Transform parent;
    public void Trim()
    {
        // 子オブジェクトを取得するリストを作成して、取得
        List<Transform> all_children = new List<Transform>();
        GetAllChildren.Get(parent, all_children);

        // 整形クラスリストを作成して取得
        List<Posiition_Trimmer> trimmer_list = new List<Posiition_Trimmer>();
        foreach (Transform w in all_children)
        {
            Posiition_Trimmer posiition_Trimmer;
            if (w.TryGetComponent<Posiition_Trimmer>(out posiition_Trimmer))
            {
                trimmer_list.Add(posiition_Trimmer);
            }
        }

        // 整形関数呼び出し
        trimmer_list.ForEach(x => x.Trim());
    }
}
