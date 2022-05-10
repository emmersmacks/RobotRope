using Ropebot.Data;
using Ropebot.Game.Player.Controllers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ropebot.UI
{
    public class DataUIController : MonoBehaviour
    {
        [SerializeField] Text _moneyField;
        [SerializeField] ActionController _characterScript;

        [Inject] private PlayerData _data;

        private void Start()
        {
            _characterScript.MoneyCollect += UpdateCounters;
        }

        public void UpdateCounters()
        {
            _moneyField.text = _data.data.money.ToString();
        }
    }
}

