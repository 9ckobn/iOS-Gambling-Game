using UnityEngine;
using UnityEngine.UI;

public class DoubleChestElement : ClickableElement
{
    [SerializeField] private Sprite rewardChest, missChest;
    [SerializeField] private Color32 nonInteractableColor = Color.gray; 
    public bool trueChest = false;

    public void SetInteractivity()
    {
        OnClick = null;
        
        if(trueChest)
        {
            targetGraphic.sprite = rewardChest;
        }
        else
        {
            targetGraphic.sprite = missChest;
            targetGraphic.color = nonInteractableColor;
        }
    }
}