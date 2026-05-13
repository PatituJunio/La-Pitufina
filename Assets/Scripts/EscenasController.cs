using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenasController : MonoBehaviour
{
   
    public class CambioEscena : MonoBehaviour
    {
        public void CargarNivel(string nombreEscena)
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }

  
}
