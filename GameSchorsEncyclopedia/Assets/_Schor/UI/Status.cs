using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TRNTH.SchorsInventory.UI.Component{
	public class Status : MonoBehaviour {
		[SerializeField]Slider _clock;
		[SerializeField]Text _Stamina;
		[SerializeField]Image _PlaceIcon;
		[SerializeField]Text _placeName;
		public void Refresh(RuntimeDatabase.UserData userdata){
			float hours=userdata.DateTime.Hour%12/12f+userdata.DateTime.Minute/60f;
			_clock.value=hours;
			_Stamina.text=Utility.IntToStringNonAllocUnder1000(userdata.Stamina.TotalHours);
			_PlaceIcon.sprite=userdata.Place.Icon;
			_placeName.text=userdata.Place.Name;
		}
	}

}
