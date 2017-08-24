using System.Collections;
using System.Collections.Generic;
using TRNTH.SchorsInventory.DeadDatabase;
using TRNTH.SchorsInventory.UI;
using UnityEngine;
namespace TRNTH.SchorsInventory.Component{

	public abstract class Facility : MonoBehaviour ,IContainerData{
		[SerializeField]Place _place;
		// public Place Place{get{return _place;}}
			string IContainerData.Title {get{return _place.Name;}}

			const string PlaceInString="地點";
			string IContainerData.Caption{get{return PlaceInString;}}
			
			Sprite IContainerData.Icon {get{return _place.Icon;}}

			string IContainerData.Description{get{return _place.Description;}}

			bool IContainerData.UsingSlider {get{return false;}}

			float IContainerData.SliderValue {get{return 0;}}

			// protected abstract IReadOnlyList<IItemData> Activities{
			// 	get;
			// }
			protected abstract IItemData Item0{get;}
			protected abstract IItemData Item1{get;}
			protected abstract IItemData Item2{get;}
			protected abstract IItemData Item3{get;}
			readonly IItemData[] _items=new IItemData[4];
			IReadOnlyList<IItemData> IContainerData.Items {
				get{
				_items[0]=Check(Item0);
				_items[1]=Check(Item1);
				_items[2]=Check(Item2);
				_items[3]=Check(Item3);
				return _items;
				}
			}
			IItemData Check(IItemData data){
				if(data is Conversation){
					var scenario=(Conversation)data;
					var contains=SjiaController.Instance.UserData.Memories.Contains(scenario);
					if(contains)return null;
				}
				return data;
			}
			

    }
}
