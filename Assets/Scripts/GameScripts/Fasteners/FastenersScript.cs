using Ropebot.Game.Player.Controllers;
using UnityEngine;

namespace Ropebot.Game.Fasteners
{
    public class FastenersScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<MovementController>())
            {
                var characterScript = collision.GetComponent<InputController>();
                characterScript.currentFastener = transform;
                characterScript.canGrab = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent<MovementController>())
            {
                var characterScript = collision.GetComponent<InputController>();
                characterScript.canGrab = false;

            }
        }
    }
}

