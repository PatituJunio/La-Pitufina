using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoscasController : MonoBehaviour
{
    [SerializeField] GameObject lamosca;
    [SerializeField] Vector3 ubicacion;
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(lamosca, new Vector3(0, 0, 0), Quaternion.identity);
        InvokeRepeating("CrearMosca",0f,2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CrearMosca()
    {
         Instantiate(lamosca, ubicacion, Quaternion.identity);
    }
}
