using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rcommand_Move : IReverseCommand
{
    public Vector2Int start_pos;
    public Vector2Int end_pos;

    public Transform move_chara;

    public Rcommand_Move(Transform move_chara, Vector2Int past_pos, Vector2Int destinatino_pos) : base(IReverseCommand.ID.Move, move_chara)
    {
        this.move_chara = base.target_chara;

        // 履歴とは逆方向に動きたいので、目的地と出発地が逆になることに注意
        this.start_pos  = destinatino_pos;
        this.end_pos    = past_pos;
    }
}
