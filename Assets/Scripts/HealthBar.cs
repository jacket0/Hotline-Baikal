using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _healthDisplay;

    private void Update()
    {
        if (_healthDisplay != null)
        {
            _healthDisplay.text = _player.Health.ToString();
        }
    }
}
