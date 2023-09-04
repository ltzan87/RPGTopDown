using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    public Image waterUIBar;
    public Image woodUIBar;
    public Image carrotUIBar;

    [Header("Tools")]
    // public Image axeUI;
    // public Image shovelUI;
    // public Image bucketUI;
    public List<Image> toolsUI = new List<Image>();
    public Color selectColor;
    public Color alphaColor;

    private PlayerITEMS _playerITEMS;
    private Player _player;


    private void Awake() {
        _playerITEMS = FindObjectOfType<PlayerITEMS>();
        _player = _playerITEMS.GetComponent<Player>();
    }

    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
    }

    void Update()
    {
        UIBar();
        ToolsSelection();
    }

    public void UIBar()
    {
        waterUIBar.fillAmount = _playerITEMS.currentWater / _playerITEMS.waterLimit;
        woodUIBar.fillAmount = _playerITEMS.totalWood / _playerITEMS.woodLimit;
        carrotUIBar.fillAmount = _playerITEMS.items / _playerITEMS.carrotsLimit;
    }

    public void ToolsSelection()
    {
        //toolsUI[_player._handlingObj].color = selectColor;

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if (i == _player._handlingObj)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}