using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _liftingSpeed;
    [SerializeField] private Transform _body;
    [Header("Borders")]
    [SerializeField] private float _topBorder = 0.1f;
    [SerializeField] private float _bottomBorder = -0.1f;

    [SerializeField] private State _state = State.Up;
    private float _height = 0f;

    enum State
    {
        Up,
        Down
    }

    private void Update()
    {
        _body.Rotate(0, _rotationSpeed * Time.deltaTime, 0);

        if (_height > _topBorder)
        {
            _state = State.Down;
        }
        else if (_height < _bottomBorder)
        {
            _state = State.Up;
        }

        switch (_state)
        {
            case State.Up:
                _height += _liftingSpeed * Time.deltaTime;
                break;
            case State.Down:
                _height -= _liftingSpeed * Time.deltaTime;
                break;
        }

        _body.position = new Vector3(
            _body.position.x,
            transform.position.y + _height,
            _body.position.z
            );
    }
}
