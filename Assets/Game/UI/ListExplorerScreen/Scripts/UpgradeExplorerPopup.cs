using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeExplorerPopup : MonoBehaviour
{
    [SerializeReference] private LevelDataAsset levelDataAsset;
    [SerializeField] private TMP_Text Detail;
    [SerializeField] private TMP_Text Cost;
    [SerializeField] private Button Upgrade;
    [SerializeField] private Button cancel;
    [SerializeField] private Transform holderExplorer;
    [SerializeField] private InventoryDataAsset inventoryDataAsset;
    // Start is called before the first frame update

    private ExplorerType currentExplorer;
    private void Awake()
    {
        Upgrade.onClick.AddListener(() =>
        {
            inventoryDataAsset.TryChangeCoin(-levelDataAsset.GetIncreateExplorerBaseInfoBetweenLevel(this.currentExplorer).Price);
            levelDataAsset.levelUp(this.currentExplorer);
            holderExplorer.gameObject.SetActive(true);
            transform.gameObject.SetActive(false);
        });
        cancel.onClick.AddListener(() =>
        {
            holderExplorer.gameObject.SetActive(true);
            transform.gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void SetData(ExplorerType explorer, int level)
    {
        LevelUpData levelNextData = levelDataAsset.GetIncreateExplorerBaseInfoBetweenLevel(explorer);
        ExplorerBaseInfo explorerBaseInfo = levelDataAsset.GetExplorerBaseInfoWithLevel(explorer, level + 1);
        Detail.text = "Level " + level + " -> " + "Level " + (level + 1) + "\n" +

           string.Format(
            "HP:                   {0,-4}(+{1,-3})\n" +
            "Attack:             {2,-4}(+{3,-3})\n" +
            "Rate Attack:     {4,-4}(+{5,-3})\n" +
            "Defense:           {6,-4}(+{7,-3})\n" +
            "Attack Range:   {8,-4}(+{9,-3})\n" +
            "Move Speed:     {10,-4}(+{11,-3})\n" +
            "Jump Velocity: {12,-4}(+{13,-3})\n",
            explorerBaseInfo.HP, levelNextData.HP,
            explorerBaseInfo.Attack, levelNextData.Attack,
            explorerBaseInfo.RateAttack, levelNextData.RateAttack,
            explorerBaseInfo.Defense, levelNextData.Defense,
            explorerBaseInfo.AttackRange, levelNextData.AttackRange,
            explorerBaseInfo.MoveSpeed, levelNextData.MoveSpeed,
            explorerBaseInfo.JumpVelocity, levelNextData.JumpVelocity
        );
        Cost.text = levelNextData.Price.ToString() + "/" + this.inventoryDataAsset.Coin;

        currentExplorer = explorer;
        if (levelNextData.Price > this.inventoryDataAsset.Coin)
        {
            Upgrade.interactable = false;
        }
        else
        {
            Upgrade.interactable = true;
        }
    }   
}
