using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using Prototype.Data;

namespace Playground
{
    public class TestInventoryExpand : EventTrigger
    {
        public override void OnPointerEnter(PointerEventData data)
        {
            //Debug.Log("OnPointerEnter called.");
        }

        public override void OnPointerExit(PointerEventData data)
        {
            HidePanel();
            //Debug.Log("OnPointerExit called.");
        }

        public void ShowPanel()
        {
            gameObject.SetActive(true);
        }

        public void HidePanel()
        {
            gameObject.SetActive(false);
        }
    }
}