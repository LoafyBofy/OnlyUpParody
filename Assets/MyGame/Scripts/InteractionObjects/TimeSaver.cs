using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TimeSaver : MonoBehaviour, IInteraction
{
    [Header("Properties")]
    [SerializeField] private string _name;
    [SerializeField] private int _queueNumber;
    [SerializeField] private int _unlockRequired = 100;
    [SerializeField] private Transform _coordinates;
    [Header("Links")]
    [SerializeField] private GameObject _burgerRequiredPopup;

    private bool _isUnlocked = false; 
    private TimeSaverView _view;
    private BurgerCollector _burgerCollector;
    private Pause _pause;
    private CanInteractPopup _popup;

    public static int UnlockedTimeSaversAmount { get; private set; } = 0;

    private void Start()
    {
        _view = FindAnyObjectByType<TimeSaverView>();
        _pause = FindAnyObjectByType<Pause>();
        _popup = FindAnyObjectByType<CanInteractPopup>();

        if (_isUnlocked)
            SendDataToView();

        if (_burgerRequiredPopup != null)
            _burgerRequiredPopup.GetComponentInChildren<TextMeshProUGUI>().text = _unlockRequired.ToString();
    }

    public void Interact()
    {
        if (_isUnlocked == false && _burgerCollector != null)
        {
            if (_burgerCollector.BurgersAmount >= _unlockRequired)
            {
                _burgerCollector.DecreaseBurgers(_unlockRequired);
                _isUnlocked = true;
                _burgerRequiredPopup.SetActive(false);
                UnlockedTimeSaversAmount++;
                SendDataToView();
                _view.OpenOrClose();
                SetPause();
            }
        }
        else if (_isUnlocked == true)
        {
            _view.OpenOrClose();
            SetPause();
        }

        if (_view.IsPanelActive)
            _popup.Hide();
        else
            _popup.Show();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out _burgerCollector);

        if (_burgerRequiredPopup != null && _isUnlocked == false)
            _burgerRequiredPopup.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out BurgerCollector _)) _burgerCollector = null;

        if (_burgerRequiredPopup != null && _isUnlocked == false)
            _burgerRequiredPopup.SetActive(false);
    }

    private void SendDataToView() => _view.AddItem(_name, _queueNumber, _coordinates);

    private void SetPause()
    {
        if (_pause.IsPaused)
            _pause.SetPause(false);
        else
            _pause.SetPause(true);
    }
}
