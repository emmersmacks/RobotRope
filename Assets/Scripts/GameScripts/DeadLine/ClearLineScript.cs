using UnityEngine;

namespace Ropebot.Game.Level.Controllers
{
    public class ClearLineScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
}

