using UnityEngine;
using Ropebot.UI;
using Ropebot.Game.Player.Controllers;
using UnityEngine.UI;
using Zenject;
using Ropebot.Data;

namespace Ropebot.Game.UI.Controllers
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] Text moneyText;
        [SerializeField] ActionController controller;
        [SerializeField] GameObject EndGameWindow;

        [Inject] PlayerData _data;

        private void Start()
        {
            controller.Dead += StartEndGame;
            controller.MoneyCollect += UpdateCounters;
            UpdateCounters();
        }

        public void StartPause(GameObject pauseWindow)
        {
            Time.timeScale = 0;
            var windowShower = new WindowShower(pauseWindow);
            windowShower.ShowWindow();
        }

        public void EndPause(GameObject pauseWindow)
        {
            Time.timeScale = 1;
            pauseWindow.SetActive(false);
        }

        private void StartEndGame()
        {
            EndGameWindow.SetActive(true);
        }

        public void UpdateCounters()
        {
            moneyText.text = _data.data.money.ToString();
        }
    }
}
