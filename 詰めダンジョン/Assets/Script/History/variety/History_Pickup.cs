using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History_Pickup : IHistory
{
    public History_Pickup(Transform chara) : base(IHistory.ID.Pickup, chara)
    {

    }
}
