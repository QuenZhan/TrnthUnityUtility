using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace TRNTH.SchorsInventory.UI.Component{
	public class Option : MonoBehaviour,IPointerEnterHandler,ISelectHandler{
		[SerializeField]Text _Name;
		[SerializeField]Text _Caption;
		[SerializeField]Text _Description;
		[SerializeField]Image _Icon;
		public void Refresh(IItemData data){
			var has=data!=null;
			gameObject.SetActive(has);
			if(!has){
				return;
			}
			_Name.text=data.Name;
			_Caption.text=data.Caption;
			_Description.text=data.Description;
			_Icon.sprite=data.Icon;
		}		
		public OptionList Container;

        // void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        // {
		// 	Container.Select(this);
        // }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            Container.Select(this);
        }

        void ISelectHandler.OnSelect(BaseEventData eventData)
        {
			Container.Select(this);
        }
    }

}
