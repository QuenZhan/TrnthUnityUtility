using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TRNTH.SchorsInventory.UI{
	public class Ingredient : IIngredient
	{
		public readonly static Ingredient[] CostTimeOnly=new Ingredient[]{new Ingredient(){Name="所需時間"}};
		public readonly static Ingredient[] Empty=new Ingredient[0];
		public string Name{get;set;}

		public Sprite Icon {get;set;}

		public byte Count {get;set;}

		public string Unit {get;set;}
	}
}
namespace TRNTH.SchorsInventory.UI.Component{
	public class Exchange : MonoBehaviour {
		[SerializeField]Text _name;
		[SerializeField]Text _description;
		[SerializeField]ExchangeIngredient[] _ingredients;
		[SerializeField]ExchangeIngredient[] _Results;
		public void Refresh(IExchange data){
			gameObject.SetActive(true);
			_name.text=data.Title;
			_description.text=data.Description;
			RefreshIngredient(data.Ingredients.GetEnumerator(),_ingredients);
			RefreshIngredient(data.Results.GetEnumerator(),_Results);
			_data=data;
		}
		IExchange _data;
		[SerializeField]SchorsInventory.Component.SjiaController _manager;
		void RefreshIngredient(IEnumerator<IIngredient> enumerator,ExchangeIngredient[] _ingredients){
			var max=_ingredients.Length;
			for(var i=0;i<max;i++){
				var has=enumerator.MoveNext();
				var cell=_ingredients[i];
				cell.gameObject.SetActive(has);
				if(!has)continue;
				cell.Refresh(enumerator.Current);
			}			
		}
		public void Select(ExchangeIngredient cell){

		}
		public void Execute(){
			// _data.Execute();
			_manager.Exchange(_data);
		}
	}

}
