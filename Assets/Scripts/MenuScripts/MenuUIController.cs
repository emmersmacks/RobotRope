using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Ropebot.Data;

namespace Ropebot.Menu.UI.Controllers
{
    public class MenuUIController : MonoBehaviour
    {
        [SerializeField] private Text _moneyTextField;
        [SerializeField] private Text _recordWay;
        [SerializeField] private Image _botImageInCapsule;
        [SerializeField] private Image _preview;

        [Inject] private PlayerData _data;

        private void Start()
        {
            UpdateTextFields();
            UpdatePreviewImage(_data.data.currentBot.GetBotSprite());
        }

        public void UpdateTextFields()
        {
            _moneyTextField.text = _data.data.money.ToString();
        }

        public void UpdatePreviewImage(Sprite sprite)
        {
            _preview.sprite = sprite;
        }
    }
}

