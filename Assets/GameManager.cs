using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    public static event Action<GameState> OnGameStateChanged;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        updateGameState(GameState.InitValues);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateGameState(GameState state)
    {
        State = state;
        switch (state)
        {
            case GameState.InitValues:
                break;
            case GameState.AlgorithmState:
                break;
            case GameState.WhileLR:
                break;
            case GameState.CalculateMiddle:
                break;
            case GameState.IfFoundValue:
                break;
            case GameState.IfLessThanValue:
                break;
            case GameState.DisplayIfResult:
                break;
            case GameState.FinishedFoundState:
                break;
            case GameState.FinishedNotFoundState:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
        OnGameStateChanged?.Invoke(state);
    }
    public enum GameState
    {
        InitValues, 
        AlgorithmState,
        WhileLR,
        CalculateMiddle,
        IfFoundValue,
        IfLessThanValue,
        DisplayIfResult,
        FinishedFoundState,
        FinishedNotFoundState,

    }

}
