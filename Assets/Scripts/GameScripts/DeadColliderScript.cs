using Ropebot.Game.Player.Controllers;
using UnityEngine;

namespace Ropebot.Game.Obstacles
{
    public class DeadColliderScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<ActionController>())
            {
                collision.GetComponent<ActionController>().DeadAction();
            }
        }
    }
}

