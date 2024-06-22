using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Presiona E para interactuar
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                Keypad keypad = hit.collider.GetComponent<Keypad>();
                if (keypad != null)
                {
                    keypad.ShowKeypad();
                }
            }
        }
    }
}