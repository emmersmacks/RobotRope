using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ropebot.UI
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private int _sceneIndex;

        public void LoadScene()
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    }
}

