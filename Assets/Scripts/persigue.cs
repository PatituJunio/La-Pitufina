using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class persigue : MonoBehaviour
{
    [SerializeField]
    private Transform objetivo;
    [SerializeField]
    private NavMeshAgent perseguidor;




    // Start is called before the first frame update
    void Start()
    {
        perseguidor.updateRotation = false;
        perseguidor.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        perseguidor.destination = objetivo.position;
    }
}