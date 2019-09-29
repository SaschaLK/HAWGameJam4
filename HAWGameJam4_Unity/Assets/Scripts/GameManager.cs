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
    [SerializeField] private MusicManager musicManager;

    private int _playerOneScore;
    private int _playerTwoScore;
    private int _playerThreeScore;
    private int _playerFourScore;

    private int _playerCount = 0;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    private float countDown = 5.5f;
    
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
            case 0:
                _playerOneScore += change;
                playerOneText.text = _playerOneScore.ToString();
                if(_playerOneScore > _playerTwoScore && _playerOneScore > _playerThreeScore && _playerOneScore > _playerFourScore) {
                    musicManager.TransitionToAnime();
                }
                break;
            case 1:
                _playerTwoScore += change;
                playerTwoText.text = _playerTwoScore.ToString();
                if (_playerTwoScore > _playerOneScore && _playerTwoScore > _playerThreeScore && _playerTwoScore > _playerFourScore) {
                    musicManager.TransitionToShittyFlute();
                }
                break;
            case 2:
                _playerThreeScore += change;
                playerThreeText.text = _playerThreeScore.ToString();
                if (_playerThreeScore > _playerOneScore && _playerThreeScore > _playerTwoScore && _playerThreeScore > _playerFourScore) {
                    musicManager.TransitionToChiptune();
                }
                break;
            case 3:
                _playerFourScore += change;
                playerFourText.text = _playerFourScore.ToString();
                if (_playerFourScore > _playerOneScore && _playerFourScore > _playerTwoScore && _playerFourScore > _playerThreeScore) {
                    musicManager.TransitionToSoundFont();
                }
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
        
        yield return new WaitForSeconds(5.5f);

        countdownPanel.SetActive(false);
        currentGameState = GameStates.RUNNING;
        StartScroller();
    }
    
    public void EndGame()
    {
        winningPanel.SetActive(true);
        
        musicManager.PlayEndSound();
        
        SortedList<string, int> allPlayerScores = new SortedList<string, int>();

        allPlayerScores.Add("Player 1", _playerOneScore);
        allPlayerScores.Add("Player 2", _playerTwoScore);
        allPlayerScores.Add("Player 3", _playerThreeScore);
        allPlayerScores.Add("Player 4", _playerFourScore);

        var orderByVal = allPlayerScores.OrderBy(v => v.Value);
        var orderByValReverse = orderByVal.Reverse();

        bool once = false;
        
        foreach (var pair in orderByValReverse)
        {
            if (!once)
            {
                winnerText.text = pair.Key;
                pointsText.text = pair.Value.ToString();
                once = true;
            }
        }
        
        currentGameState = GameStates.END;
        
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


    //only for testing
    private void TestMusicChange() {
        if (Input.GetKey("up")) {
            _playerOneScore+=1;
            Debug.Log(_playerOneScore);
        }
        if (Input.GetKey("left")) {
            _playerTwoScore += 1;
        }
        if (Input.GetKey("right")) {
            _playerThreeScore += 1;
        }
        if (Input.GetKey("down")) {
            _playerFourScore += 1;
        }
    }
}
