using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Results;
using UnityEngine;

public class UiController : MonoBehaviour, IUiController
{
    private List<UiPanel> _allPanels;
    
    public IMainMenuPanel MainMenuPanel { get; private set; }
    public IInGamePanel InGamePanel { get; private set; }
    public IPausePanel PausePanel { get; private set; }
    public IShopPanel ShopPanel { get; private set; }
    public ILevelSuccessPanel LevelSuccessPanel { get; private set; }
    public ILevelFailedPanel LevelFailedPanel { get; private set; }
    
    private void Awake()
    {
        MainMenuPanel = FindObjectOfType<MainMenuPanel>(true);
        InGamePanel = FindObjectOfType<InGamePanel>(true);
        PausePanel = FindObjectOfType<PausePanel>(true);
        ShopPanel = FindObjectOfType<ShopPanel>(true);
        LevelSuccessPanel = FindObjectOfType<LevelSuccessPanel>(true);
        LevelFailedPanel = FindObjectOfType<LevelFailedPanel>(true);
        
        GetAllPanels();
        CloseAllPanels();
        OpenSpecificPanel(MainMenuPanel);
    }

    public Result GetAllPanels()
    {
        _allPanels = new List<UiPanel>();
        _allPanels = FindObjectsOfType<UiPanel>(true).ToList();
        return new SuccessResult();
    }

    public Result CloseAllPanels()
    {
        foreach (var panel in _allPanels)
        {
            panel.gameObject.SetActive(false);
        }

        return new SuccessResult();
    }

    public Result OpenSpecificPanel(IUiPanel uiPanel)
    {
        var result = _allPanels.FirstOrDefault(x => x == uiPanel);
        if (result)
        {
            CloseAllPanels();
            result.gameObject.SetActive(true);   
            return new SuccessResult();
        }

        return new ErrorResult("spesific panel doesnt exist");
    }

}
