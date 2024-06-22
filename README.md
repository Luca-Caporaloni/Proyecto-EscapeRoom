# EscapeRoom Phsiquiatra

## Uso

- Funcionalidades principales

- Puzzles Interactivos: Los jugadores pueden interactuar con objetos del entorno para descubrir pistas.

- Sistema de Inventario: Recolecta y utiliza objetos clave para avanzar en el juego.

- Integración de Keypad: Introduce códigos en teclados virtuales para desbloquear puertas y obtener acceso a nuevas áreas.


## Código - Keypad.cs

´´´
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text displayText;
    [SerializeField] private Animator doorAnimator;
    private string correctCode = "123456";

    public void EnterDigit(int digit)
    {
        displayText.text += digit.ToString();
    }

    public void SubmitCode()
    {
        if (displayText.text == correctCode)
        {
            displayText.text = "Correcto";
            doorAnimator.SetBool("Open", true);
            StartCoroutine(CloseDoor());
        }
        else
        {
            displayText.text = "Incorrecto";
        }
    }

    private IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(2f);
        doorAnimator.SetBool("Open", false);
    }
}
´´´

## Características

- Sistema de Sonido Realista: Efectos de sonido que mejoran la atmósfera y la inmersión del juego.

- Escenarios Detallados: Habitaciones y entornos detallados con gráficos de alta calidad.


## Contribución

Agradecemos contribuciones via pull requests. Para cambios importantes, abra primero un issue para discutir lo que le gustaría cambiar.


## Agradecimientos

Gracias Lucas Briozzo por darme la idea.
