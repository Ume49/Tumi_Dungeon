using UnityEngine;

// 静的オブジェクトの識別タグ
public class Static_Object_Tag : MonoBehaviour {

    // 種類
    public enum Kind {
        Null,
        Goal
    }

    public Kind value;
}