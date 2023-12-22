using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabBase : ClickableElement
{
    [SerializeField] private UIScreen currentScreen;

    private TabSelector _mainSelector;

    public void SetupCurrentScreen(TabSelector mainSelector)
    {
        if (_mainSelector == null)
            _mainSelector = mainSelector;
    }
}
