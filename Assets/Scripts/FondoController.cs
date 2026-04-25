using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoController : MonoBehaviour
{
    private float posInicial;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(posInicial+distancia,transform.position.y,transform.position.z);

    }
}
