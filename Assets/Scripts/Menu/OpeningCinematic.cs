using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OpeningCinematic : MonoBehaviour
{
    public TextMeshProUGUI cinematicText; // Referencia al TextMeshPro
    public GameObject cinematicPanel; // Referencia al Panel negro
    public Image panelImage; // Referencia a la imagen del Panel
    public float typingSpeed = 0.05f; // Velocidad de aparición del texto
    public float fadeDuration = 1.5f; // Duración del fade-out
    public FirstPersonMovement movementScript; // Referencia al script de movimiento del jugador
    public FirstPersonLook lookScript; // Referencia al script de mirada del jugador

    private string story = "Te encuentras atrapado en una misteriosa habitación...\n" +
                           "Encuentra la forma de salir antes de que sea demasiado tarde.";

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        movementScript.enabled = false; // Desactivar el movimiento del jugador
        lookScript.enabled = false; // Desactivar la rotación de la cámara del jugador

        cinematicText.text = "";
        foreach (char letter in story.ToCharArray())
        {
            cinematicText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(2f); // Retraso antes de permitir el control del jugador
        StartCoroutine(FadeOut()); // Iniciar el fade-out
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color panelColor = panelImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            panelImage.color = new Color(panelColor.r, panelColor.g, panelColor.b, alpha);
            yield return null;
        }

        cinematicPanel.SetActive(false); // Ocultar el panel de la cinemática

        movementScript.enabled = true; // Reactivar el movimiento del jugador
        lookScript.enabled = true; // Reactivar la rotación de la cámara del jugador
    }
}