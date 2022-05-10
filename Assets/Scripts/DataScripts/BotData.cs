using System;
using UnityEngine.UI;
using UnityEngine;

namespace Ropebot.Data.Bots
{
    public interface BotData
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string SpriteLink {get; set; }
        public string LinkPrefab { get; set; }

        public Sprite GetBotSprite();
    }
}

