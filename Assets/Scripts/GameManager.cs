using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameState _state;

    private void Start()
    {
        ChangeGameState(GameState.GenerateLevel);
    }

    private void ChangeGameState(GameState newGameState){
        _state = newGameState;

        switch(newGameState){
            case GameState.GenerateLevel:
                break;
            case GameState.GenerateBlock:
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
    
    private void Update()
    {
        if(_state != GameState.WaitingInput) return;

        if(Input.GetKeyDown(KeyCode.A)) Shift(Vector2.left);
        if(Input.GetKeyDown(KeyCode.D)) Shift(Vector2.right);
        if(Input.GetKeyDown(KeyCode.W)) Shift(Vector2.up);
        if(Input.GetKeyDown(KeyCode.S)) Shift(Vector2.down);
    }

    private void Shift(Vector2 left)
    {
        throw new System.NotImplementedException(left.ToString());
    }
}


//游戏状态
public enum GameState
{
    GenerateLevel,
    GenerateBlock,
    WaitingInput,
    Moving,
    Judgment,
    Win,
    Lose
}
