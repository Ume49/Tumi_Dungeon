using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestination
{
    public static void Set(Transform target, Vector3 destination)
    {
        target.GetComponent<Move>().destination = destination;
    }
}
