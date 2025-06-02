using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BurgersAmountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _burgersAmountText;

    private TextAnimation _textAnimation;

    private void Start()
    {
        _textAnimation = _burgersAmountText.GetComponent<TextAnimation>();
    }

    public void SetText(int value)
    {
        _burgersAmountText.text = value.ToString();
        _textAnimation.StartAnimation();
    }
}
