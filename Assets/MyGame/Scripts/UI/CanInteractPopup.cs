using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanInteractPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void Show(string objectName = "")
    {
        if (_text != null)
        {
            if (objectName != "")
                _text.text = $"{objectName} \n ֽאזלטעו 'E'";
            _text.gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        if (_text != null)
            _text.gameObject.SetActive(false);
    }
}
