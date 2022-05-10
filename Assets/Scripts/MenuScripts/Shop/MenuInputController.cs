using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Ropebot.Menu.UI.Controllers;


namespace Ropebot.Menu.UI.Shop.Controllers
{
    public class MenuInputController : MonoBehaviour
    {
        [SerializeField] private GameObject _choiceBorder;
        [SerializeField] private GameObject _buyButton;
        [SerializeField] private Image _previewImage;

        [Inject] private MenuUIController _ui;

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    var touchPoint = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
                    var hit = ShotRaycastToPoint(touchPoint);
                    if (hit)
                    {
                        if (hit.collider.transform.GetComponent<SlotInfo>())
                        {
                            var botType = hit.collider.GetComponent<SlotInfo>().botType;
                            _ui.SetChoiceBotData(botType);
                            _ui.SwitchChoiseBorder(hit.transform.position);
                        }
                        else if (hit.collider.GetComponent<BuyBotController>())
                        {
                            hit.collider.GetComponent<BuyBotController>().StartBuyAction();
                        }
                    }
                }
            }

            if(Input.GetMouseButtonDown(0))
            {
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var hit = ShotRaycastToPoint(mousePos);
                if (hit)
                {
                    if (hit.collider.transform.GetComponent<SlotInfo>())
                    {
                        var botType = hit.collider.GetComponent<SlotInfo>().botType;
                        _ui.SetChoiceBotData(botType);
                        _ui.SwitchChoiseBorder(hit.transform.position);
                    }
                    else if(hit.collider.GetComponent<BuyBotController>())
                    {
                        hit.collider.GetComponent<BuyBotController>().StartBuyAction();
                    }
                }
            }
        }

        private RaycastHit2D ShotRaycastToPoint(Vector2 position)
        {
            var mousePos2D = new Vector2(position.x, position.y);
            return Physics2D.Raycast(mousePos2D, Vector2.zero);
        }
    }
}

