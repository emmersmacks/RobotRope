using Ropebot.Data;
using UnityEngine;
using System;
using Zenject;

namespace Ropebot.Game.Player.Controllers
{
    public class ActionController : MonoBehaviour
    {
        [Inject] private PlayerData _data;

        private InputController _characterController;

        public event Action MoneyCollect = default;
        public event Action Dead = default;

        private void Start()
        {
            _characterController = GetComponent<InputController>();
        }

        public void DeadAction()
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(new Vector2(10, 10), ForceMode2D.Impulse);
            _characterController.currentState = CharacterState.isDead;
            Dead();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PrefabInform>())
            {
                if (collision.GetComponent<PrefabInform>().prefabType == PrefabType.Money)
                {
                    Destroy(collision.gameObject);
                    _data.data.money++;
                    MoneyCollect();
                }
            }
        }
    }
}

