using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExplorerDetailPanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text explorerDetail;
    [SerializeField] private Image skillImange;
    [SerializeField] private TMP_Text skillDescription;
    [SerializeField] private GameObject skillTab;
    [SerializeField] private GameObject detailTab;

    [Space(12)]
    [SerializeField] private ListExplorerScreen listExplorerScreen;

    private ExplorerBaseInfo currentExplorerBaseInfo;


    // Update is called once per frame
    void Update()
    {
        currentExplorerBaseInfo = listExplorerScreen.GetCurrentExplorerBaseInfo();
        DisplayDetail(currentExplorerBaseInfo);
        DisplaySkill(currentExplorerBaseInfo);
    }

    public void OnClickNavigationButton(bool isDetailTab)
    {
        if (isDetailTab) { detailTab.SetActive(true); skillTab.SetActive(false); }
        else { skillTab.SetActive(true); detailTab.SetActive(false); }
    }

    private void DisplayDetail(ExplorerBaseInfo explorerBaseInfo)
    {
        explorerDetail.text =
            "HP: " + explorerBaseInfo.HP + "\n" +
            "Attack: " + explorerBaseInfo.Attack + "\n" +
            "Rate Attack: " + explorerBaseInfo.RateAttack + "\n" +
            "Defense: " + explorerBaseInfo.Defense + "\n" +
            "Attack Range: " + explorerBaseInfo.AttackRange + "\n" +
            "Move Speed: " + explorerBaseInfo.MoveSpeed + "\n" +
            "Jump Velocity: " + explorerBaseInfo.JumpVelocity + "\n";
    }
    private void DisplaySkill(ExplorerBaseInfo explorerBaseInfo)
    {
        skillImange.sprite = explorerBaseInfo.SkillData.Icon;
        skillDescription.text = explorerBaseInfo.SkillData.Description;
    }



}
