using System.Collections;
using System.Collections.Generic;
using TRNTH.SchorsInventory.Component;
using UnityEngine;
using UnityEngine.UI;
namespace TRNTH.SchorsInventory.UI.Component{
	public class PlaceDetail : MonoBehaviour {
		[SerializeField]Text _Name;
		[SerializeField]Text _Description;
		[SerializeField]Text _CostTime;
		public Place Place;
		System.TimeSpan  costime=new System.TimeSpan(0,10,0);
		void Start()
		{
			gameObject.SetActive(false);
		}
		public void Go(){
			var userdata=SjiaController.Instance.UserData;
			userdata.Place=Place;
			userdata.DateTime=userdata.DateTime.Add(costime);
			SjiaController.Instance.ScenarioController.ChangePlace(Place);
			gameObject.SetActive(false);
		}
		public void Refresh(Place place){
			this.Place=place;
			_Name.text=place.Name;
			_Description.text=place.Description;
			_CostTime.text=Utility.IntToStringNonAllocUnder1000(costime.Minutes);
			gameObject.SetActive(true);
			SjiaController.Instance.ScenarioController.SelectPlace(Place);
		}
	}

}
