using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapItem : MonoBehaviour
{
    [SerializeField] private TMP_Text mapName;
    [SerializeField] private Image mapThumbnail;
    [SerializeField] private Image treasure;
    [SerializeField] private GameObject infomationPopup;
    [SerializeField] private Button playButton;

    [Space(10), Header("Data")]
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;

    private LevelData levelData;
    private GameObject infomationPopupInstance = null;
    // Start is called before the first frame update

    private void Awake()
    {
        transform.AddComponent<EventTrigger>();
        // add event trigger pointer enter
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { OnCursorEnter(); });
        transform.GetComponent<EventTrigger>().triggers.Add(entry);
        //add event trigger pointer exit
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerExit;
        entry2.callback.AddListener((data) => { OnCursorExit(); });
        transform.GetComponent<EventTrigger>().triggers.Add(entry2);
        
        playButton.onClick.AddListener(OnClickPlay);

    }

    private void Update()
    {
        this.treasure.sprite = this.levelData.treasureData.avatar;
    }

    public void OnCursorEnter()
    {
        ConsoleLog.Log("OnMouseEnter");
        if (this.infomationPopupInstance != null) 
        {             
            Destroy(this.infomationPopupInstance.gameObject);
        }
        // caculate the position of the popup inside the window
        Vector2 windowPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 itemPos = transform.position;
        Debug.Log(itemPos);
        Vector2 popupPos = new Vector2();
        if (itemPos.x < 0)
        {
            popupPos.x =  400;
        }
        else
        {
            popupPos.x =  -400 ;
        }
        if (itemPos.y > -15 && itemPos.y < 15)
        {
            popupPos.y = 0;
        }
        else if (itemPos.y < 0)
        {
            popupPos.y =  200;
        }
        else
        {
            popupPos.y =  -200;
        }
        popupPos = transform.InverseTransformDirection(popupPos);
        Debug.Log(popupPos);
        this.infomationPopupInstance = Instantiate(this.infomationPopup, popupPos, Quaternion.identity, transform);
        var rectTransform = this.infomationPopupInstance.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(popupPos.x, popupPos.y, 0);
        TMP_Text mapName = this.infomationPopupInstance.transform.Find("ttMapName").gameObject.GetComponent<TMP_Text>();
        TMP_Text story = this.infomationPopupInstance.transform.Find("ttStory").gameObject.GetComponent<TMP_Text>();
        Image treasureImage = this.infomationPopupInstance.transform.Find("ttTreasureImage").gameObject.GetComponent<Image>();
        TMP_Text treasureDescription = this.infomationPopupInstance.transform.Find("ttTreasureDescription").gameObject.GetComponent<TMP_Text>();
        mapName.text = this.levelData.levelName;
        story.text = this.levelData.story;
        treasureImage.sprite = this.levelData.treasureData.avatar;
        treasureDescription.text = this.levelData.treasureData.description;
        // set the vertical layout for the popup
        this.infomationPopupInstance.GetComponent<VerticalLayoutGroup>().enabled = true;
        //set the transform is the hightest in the parent
        this.transform.SetAsLastSibling();
    }

    public void OnCursorExit()
    {
        Destroy(this.infomationPopupInstance?.gameObject);
    }

    public void setLevelData(LevelData levelData)
    {
        this.levelData = levelData;
        this.mapName.text = levelData.levelName;
        this.mapThumbnail.sprite = levelData.mapThumbnail;
        Sprite spriteTemp = levelData.treasureData.avatar;
    }
    public void OnClickPlay()
    {
        // Pass data
        runtimeGlobalData.DataStartGamePlay = new DataStartGamePlay(1, ExplorerType.Bishop);

        // Load scene
        LoadSceneController.Instance.LoadHomeToGame();
    }

}
