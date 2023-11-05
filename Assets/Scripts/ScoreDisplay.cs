using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 0;
    [SerializeField] private TextMeshProUGUI _scoreDisplay;


    // Start is called before the first frame update
    void Start()
    {
    }

    public void Kill()
    {
        _scoreValue++;
    }

    // Update is called once per frame
    void Update()
    {
        _scoreDisplay.text = _scoreValue.ToString();
    }
}
