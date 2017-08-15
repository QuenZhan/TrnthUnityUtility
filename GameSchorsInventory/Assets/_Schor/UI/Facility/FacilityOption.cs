using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace TRNTH.SchorsInventory.UI.Component{

public class FacilityOption : MonoBehaviour, IPointerDownHandler{
    public Text Name;
    public Facility Container;

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            Container.Select(this);
        }
    }
}