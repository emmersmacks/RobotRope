using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DataUIController : MonoBehaviour
{
    [SerializeField] Text _moneyField;
    [SerializeField] MovementController _characterScript;

    [Inject] private PlayerData _data;

    private void Start()
    {
        _characterScript.MoneyCollect += UpdateCounters;
    }

    public void UpdateCounters()
    {
        _moneyField.text = _data.data.money.ToString();
    }
}
