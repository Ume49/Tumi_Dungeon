using UnityEngine;

public abstract class IHistory
{
    // 中身が何なのか識別するID
    public enum ID
    {
        Move,
        Attack,
        Pickup,
        Deth,
        ChageFront
    }

    public ID id;
    
    // ふんわりと「なにかしたキャラクター」
    // * 派生クラスでより具体的な名前にする
    public Transform target_charactor;

    public IHistory( ID id, Transform target ){
        this.id               = id;
        this.target_charactor = target;
    }
}
