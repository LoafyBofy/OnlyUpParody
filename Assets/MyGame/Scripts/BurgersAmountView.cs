using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BurgersAmountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _burgersAmountText;

    public void SetText(int value)
    {
        _burgersAmountText.text = value.ToString();
    }
}
