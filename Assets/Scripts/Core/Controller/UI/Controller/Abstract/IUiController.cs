using System.Collections;
using System.Collections.Generic;
using Core.Utilities.Results;
using UnityEngine;

public interface IUiController
{
    public Result GetAllPanels();
    public Result CloseAllPanels();
    public Result OpenSpecificPanel(IUiPanel uiPanel);
}
