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

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        Vector2 popupPos = new Vector2();
        if (itemPos.x < 0)
        {
            popupPos.x = itemPos.x +250 /10;
        }
        else
        {
            popupPos.x = itemPos.x - 250 / 10;
        } 
        if (itemPos.y < 0)
        {
            popupPos.y = itemPos.y + 350 /10;
        }
        else
        {
            popupPos.y = itemPos.y - 350 / 10;
        }
        popupPos = transform.InverseTransformDirection(popupPos);
        Debug.Log(itemPos);
        Debug.Log(popupPos);
        this.infomationPopupInstance = Instantiate(this.infomationPopup, popupPos, Quaternion.identity, transform);
    }

    public void OnCursorExit()
    {
        Destroy(this.infomationPopupInstance?.gameObject);
    }

    public void setLevelData(LevelData levelData)
    {
        this.levelData = levelData;
    }


}
