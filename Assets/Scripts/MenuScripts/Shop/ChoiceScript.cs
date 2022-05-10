using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Ropebot.Data;
using Ropebot.Data.Bots;
using Ropebot.Menu.UI.Controllers;


namespace Ropebot.Menu.UI.Shop.Controllers
{
    public class ChoiceScript : MonoBehaviour
    {
        [SerializeField] private MenuUIController _UIController;
        [SerializeField] private GameObject _choiceBorder;
        [SerializeField] private GameObject _buyButton;
        [SerializeField] private Image _previewSlotImage;

        [Inject] private PlayerData _data;

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
                    Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                    RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                    if (hit)
                    {
                        if (hit.collider.transform.GetComponent<SlotInfo>())
                        {
                            var panelBotType = hit.collider.transform.GetComponent<SlotInfo>().botType;
                            SwitchChoiseBorder(hit.transform.position);
                            Sprite previewImage = panelBotType.GetBotSprite();
                            _previewSlotImage.sprite = previewImage;
                            if (CheckBotExistsInInventory(panelBotType))
                            {
                                _data.data.currentBot = panelBotType;
                                _UIController.UpdatePreviewImage(previewImage);
                                _buyButton.SetActive(false);
                            }
                            else
                            {
                                _buyButton.SetActive(true);
                                _buyButton.GetComponent<BuyController>().currentItemBuy = panelBotType;
                            }
                        }
                        else if (hit.collider.GetComponent<BuyController>())
                        {
                            hit.collider.GetComponent<BuyController>().StartBuyAction();
                        }
                    }
                }
            }

            if(Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit)
                {
                    if (hit.collider.transform.GetComponent<SlotInfo>())
                    {
                        var panelBotType = hit.collider.transform.GetComponent<SlotInfo>().botType;
                        SwitchChoiseBorder(hit.transform.position);
                        Sprite previewImage = panelBotType.GetBotSprite();
                        _previewSlotImage.sprite = previewImage;
                        if (CheckBotExistsInInventory(panelBotType))
                        {
                            _data.data.currentBot = panelBotType;
                            _UIController.UpdatePreviewImage(previewImage);
                            _buyButton.SetActive(false);
                        }
                        else
                        {
                            _buyButton.SetActive(true);
                            _buyButton.GetComponent<BuyController>().currentItemBuy = panelBotType;
                        }
                    }
                    else if(hit.collider.GetComponent<BuyController>())
                    {
                        hit.collider.GetComponent<BuyController>().StartBuyAction();
                    }
                }
            }
        }

        private void SwitchChoiseBorder(Vector3 position)
        {
            _choiceBorder.SetActive(true);
            _choiceBorder.transform.position = position;
        }

        private bool CheckBotExistsInInventory(BotData type)
        {
            foreach(var bot in _data.data.botsInventory)
            {
                if(bot.GetType() == type.GetType())
                {
                    return true;
                }
            }
            return false;
        }
    }
}

