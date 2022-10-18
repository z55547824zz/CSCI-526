using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public PlatformType type = PlatformType.HorizontalEnemy;
    public float moveDistance = 3f;
    public float speed = 3f;
    public bool isReverse;

    public enum PlatformType
    {
        HorizontalEnemy = 1,
        VerticalEnemy = 2
    }

    private float _initialPositionX = 0;

    private float _initialPositionY = 0;

//when direction is true, the platform is moving toward to right
    private bool _direction = true;

    // Start is called before the first frame update
    void Start()
    {
        _direction = isReverse;
        _initialPositionX = transform.position.x;
        _initialPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (type == PlatformType.HorizontalEnemy)
        {
            HorizontalMove();
        }

        if (type == PlatformType.VerticalEnemy)
        {
            VerticalMove();
        }
    }

    void HorizontalMove()
    {
        if (_direction && transform.position.x - _initialPositionX >=
            moveDistance)
        {
            _direction = false;
        }

        if (_direction == false && _initialPositionX - transform.position.x >=
            moveDistance)
        {
            _direction = true;
        }

        if (_direction)
        {
            transform.position =
                new Vector3(transform.position.x + Time.deltaTime * speed,
                    _initialPositionY, 0);
        }
        else
        {
            transform.position =
                new Vector3(transform.position.x - Time.deltaTime * speed,
                    _initialPositionY, 0);
        }
    }

    void VerticalMove()
    {
        if (_direction && transform.position.y - _initialPositionY >=
            moveDistance)
        {
            _direction = false;
        }

        if (_direction == false && _initialPositionY - transform.position.y >=
            moveDistance)
        {
            _direction = true;
        }

        if (_direction)
        {
            transform.position =
                new Vector3(_initialPositionX, transform.position.y + Time.deltaTime * speed,
                    0);
        }
        else
        {
            transform.position =
                new Vector3(_initialPositionX, transform.position.y - Time.deltaTime * speed
                    , 0);
        }
    }
}
