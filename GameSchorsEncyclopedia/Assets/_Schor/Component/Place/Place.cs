using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TRNTH.SchorsInventory.UI;
using TRNTH.SchorsInventory.DeadDatabase;
using TRNTH.SchorsInventory.RuntimeDatabase;

namespace TRNTH.SchorsInventory.Component
{
    public class Place : MonoBehaviour
	 ,IPointerEnterHandler
	 ,ISelectHandler
	 ,IItemSelector
	 ,IContainerData
	 {
		public string Name{get{return _Name;}}

        public string Title {get{return _Name;}}
		const string Facility="設施";
        public string Caption {get{return Facility;}}

        Sprite IContainerData.Icon{get{return Icon;}}

        string IContainerData.Description {get{return Description;}}

        public bool UsingSlider {get{return false;}}

        public float SliderValue {get{return 0;}}
		// protected ItemData[] Items{get{
		// 	return _items;
		// }}
		protected virtual void BeforeItems(IItemData[] _datas){

		}
        public virtual IReadOnlyList<IItemData> Items {
			get{
				BeforeItems(_items);
				return _items;
			}
		}
		// protected virtual IItemData Item0{get{return null;}}
		// protected virtual IItemData Item1{get{return null;}}
		// protected virtual IItemData Item2{get{return null;}}
		// protected virtual IItemData Item3{get{return null;}}
		// protected virtual IItemData Item4{get{return null;}}
		// protected virtual IItemData Item5{get{return null;}}
		// protected virtual IItemData Item6{get{return null;}}
		// protected virtual IItemData Item7{get{return null;}}
		// protected virtual IItemData Item8{get{return null;}}
		// protected virtual IItemData Item9{get{return null;}}
		readonly IItemData[] _items=new IItemData[10];
		// IItemData Check(IItemData data){
		// 		if(data is Conversation){
		// 			var scenario=(Conversation)data;
		// 			var contains=SjiaController.Instance.UserData.Memories.Contains(scenario);
		// 			if(contains)return null;
		// 		}
		// 		return data;
		// 	}

        [Multiline]public string Description;
		[SerializeField]UI.Component.OptionList _detailer;
		[SerializeField]Text _NameText;
		[SerializeField]string _Name;
		public Sprite Icon;
		[SerializeField]Transport[] _transports;
		public IReadOnlyCollection<Transport> Transports{get{return _transports;}}
		[SerializeField]UI.Component.Exchange _TransportExecutionPage;
		// [SerializeField]Facility _facility;
		void Start()
		{
			if(_NameText)_NameText.text=_Name;
		}
		// UserData UserData;
		[SerializeField]Manager _manager;
		void Select(){
			_manager.SelectPlace(this);
		}
		[ContextMenu("TestExecute")]
		void ExchangePageRefresh(){
			_TransportExecutionPage.Refresh(_transports[0]);
		}
        void IItemSelector.Select(IItemData item)
        {
            if(item is IExchange){
				_TransportExecutionPage.Refresh((IExchange)item);
			}
        }

        void ISelectHandler.OnSelect(BaseEventData eventData)
        {
            // throw new NotImplementedException();
			Select();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            Select();
        }

        // public IReadOnlyList<IFacilityOption> Options{get{return _options;}}
        TransportOptions _transport=new TransportOptions();
    }
	[System.Serializable]public class Transport:
		IItemData
	,IExchange
	{
		public DeadDatabase.TransportMethod Method;
		public Place Destination;
		public System.TimeSpan CostTime{
			get{
				var hours=(int)_Hours;
				var mintues=(_Hours-hours)*60;
				return new System.TimeSpan(hours,(int)mintues,0);
			}
			set{
				_Hours=(int)value.TotalHours+value.Minutes/60f;
			}
		}

		// Sprite IItemData.Icon {get{return Method.Icon;}}

		// public string Name {get{return Destination.Name;}}

		// public string Description {get{return Method.Description;}}

		// string IItemData.Caption {get{return Method.Name;}}

		string IExchange.Title {get{return Method.Name;}}
		[SerializeField]Sprite _CostIcon;
		[SerializeField]Sprite _TranfertIcon;
		IReadOnlyCollection<IIngredient> IExchange.Ingredients{
			get{
				var ing=UI.Ingredient.CostTimeOnly[0];
				var hasHour=CostTime.Hours>0;
				ing.Unit=hasHour?HourInStr:MinuteInString;
				ing.Count=(byte)(hasHour?CostTime.Hours:CostTime.Minutes);
				ing.Icon=_CostIcon;
				return UI.Ingredient.CostTimeOnly;
				}
			}
		public const string HourInStr="小時";
		public const string MinuteInString="分鐘";
		IReadOnlyCollection<IIngredient> IExchange.Results{
			get{
				return UI.Ingredient.Empty;
			}
		}

        string IAction.Name{get{return Name;}}

        string IAction.Description {get{return Description;}}

        [SerializeField]float _Hours;
	}

}

namespace TRNTH.SchorsInventory
{
    public interface IExchange:IAction{
		string Title{get;}
		// string Description{get;}
		// System.TimeSpan CostTime{get;}
		IReadOnlyCollection<IIngredient> Ingredients{get;}
		IReadOnlyCollection<IIngredient> Results{get;}
	}
	public interface IExchange<ItemData>:IExchange{

	}
	public interface IIngredient{
		string Name{get;}
		Sprite Icon{get;}
		byte Count{get;}
		string Unit{get;}
	}
}