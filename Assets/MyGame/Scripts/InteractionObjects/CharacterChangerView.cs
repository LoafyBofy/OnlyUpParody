using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChangerView : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private RawImage _characterImage;
    [SerializeField] private TextMeshProUGUI _characterName;
    [SerializeField] private Button _equipButton;

    [Header("Images")]
    [SerializeField] private Sprite _burgerImage;

    private BurgerCollector _burgerCollector;
    private PlayerBody _playerBody;
    private TextMeshProUGUI _equipButtonText;
    private List<Image> _equipButtonImages = new();
    private AnimalItem[] _animals;
    private Dictionary<Animals, bool> _animalsAcces;
    private int _count = 0;

    public bool IsPanelActive
    {
        get { return _panel.activeSelf; }
    }

    public int UnlockPrice { get; set; }

    private void Start()
    {
        _playerBody = FindAnyObjectByType<PlayerBody>();
        _burgerCollector = FindAnyObjectByType<BurgerCollector>();

        if (_equipButton != null)
        {
            _equipButtonText = _equipButton.GetComponentInChildren<TextMeshProUGUI>();
            var images = _equipButton.GetComponentsInChildren<Image>();

            for (int i = 1; i < images.Length; i++)
            {
                _equipButtonImages.Add(images[i]);
                _equipButtonImages[i - 1].sprite = _burgerImage;
            }
            ShowOrHideImagesInEquipButton(false);

            _equipButton.onClick.AddListener(EquipCharacter);
        }
    }

    public void ClickNext()
    {
        if (_count < _animals.Length - 1)
        {
            _count++;
            ChangeCurrentCharacterInView();
        }
    }

    public void ClickBack()
    {
        if (_count > 0)
        {
            _count--;
            ChangeCurrentCharacterInView();
        }
    }

    private void ChangeCurrentCharacterInView()
    {
        if (_animals.Length > 0)
        {
            _characterImage.texture = _animals[_count].renderTexture;
            _characterName.text = _animals[_count].name.ToString();

            if (_animals[_count].isUnlocked)
            {
                _equipButtonText.text = "Использовать";
            }
            else
            {
                _equipButtonText.text = $"Открыть ({UnlockPrice})";
            }

            ShowOrHideImagesInEquipButton(!_animals[_count].isUnlocked);
        }
    }

    private void EquipCharacter()
    {
        if (_animals[_count].isUnlocked && _playerBody != null)
        {
            _playerBody.SetNewBody(_animals[_count].prefab);
        }
        else if (_animals[_count].isUnlocked == false && _burgerCollector.BurgersAmount >= UnlockPrice)
        {
            _burgerCollector.DecreaseBurgers(UnlockPrice);
            _animals[_count].isUnlocked = true;
            ChangeCurrentCharacterInView();
        }
    }

    public void SetData(AnimalItem[] animals, Dictionary<Animals, bool> animalsAcces)
    {
        _animals = animals;
        _animalsAcces = animalsAcces;

        if (_animals != null && _animalsAcces != null)
            ChangeCurrentCharacterInView();
    }

    public void OpenOrClose() => _panel.SetActive(!_panel.activeSelf);

    private void ShowOrHideImagesInEquipButton(bool state)
    {
        for (int i = 0; i < _equipButtonImages.Count; i++)
        {
            _equipButtonImages[i].gameObject.SetActive(state);
        }
    }
}
