using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace TRNTH.SchorsInventory{
	public interface IFacilityOption{
		string Name{get;}
		// void Execute();
	}
    [System.Serializable]public class FacilityOption : IFacilityOption
    {
		[SerializeField]string _Name;
        string IFacilityOption.Name {get{return _Name;}}
    }
}
namespace TRNTH.SchorsInventory.Component{
	public class Place : MonoBehaviour ,IPointerDownHandler{
		public string Name{get{return _Name.text;}}
		[Multiline]public string Description;
		[SerializeField]UI.Component.PlaceDetail _detailer;
		[SerializeField]UI.Component.Facility _facility;
		[SerializeField]Text _Name;
		[SerializeField]FacilityOption[] _options;
        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
			if(Manager.Instance.UserData.Place==this){
				_facility.Refresh(this);
			}
			else{
				_detailer.Refresh(this);
			}
		}
		public IReadOnlyList<IFacilityOption> Options{get{return _options;}}
    }

}
