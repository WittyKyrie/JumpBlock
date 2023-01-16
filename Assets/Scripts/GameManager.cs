using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameState _state;
    // public static event Action<GameState> OnGameStateChanged;

    private void Start()
    {
        ChangeGameState(GameState.LoadingAsset);
    }

    public void ChangeGameState(GameState newGameState){
        _state = newGameState;

        switch(newGameState){
            case GameState.LoadingAsset:
                LevelGenerator.Instance.PrepareLevelAsset();
                break;
            case GameState.GenerateLevel:
                LevelGenerator.Instance.GenerateLevel(1);
                break;
            case GameState.WaitingInput:
                break;
            case GameState.Moving:
                break;
            case GameState.Judgment:
                break; 
            case GameState.Win:
                break;
            case GameState.Lose:
            default:
                return;           
        }
    }
}


//游戏状态
public enum GameState
{
    LoadingAsset,
    GenerateLevel,
    WaitingInput,
    Moving,
    Judgment,
    Win,
    Lose
}
