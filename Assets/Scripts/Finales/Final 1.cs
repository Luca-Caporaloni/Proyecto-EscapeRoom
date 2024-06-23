using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final1 : MonoBehaviour
{
    public float interactionDistance = 1f;
    public string escapeSceneName = "EscapeScene"; // Nombre de la escena de escape

    private bool hasCard = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Card"))
            {
                CollectCard(hit.collider.gameObject);
            }
        }
    }

    void CollectCard(GameObject card)
    {
        // Realiza la acción de recoger la tarjeta
        hasCard = true;
        Destroy(card); // Eliminar la tarjeta del juego

        // Iniciar la cuenta regresiva de 3 segundos para cambiar a la escena de escape
        StartCoroutine(StartEscapeCountdown());
    }

    IEnumerator StartEscapeCountdown()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(escapeSceneName, LoadSceneMode.Single);
    }
}