using UnityEngine;
using Zenject;

namespace Ropebot.Data.player.installer
{
    public class PlayerDataInstaller : MonoInstaller
    {
        [SerializeField] private PlayerData playerData;

        public override void InstallBindings()
        {
            Container.Bind<PlayerData>().FromInstance(playerData).AsSingle();
        }
    }
}
