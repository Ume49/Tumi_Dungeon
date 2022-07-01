using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rcommand_Pickup : IReverseCommand
{
    public Rcommand_Pickup(Transform chara) : base(IReverseCommand.ID.Pickup, chara)
    {
        
    }
}
