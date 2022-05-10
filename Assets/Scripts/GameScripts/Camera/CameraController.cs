using Ropebot.Game.Player.Controllers;
using UnityEngine;

namespace Ropebot.Game.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private ActionController _characterController;
        [SerializeField] private Transform _player;

        private bool _isFreeze;

        private void Start()
        {
            _characterController = _player.GetComponent<ActionController>();
            _characterController.Dead += OnDead;
            _isFreeze = false;
        }

        private void Update()
        {
            if (!_isFreeze)
                transform.position = (Vector2)_player.position;
        }

        public void OnDead()
        {
            _isFreeze = true;
        }
    }
}

