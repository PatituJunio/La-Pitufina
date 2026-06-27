using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitufinaAnimacionesController : MonoBehaviour
{
    [SerializeField] private Animator animador;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            animador.Play("PitufinaComiendo");
        }
        else { animador.Play("PituAndando"); }
    }
}
