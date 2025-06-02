using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeSaverView : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _content;

    [Header("Prefabs")]
    [SerializeField] private GameObject _scrollViewItemPrefab;

    private List<TimeSaverItem> _items = new List<TimeSaverItem>();

    public bool IsPanelActive
    {
        get { return _panel.activeSelf; }
    }

    public void AddItem(string name, int queueNumber, Transform coordinates)
    {
        _items.Add(new TimeSaverItem(name, queueNumber, coordinates));

        if (TimeSaver.UnlockedTimeSaversAmount == _items.Count)
            AddItemsInContent();
    }

    private void AddItemsInContent()
    {
        ClearContent();
        var newItems = _items.OrderBy(x => x.queueNumber);

        foreach (var i in newItems)
        {
            var rect = _content.GetComponent<RectTransform>();
            var item = Instantiate(_scrollViewItemPrefab, rect);
            item.GetComponentInChildren<TextMeshProUGUI>().text = i.name;
            item.GetComponentInChildren<Button>().onClick.AddListener( 
                delegate {
                    var player = FindAnyObjectByType<ThirdPersonController>();
                    FindAnyObjectByType<Pause>().SetPause(false);
                    player.TeleportTo(i.coordinates.position);
                    OpenOrClose();
                } 
            );
        }
    }

    private void ClearContent()
    {
        for (int i = 0; i < _content.transform.childCount; i++)
        {
            Transform child = _content.transform.GetChild(i);
            Destroy(child.gameObject);
        }
    }

    public void OpenOrClose() => _panel.SetActive(!_panel.activeSelf);

    public struct TimeSaverItem
    {
        public string name;
        public int queueNumber;
        public Transform coordinates;

        public TimeSaverItem(string name, int queueNumber, Transform coordinates)
        {
            this.name = name;
            this.queueNumber = queueNumber;
            this.coordinates = coordinates;
        }
    }
}
