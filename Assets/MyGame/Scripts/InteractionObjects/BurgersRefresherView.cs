using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BurgersRefresherView : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _button;

    public bool IsPanelActive
    {
        get { return _panel.activeSelf; }
    }

    public void OpenOrClose()
    {
        _panel.SetActive(!_panel.activeSelf);
    }

    public void SetMethodForRefreshButton(UnityAction method)
    {
        _button.onClick.AddListener(method);
    }
}
