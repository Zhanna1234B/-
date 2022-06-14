using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IDropHandler
{
    public int slotID;
    private Shop_3 camera;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<Shop_3>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        var itemID = eventData.pointerDrag.GetComponent<UIItem>().itemID;
       
        if (itemID == slotID)
        { 
            camera.count += 1;
          
            var otherItemTransform = eventData.pointerDrag.transform;
            otherItemTransform.SetParent(transform);
            otherItemTransform.localPosition = Vector3.zero;
        }
        else
        {
           
           
        }

    }


    
}
