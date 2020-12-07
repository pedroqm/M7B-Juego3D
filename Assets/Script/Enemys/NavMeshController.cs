using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public Transform objetivo;
    public NavMeshAgent agente;

    [SerializeField]
    private float distance;

    private void Update()
    {
        distance = Vector3.Distance(agente.transform.position, objetivo.transform.position);
        if (distance < 8f)
        {
            agente.destination = objetivo.position;
        }
        else
        {
            agente.destination = transform.position;
        }
    }
}
