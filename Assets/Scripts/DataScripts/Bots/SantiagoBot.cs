using System;
using UnityEngine.UI;
using UnityEngine;

namespace Ropebot.Data.Bots
{
    [Serializable]
    public class SantiagoBot : BotData
    {
        public string Name { get; set; }
        public int Price { get ; set; }
        public string LinkPrefab { get; set; }
        public string SpriteLink { get; set; }

        public SantiagoBot()
        {
            Name = "Santiago";
            Price = 0;
            SpriteLink = "Textures/Santiago";
            LinkPrefab = "Prefabs/Santiago";
        }

        public Sprite GetBotSprite()
        {
            return Resources.Load<Sprite>(SpriteLink);
        }
    }
}

