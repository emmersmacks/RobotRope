using UnityEngine;
using System.Threading.Tasks;

namespace Ropebot.Game.Player.Controllers
{
    public class HookController : MonoBehaviour
    {
        [SerializeField] private LineRenderer _ropeLine;
        [SerializeField] private GameObject _hookEffect;

        private InputController _characterController;
        private DistanceJoint2D _joint;


        private void Start()
        {
            _characterController = GetComponent<InputController>();
            _joint = GetComponent<DistanceJoint2D>();

            _characterController.Hook += OnHook;
            _characterController.Unhook += OnUnhook;
        }

        private void OnHook()
        {
            _joint.enabled = true;
            _ropeLine.enabled = true;
            GrabFastener();
            RenderRope();
            _hookEffect.SetActive(true);
            _hookEffect.transform.position = _characterController.currentFastener.position;
        }

        private void OnUnhook()
        {
            _ropeLine.enabled = false;
            _joint.enabled = false;
            _hookEffect.SetActive(false);
        }

        public void GrabFastener()
        {
            _joint.connectedAnchor = _characterController.currentFastener.position;
            _joint.distance = Vector2.Distance(transform.position, _characterController.currentFastener.position);
        }

        public async void RenderRope()
        {
            while (_ropeLine.enabled)
            {
                _ropeLine.SetPosition(0, transform.position);
                _ropeLine.SetPosition(1, _characterController.currentFastener.position);
                await Task.Delay(5);
            }

        }
    }
}

