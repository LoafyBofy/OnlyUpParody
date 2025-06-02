using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Lumin;

public class CharacterChanger : MonoBehaviour, IInteraction
{
    [SerializeField] private AnimalItem[] _animals;
    [SerializeField] private int _unlockPrice = 1000;

    private Pause _pause;
    private CharacterChangerView _view;
    private CanInteractPopup _popup;
    private Dictionary<Animals, bool> _animalsAcces = new()
    {
        { Animals.Sparrow, true },
        { Animals.Squid, false },
        { Animals.Snake, false },
        { Animals.Deer, false },
        { Animals.Hamster, false },
        { Animals.Fish, false },
        { Animals.Gecko, false },
        { Animals.Monkey, false },
    };

    private void Start()
    {
        _pause = FindAnyObjectByType<Pause>();
        _view = FindAnyObjectByType<CharacterChangerView>();
        _popup = FindAnyObjectByType<CanInteractPopup>();
        _view.UnlockPrice = _unlockPrice;

        if (_animals.Length > 0)
        {
            for (int i = 0; i < _animals.Length; i++)
                _animals[i].isUnlocked = _animalsAcces[_animals[i].name];

            _view.SetData(_animals, _animalsAcces);
        }
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

    private void SetPause()
    {
        if (_pause.IsPaused)
        {
            _pause.SetPause(false);
            ChangeCursorState(false);
        }
        else
        {
            _pause.SetPause(true);
            ChangeCursorState(true);
        }
    }

    private void ChangeCursorState(bool enabled)
    {
        UnityEngine.Cursor.visible = true;

        if (enabled)
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        else
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
}
