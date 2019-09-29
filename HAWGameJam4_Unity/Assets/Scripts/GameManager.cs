using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameStates
    {
        WAIT,
        STARTING,
        RUNNING,
        END
    }

    public GameStates currentGameState = GameStates.WAIT;

    [SerializeField] private TextMeshProUGUI playerOneText;
    [SerializeField] private TextMeshProUGUI playerTwoText;
    [SerializeField] private TextMeshProUGUI playerThreeText;
    [SerializeField] private TextMeshProUGUI playerFourText;

    [SerializeField] private GameObject winningPanel;
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private TextMeshProUGUI pointsText;

    [SerializeField] private GameObject countdownPanel;
    [SerializeField] private TextMeshProUGUI countdownText;

    private int _playerOneScore;
    private int _playerTwoScore;
    private int _playerThreeScore;
    private int _playerFourScore;

    private int _playerCount;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    private float countDown = 5;
    
    void Update()
    {
        if (currentGameState != GameStates.STARTING)
            return;
        
        int intDown = (int) countDown;
        
        countdownText.text = intDown.ToString();

        countDown -= Time.deltaTime;
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

    public void PlayerConnected()
    {
        _playerCount++;

        if (_playerCount == 4)
        {
            StartCoroutine(GameStart());
        }
    }

    private IEnumerator GameStart()
    {
        countdownPanel.SetActive(true);
        currentGameState = GameStates.STARTING;
        
        yield return new WaitForSeconds(5);

        countdownPanel.SetActive(false);
        currentGameState = GameStates.RUNNING;
        StartScroller();
    }
    
    public void EndGame()
    {
        winningPanel.SetActive(true);

        SortedList<string, int> allPlayerScores = new SortedList<string, int>();

        allPlayerScores.Add("Player 1", _playerOneScore);
        allPlayerScores.Add("Player 2", _playerTwoScore);
        allPlayerScores.Add("Player 3", _playerThreeScore);
        allPlayerScores.Add("Player 4", _playerFourScore);

        int value = allPlayerScores.Values[0];
        string key = allPlayerScores.Keys[0];

        winnerText.text = key;
        pointsText.text = value.ToString();
        
        StopScroller();
    }

    private void StartScroller()
    {
        var movingHouseWalls = GameObject.FindGameObjectsWithTag("MovingHouseWall");
        var movingObjects = GameObject.FindGameObjectsWithTag("Moving");

        foreach (var go in movingHouseWalls)
        {
            go.GetComponent<HouseWallBehaviour>().StartMovement();
        }

        foreach (var go in movingObjects)
        {
            go.GetComponent<Mover>().StartMovement();
        }

        GameObject.FindGameObjectWithTag("Goal").GetComponent<Goal>().StartMovement();
    }
    
    private void StopScroller()
    {
        var movingHouseWalls = GameObject.FindGameObjectsWithTag("MovingHouseWall");
        var movingObjects = GameObject.FindGameObjectsWithTag("Moving");

        foreach (var go in movingHouseWalls)
        {
            go.GetComponent<HouseWallBehaviour>().StopMovement();
        }

        foreach (var go in movingObjects)
        {
            go.GetComponent<Mover>().StopMovement();
        }

        GameObject.FindGameObjectWithTag("Goal").GetComponent<Goal>().StopMovement();
    }
}
