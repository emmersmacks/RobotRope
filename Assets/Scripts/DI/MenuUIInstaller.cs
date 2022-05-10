using UnityEngine;
using Zenject;
using Ropebot.Menu.UI.Controllers;

namespace Ropebot.Data.player.installer
{
    public class MenuUIInstaller : MonoInstaller
    {
        [SerializeField] private MenuUIController controller;

        public override void InstallBindings()
        {
            Container.Bind<MenuUIController>().FromInstance(controller).AsSingle();
        }
    }
}
