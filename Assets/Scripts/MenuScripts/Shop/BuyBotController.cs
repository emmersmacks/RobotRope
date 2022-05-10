using UnityEngine;
using Ropebot.Data.Bots;
using Ropebot.Data;
using Ropebot.Menu.UI.Controllers;
using Zenject;

namespace Ropebot.Menu.UI.Shop.Controllers
{
    public class BuyBotController : MonoBehaviour
    {
        public BotData currentItemBuy;

        [Inject] private PlayerData _data;
        [Inject] private MenuUIController _ui;

        public void StartBuyAction()
        {
            if (currentItemBuy.Price <= _data.data.money)
            {
                _data.data.money -= currentItemBuy.Price;
                _data.data.currentBot = currentItemBuy;
                _data.data.botsInventory.Add(currentItemBuy);
                _ui.UpdateTextFields();
                var previewImage = currentItemBuy.GetBotSprite();
                _ui.UpdatePreviewImage(previewImage);
                _ui.SetChoiceBotData(currentItemBuy);
            }
            else
                Debug.Log("not enough money");
        }
    }
}

