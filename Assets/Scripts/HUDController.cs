using UnityEngine;
using TMPro; // Requerido para usar TextMeshPro

public class HUDController : MonoBehaviour
{
    [Header("Componentes de Texto de la UI")]
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoVidas;
    public TextMeshProUGUI textoEnergia;

    public GameObject anteojosUI;

    private void Update()
    {
        // Verifica que el GameManager exista antes de leer los datos
        if (GameManagerController.instance != null)
        {
            textoPuntos.text = "Puntos: " + GameManagerController.instance.puntos;
            textoVidas.text = "Vidas: " + GameManagerController.instance.vidas;
            textoEnergia.text = "Energía: " + Mathf.RoundToInt(GameManagerController.instance.energia) + "%";
            anteojosUI.SetActive( GameManagerController.instance.tieneAnteojos);
        }
    }
}
