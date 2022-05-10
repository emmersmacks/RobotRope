using UnityEngine;

namespace Ropebot.Game.Obstacles
{
    public class PlayerStalkingScript : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _speed;

        private float _speedMultiplier = 1;

        const int PlayerDistance = 50;

        private void Update()
        {
            if (Vector2.Distance(transform.position, _player.position) > PlayerDistance)
                _speedMultiplier++;
            else
                _speedMultiplier = 1;
            transform.position = Vector3.MoveTowards(transform.position, _player.position, Time.deltaTime * _speed * _speedMultiplier);
        }
    }
}

