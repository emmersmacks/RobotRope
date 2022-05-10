using System;
using UnityEngine;

namespace Ropebot.Data.Bots
{
    [Serializable]
    public class TestBot : BotData
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string SpriteLink { get; set; }
        public string LinkPrefab { get; set; }

        public TestBot()
        {
            Name = "TestBot";
            Price = 100;
            SpriteLink = "Textures/TestBot";
            LinkPrefab = "Prefabs/TestBot";
        }

        public Sprite GetBotSprite()
        {
            return Resources.Load<Sprite>(SpriteLink);
        }
    }
}

