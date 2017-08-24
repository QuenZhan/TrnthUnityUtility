using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace TRNTH.SchorsInventory.UI.Component{
	public class ExchangeIngredient : MonoBehaviour,IPointerDownHandler,IPointerEnterHandler {
			[SerializeField]Text _Name;
		[SerializeField]Text _Caption;
		[SerializeField]Text _Description;
		[SerializeField]Image _Icon;
		public void Refresh(IIngredient ingredient){
				_Name.text=ingredient.Name;
				_Caption.text=Utility.IntToStringNonAllocUnder1000(ingredient.Count);
				_Description.text=ingredient.Unit;
				_Icon.sprite=ingredient.Icon;
			}
			[SerializeField]Exchange Container;
			
			        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
			Container.Select(this);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            Container.Select(this);
        }
	}

}
