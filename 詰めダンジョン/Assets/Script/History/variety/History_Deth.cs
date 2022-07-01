using UnityEngine;

public class History_Deth : IHistory{
    public Transform dead_charactor;

    public History_Deth(Transform dead_charactor) : base(IHistory.ID.Deth, dead_charactor)
    {
        this.dead_charactor = base.target_charactor;
    }
}