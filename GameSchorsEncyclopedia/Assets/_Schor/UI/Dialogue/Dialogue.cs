using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TRNTH.SchorsInventory.UI.Component{
	public class Dialogue : MonoBehaviour {

		[SerializeField]Text _name;
		[SerializeField]Text _content;
		[SerializeField]Image _Tachie;
		[SerializeField]Color _systemColor=Color.gray;
		public void Refresh(DeadDatabase.Dialogue data){
			gameObject.SetActive(true);
			_content.text=data.Content;
			_content.color=_systemColor;
			_name.text=string.Empty;
			_name.color=_systemColor;
			_Tachie.gameObject.SetActive(data.Character!=null);
			if(data.Character!=null){
				_name.text=data.Character.Name;
				_name.color=data.Character.Color;
				_content.color=data.Character.Color;
				_Tachie.sprite=data.Character.Tachie;
			}
		}
		void Start()
		{		
			gameObject.SetActive(false);
		}
	}

}
