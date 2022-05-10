using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
                panel.GetComponent<SlotInfo>().botType = botsList[i];
                var previewImage = panel.transform.GetChild(1).GetComponent<Image>();
                var priceText = panel.transform.GetChild(2).GetChild(0).GetComponent<Text>();
                var nameText = panel.transform.GetChild(3).GetComponent<Text>();
                previewImage.sprite = botsList[i].GetBotSprite();
                priceText.text = botsList[i].Price.ToString();
                nameText.text = botsList[i].Name.ToString();
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

