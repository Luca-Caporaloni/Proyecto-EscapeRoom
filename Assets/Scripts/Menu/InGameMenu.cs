using UnityEngine;
using TMPro;

public class InGameMenu : MonoBehaviour
{
    public GameObject menuCanvas; // Referencia al Canvas del menú
    public TMP_Text instructionsText; // Referencia al TextMeshPro para las instrucciones
    public TMP_Text controlsText; // Referencia al TextMeshPro para los controles
    public TMP_Text tipsText; // Referencia al TextMeshPro para los consejos
    public TMP_Text objectivesText; // Referencia al TextMeshPro para los objetivos
    private bool isMenuActive = false;

    void Start()
    {
        menuCanvas.SetActive(false); // Asegúrate de que el menú esté desactivado al inicio
        UpdateInstructions(); // Actualizar las instrucciones al inicio
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) // Presiona M para abrir/cerrar el menú
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        isMenuActive = !isMenuActive;
        menuCanvas.SetActive(isMenuActive);
        Cursor.lockState = isMenuActive ? CursorLockMode.None : CursorLockMode.Locked; // Liberar o bloquear el cursor
        Cursor.visible = isMenuActive; // Hacer visible o invisible el cursor
    }

    public void UpdateInstructions()
    {
        instructionsText.text = "Presiona M para abrir el menú de ayuda.\n" +
                                "Presiona E para interactuar con objetos.\n" +
                                "Presiona F para inspeccionar objetos.\n" +
                                "Presiona Esc para pausar el juego.";

        controlsText.text = "Controles:\n" +
                            "\n" +
                            "Moverse: W, A, S, D\n" +
                            "Agacharse: Ctrl";

        tipsText.text = "Consejos:\n" +
                        "\n" +
                        "Revisa todos los rincones para encontrar objetos útiles.\n" +
                        "Algunos objetos pueden ser inspeccionados más de cerca.\n" +
                        "Si te quedas atascado, revisa las pistas que has encontrado.";

        objectivesText.text = "Objetivos:\n" +
                              "Objetivo actual: Encuentra la tarjeta de acceso.\n" +
                              "Objetivos secundarios: Explora la habitación para encontrar pistas.\n";
    }

    // Método para cerrar el menú desde un botón
    public void CloseMenu()
    {
        isMenuActive = false;
        menuCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
