using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCollector : MonoBehaviour
{
    private BurgersAmountView _view;
    private int _burgersAmount;
    public int BurgersAmount { get { return _burgersAmount; } }

    private void Start()
    {
        _view = FindAnyObjectByType<BurgersAmountView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Burger burger))
        {
            IncreaseBurgers(1);
            _view.SetText(_burgersAmount);
            burger.gameObject.SetActive(false);
        }
    }

    public void IncreaseBurgers(int value)
    {
        if (value > 0)
        {
            _burgersAmount += value;
            _view.SetText(_burgersAmount);
        }
    }

    public void DecreaseBurgers(int value)
    {
        if (_burgersAmount > value)
            _burgersAmount -= value;
        else
            _burgersAmount = 0;

        _view.SetText(_burgersAmount);
    }
}
