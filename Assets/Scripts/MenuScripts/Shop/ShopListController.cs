using System.Collections.Generic;
using UnityEngine;
using Ropebot.Data.Bots;

namespace Ropebot.Menu.UI.Shop.Controllers
{
    public class ShopListController : MonoBehaviour
    {
        [SerializeField] GameObject ItemPanel;

        public List<BotData> items;

        private void Start()
        {
            FillSlots();
        }

        public void FillSlots()
        {
            var botsList = CreateShopItemsList();
            for (int i = 0; i < botsList.Count; i++)
            {
                var panel = Instantiate(ItemPanel, transform);
                var slotInfo = panel.GetComponent<SlotInfo>();
                slotInfo.botType = botsList[i];
                slotInfo.botPreview.sprite = botsList[i].GetBotSprite();
                slotInfo.priceField.text = botsList[i].Price.ToString();
                slotInfo.botNameField.text = botsList[i].Name.ToString();
            }
        }

        public List<BotData> CreateShopItemsList()
        {
            items = new List<BotData>();
            items.Add(new SantiagoBot());
            items.Add(new TestBot());
            return items;
        }
    }
}

