using UnityEngine;

public class FastenersScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() != null)
        {
            var characterScript = collision.GetComponent<InputController>();
            characterScript.currentFastener = transform;
            characterScript.canGrab = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() != null)
        {
            var characterScript = collision.GetComponent<InputController>();
            characterScript.canGrab = false;
            
        }
    }
}
