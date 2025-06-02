using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;

    private RectTransform _rectTransform;
    private float _timer = 0f;
    private bool _isTimerStarted = false;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (_timer < _curve.keys[_curve.length - 1].time && _isTimerStarted)
        {
            _timer += Time.deltaTime;
            _rectTransform.localScale = new Vector3(_curve.Evaluate(_timer), _curve.Evaluate(_timer), _curve.Evaluate(_timer));
        }
        else
        {
            _isTimerStarted = false;
        }
    }

    public void StartAnimation()
    {
        _timer = 0;
        _isTimerStarted = true;
    }
}
