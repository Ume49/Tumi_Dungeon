using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 死亡の逆なので復活
public class Rcommand_Death : IReverseCommand
{
    public Transform resolve_chara;

    public Rcommand_Death(Transform dead_charactor) : base(IReverseCommand.ID.Death, dead_charactor)
    {
        this.resolve_chara = base.target_chara;
    }
}
