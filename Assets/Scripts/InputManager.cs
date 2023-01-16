using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager : Singleton<InputManager>
{
    private bool _isWaitingInput;

    public bool IsWaitingInput
    {
        set => _isWaitingInput = value;
    }

    private void Update()
    {
        if(!_isWaitingInput) return;

        if(Input.GetKeyDown(KeyCode.A)) BlockMove(Vector2Int.left);
        if(Input.GetKeyDown(KeyCode.D)) BlockMove(Vector2Int.right);
        if(Input.GetKeyDown(KeyCode.W)) BlockMove(Vector2Int.up);
        if(Input.GetKeyDown(KeyCode.S)) BlockMove(Vector2Int.down);
    }

    private void BlockMove(Vector2Int dir)
    {
        
    }
}
