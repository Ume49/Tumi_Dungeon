using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICommand : MonoBehaviour
{
    // Ž¯•Ê—pID
    public enum Command_ID
    {
        Move,
        Attack,
        PickUp_Item
    }

    Command_ID command_id;
}
