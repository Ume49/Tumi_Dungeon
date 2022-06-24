using UnityEngine;

public class History_Deth : IHistory{
    public Transform dead_charactor;

    public History_Deth(Transform dead_charactor){
        this.dead_charactor = dead_charactor;

        base.id = IHistory.ID.Deth;
    }
}