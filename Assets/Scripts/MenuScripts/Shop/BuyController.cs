using UnityEngine;
using Ropebot.Data.Bots;
using Ropebot.Data;
using Ropebot.Menu.UI.Controllers;
using Zenject;

namespace Ropebot.Menu.UI.Shop.Controllers
{
    public class BuyController : MonoBehaviour
    {
        [SerializeField] private MenuUIController _UIController;

        public BotData currentItemBuy;

        [Inject] private PlayerData _data;

        public void StartBuyAction()
        {
            if (currentItemBuy.Price <= _data.data.money)
            {
                _data.data.money -= currentItemBuy.Price;
                _data.data.currentBot = currentItemBuy;
                _data.data.botsInventory.Add(currentItemBuy);
                _UIController.UpdateTextFields();
                var previewImage = currentItemBuy.GetBotSprite();
                _UIController.UpdatePreviewImage(previewImage);
                Debug.Log("Buy Socces");
            }
            else
                Debug.Log("not enough money");
        }
    }
}

