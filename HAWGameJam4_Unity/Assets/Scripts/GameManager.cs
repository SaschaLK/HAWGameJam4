using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI playerOneText;
    [SerializeField] private TextMeshProUGUI playerTwoText;
    [SerializeField] private TextMeshProUGUI playerThreeText;
    [SerializeField] private TextMeshProUGUI playerFourText;

    private int _playerOneScore;
    private int _playerTwoScore;
    private int _playerThreeScore;
    private int _playerFourScore;

    public static GameManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void UpdatePlayerScore(int player, int change) 
    {
        switch (player)
        {
            case 1:
                _playerOneScore += change;
                playerOneText.text = _playerOneScore.ToString();
                break;
            case 2:
                _playerTwoScore += change;
                playerTwoText.text = _playerTwoScore.ToString();
                break;
            case 3:
                _playerThreeScore += change;
                playerThreeText.text = _playerThreeScore.ToString();
                break;
            case 4:
                _playerFourScore += change;
                playerFourText.text = _playerFourScore.ToString();
                break;
        }
    }
}
