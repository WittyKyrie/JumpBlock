using System;
using DG.Tweening;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool _isActiveBlock;
    private const float MoveOnceTime = 0.4f;
    private Vector2Int _blockPos;

    private void Awake()
    {
        _blockPos = Util.PositionToVector2Int(transform);
    }

    public bool IsActiveBlock
    {
        set => _isActiveBlock = value;
        get => _isActiveBlock;
    }

    public void CheckDirCanMove(Vector2Int dir)
    {
        if(!_isActiveBlock) return;
        
        while (LevelGenerator.Instance.GetNodeIsEmptyAtPosition(_blockPos + dir))
        {
            _blockPos = new Vector2Int(_blockPos.x + dir.x,
                 _blockPos.y + dir.y);
        }

        var destination = Util.Vector2IntToPosition(_blockPos);
        var personPos = Util.PositionToVector2Int(transform);
        LevelGenerator.Instance.GetNodeAtPosition(personPos).block = null;
        LevelGenerator.Instance.GetNodeAtPosition(_blockPos).block = this;

        transform.DOMove(destination, MoveOnceTime).OnComplete(() =>
        {
            GameManager.Instance.ChangeGameState(GameState.WaitingInput);
        });
    }
}

