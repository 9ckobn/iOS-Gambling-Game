using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Row : MonoBehaviour
{
    [SerializeField] private List<Block> blocks;

    public int randomIndex;

    public void EnableRow(Action nextRow, Action loseRow)
    {
        foreach (var item in blocks)
            item.EnableBlock();

        randomIndex = UnityEngine.Random.Range(0, 3);

        Debug.Log(randomIndex);

        blocks[randomIndex].trueBlock = true;

        for (int i = 0; i < 3; i++)
        {
            if (i == randomIndex)
            {
                blocks[i].OnClick += nextRow;
            }
            else
            {
                blocks[i].SetupLoseGraphicOnClick();
                blocks[i].OnClick += loseRow;
            }
        }
    }

    public void DisableRow()
    {
        Debug.Log("disabling");

        foreach (var item in blocks)
        {
            item.ChangeSprite();
        }

        blocks = null;
    }
}