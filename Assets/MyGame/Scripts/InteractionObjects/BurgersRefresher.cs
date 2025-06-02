using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgersRefresher : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject _containerWithBurgers;

    private Burger[] _burgers;
    private ThirdPersonController _player;
    private Vector3 _respawn;
    private BurgersRefresherView _view;
    private CanInteractPopup _popup;
    private Pause _pause;

    private void Start()
    {
        if (_containerWithBurgers != null)
            _burgers = _containerWithBurgers.GetComponentsInChildren<Burger>();

        _player = FindAnyObjectByType<ThirdPersonController>();
        _respawn = GameObject.FindWithTag("Respawn").transform.position;
        _view = FindAnyObjectByType<BurgersRefresherView>();
        _popup = FindAnyObjectByType<CanInteractPopup>();
        _pause = FindAnyObjectByType<Pause>();

        _view.SetMethodForRefreshButton(ReactivateBurgers);
    }

    public void Interact()
    {
        _view.OpenOrClose();
        SetPause();

        if (_view.IsPanelActive)
            _popup.Hide();
        else
            _popup.Show();
    }

    private void ReactivateBurgers()
    {
        _view.OpenOrClose();
        SetPause();

        if (_burgers.Length > 0)
        {
            for (int i = 0; i < _burgers.Length - 1; i++)
            {
                _burgers[i].gameObject.SetActive(true);
            }

            _player.TeleportTo(_respawn);
        }
    }

    private void SetPause()
    {
        if (_pause.IsPaused)
            _pause.SetPause(false);
        else
            _pause.SetPause(true);
    }
}
