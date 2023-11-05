using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform _playerTransform;

    void Awake()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (_playerTransform != null)
        {
            transform.position = new Vector3(_playerTransform.position.x, _playerTransform.position.y, transform.position.z);
        }
    }
}