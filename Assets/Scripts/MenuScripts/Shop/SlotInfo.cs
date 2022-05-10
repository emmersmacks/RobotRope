using Ropebot.Data.Bots;
using UnityEngine;
using UnityEngine.UI;


namespace Ropebot.Menu.UI.Shop
{
    public class SlotInfo : MonoBehaviour
    {
        [SerializeField] public Text priceField;
        [SerializeField] public Text botNameField;
        [SerializeField] public Image botPreview;
        public BotData botType;
    }
}

