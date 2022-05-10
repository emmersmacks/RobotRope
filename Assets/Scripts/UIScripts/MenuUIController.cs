using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Ropebot.Data;
using Ropebot.Data.Bots;
using Ropebot.Menu.UI.Shop;
using Ropebot.Menu.UI.Shop.Controllers;

namespace Ropebot.Menu.UI.Controllers
{
    public class MenuUIController : MonoBehaviour
    {
        [SerializeField] private Text _moneyTextField;
        [SerializeField] private Text _recordWay;
        [SerializeField] private Image _botImageInCapsule;
        [SerializeField] private Image _preview;
        [SerializeField] private GameObject _choiceBorder;
        [SerializeField] private GameObject _buyButton;
        [SerializeField] private Image _shopPreviewImage;

        [Inject] private PlayerData _data;

        public void SetChoiceBotData(BotData type)
        {
            var previewImage = type.GetBotSprite();
            _shopPreviewImage.sprite = previewImage;
            if (CheckBotExistsInInventory(type))
            {
                UpdatePreviewImage(previewImage);
                _data.data.currentBot = type;
                _buyButton.SetActive(false);
            }
            else
            {
                _buyButton.SetActive(true);
                _buyButton.GetComponent<BuyBotController>().currentItemBuy = type;
            }
        }

        public void SwitchChoiseBorder(Vector3 position)
        {
            _choiceBorder.SetActive(true);
            _choiceBorder.transform.position = position;
        }

        private bool CheckBotExistsInInventory(BotData type)
        {
            foreach (var bot in _data.data.botsInventory)
            {
                if (bot.GetType() == type.GetType())
                {
                    return true;
                }
            }
            return false;
        }

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

