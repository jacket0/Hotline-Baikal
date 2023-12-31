using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 0;
    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] private int _scoreForKill = 1;

    private float secundomer = 0f;
    private int _scoreMultiplier = 1;
    private float _holdMultiplierTime = 3f;

    public void Kill()
    {
        _scoreValue += _scoreMultiplier * _scoreForKill;
    }

    public void KillTimer()
    {
        secundomer += Time.deltaTime;
    }

    void Update()
    {
        _scoreDisplay.text = _scoreValue.ToString();
        _holdMultiplierTime -= Time.deltaTime;
        if (_holdMultiplierTime < 0)
        {
            _scoreMultiplier = 1;
        }

    }
}
