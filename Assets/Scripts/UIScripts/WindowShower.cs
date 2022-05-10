using UnityEngine;

namespace Ropebot.UI
{
    public class WindowShower
    {
        private GameObject _window;

        public WindowShower(GameObject window)
        {
            _window = window;
        }

        public void ShowWindow()
        {
            _window.SetActive(true);
        }
    }
}

