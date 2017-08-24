using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TRNTH.SchorsInventory.UI;
using TRNTH.SchorsInventory.DeadDatabase;

namespace TRNTH.SchorsInventory{
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
	// public interface IFacilityOption{
	// 	string Name{get;}
	// }
    // [System.Serializable]public class FacilityOption : IFacilityOption
    // {
	// 	[SerializeField]string _Name;
    //     string IFacilityOption.Name {get{return _Name;}}
    // }
}
namespace TRNTH.SchorsInventory.Component{
	public class Place : MonoBehaviour
	 ,IPointerEnterHandler
	 ,ISelectHandler
	 ,IItemSelector
	 ,IContainerData
	 {
		public string Name{get{return _Name;}}

        string IContainerData.Title {get{throw new NotImplementedException();}}

        string IContainerData.Caption {get{throw new NotImplementedException();}}

        Sprite IContainerData.Icon {get{throw new NotImplementedException();}}

        string IContainerData.Description {get{throw new NotImplementedException();}}

        bool IContainerData.UsingSlider {get{throw new NotImplementedException();}}

        float IContainerData.SliderValue {get{throw new NotImplementedException();}}

        IReadOnlyList<IItemData> IContainerData.Items {get{throw new NotImplementedException();}}

        [Multiline]public string Description;
		[SerializeField]UI.Component.OptionList _detailer;
		[SerializeField]Text _NameText;
		[SerializeField]string _Name;
		public Sprite Icon;
		[SerializeField]Transport[] _transports;
		[SerializeField]UI.Component.Exchange _TransportExecutionPage;
		[SerializeField]Facility _facility;
        // void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        // {
		// 	Select();
		// }
		void Start()
		{
			_NameText.text=_Name;
		}
		void Select(){
			_TransportExecutionPage.gameObject.SetActive(false);
			if(SjiaController.Instance.UserData.Place==this){
				_detailer.Executeor=this;
				_detailer.Refresh(_facility);
			}
			else{
				_transport.Datas.Clear();
				foreach(var e in SjiaController.Instance.UserData.Place._transports){
					if(e.Destination!=this)continue;
					_transport.Datas.Add(e);	
				}
				_transport.Destinartion=this;
				_detailer.Refresh(_transport);
				_detailer.Executeor=this;
			}

		}

        // void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        // {
        //     Select();
        // }
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
		// Facility _facility;
        class ContainerDataBase : IContainerData
        {
			[SerializeField]string _Title;
            string IContainerData.Title {get{return _Title;}}
			[SerializeField]string _caption;
            string IContainerData.Caption {get{return _caption;}}

            Sprite IContainerData.Icon {get{return null;}}
			[Multiline][SerializeField]string _Description;

            string IContainerData.Description{get{return _Description;}}

            bool IContainerData.UsingSlider{get{ throw new NotImplementedException();}}

            float IContainerData.SliderValue{get{ throw new NotImplementedException();}}

            IReadOnlyList<IItemData> IContainerData.Items {get  {throw new NotImplementedException();}}
        }
        [System.Serializable]
        class TransportOptions : IContainerData
        {
			public IList<Transport> Datas{
				get{
					return _Datas;
				}				
			}
			readonly List<Transport> _Datas=new List<Transport>();
			public Place Destinartion;
            string IContainerData.Title {
				get{
					return Goto;
				}
			}
			const string Goto="前往…";

            string IContainerData.Caption {get{return Destinartion.Name;}}

            Sprite IContainerData.Icon {get{return Destinartion.Icon;}}

            string IContainerData.Description{get{return string.Empty;}}

            bool IContainerData.UsingSlider {get{return false;}}

            float IContainerData.SliderValue {get{return 0;}}

            IReadOnlyList<IItemData> IContainerData.Items{get{return _Datas;}}
        }
        // [System.Serializable]
        // class Facility : ContainerDataBase{
        // }
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

		Sprite IItemData.Icon {get{return Method.Icon;}}

		public string Name {get{return Destination.Name;}}

		public string Description {get{return Method.Description;}}

		string IItemData.Caption {get{return Method.Name;}}

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

		[SerializeField]float _Hours;
	}

}
