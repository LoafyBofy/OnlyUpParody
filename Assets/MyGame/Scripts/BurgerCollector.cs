using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCollector : MonoBehaviour
{
    private int _burgersAmount;
    private BurgersAmountView _view;

    private void Start()
    {
        _view = FindAnyObjectByType<BurgersAmountView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Burger burger))
        {
            _burgersAmount += 1;
            _view.SetText(_burgersAmount);
            burger.gameObject.SetActive(false);
        }
    }
}
