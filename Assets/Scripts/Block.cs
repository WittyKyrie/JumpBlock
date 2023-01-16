using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool _isActiveBlock;

    private Vector2Int _blockPos;

    public bool IsActiveBlock
    {
        set => _isActiveBlock = value;
    }

    public void CheckDirCanMove(Vector2Int dir)
    {
        var canMove = LevelGenerator.Instance.GetNodeAtPosition(_blockPos + dir).IsEmpty;
        if (canMove)
        {
            var position = transform.position;
            var destination = new Vector3(position.x + dir.x, position.y,
                position.z + dir.y);
        }
    }
}
