using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Process_StateMachine stateMachine;
    public Vector3 destination;
    private void OnEnable()
    {

    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (transform.position == destination) this.enabled = false;
    }
}
