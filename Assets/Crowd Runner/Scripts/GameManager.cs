using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        Menu,Game,LevelComplete,GameOver
    }

    private GameState gameState;

    public static Action<GameState> onGameStateChanged;

    private void Awake()
    {
        if(instance != null)
            Destroy(instance);  
        else
            instance = this;    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);
        Debug.Log("Game state change to " + gameState);
    }

    public bool isGameState()
    {
        return gameState == GameState.Game;
    }
}
