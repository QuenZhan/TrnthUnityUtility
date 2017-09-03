using System;
using System.Collections;
using System.Collections.Generic;
using TRNTH.SchorsInventory.DeadDatabase;
using TRNTH.SchorsInventory.RuntimeDatabase;
using TRNTH.SchorsInventory.UI.Component;
using UnityEngine;
namespace TRNTH.SchorsInventory.Component
{
    public class Manager : MonoBehaviour{
		// public void ShowEx
		// [SerializeField]Sleep _sleep;
		[SerializeField]Status _status; 
		[SerializeField]GameObject[] _ExchangeToReset;
		// static public IManager Instance{get;private set;}
		public OptionList OptionListPage;
		public Exchange ExchangePage;
		// public void Participate(ILesson lesson){

		// // }
		// class ILesson{
			
		// }

        public UserData UserData {get{return _UserData;}}
		public void Exchange(IAction data){
			foreach(var e in _ExchangeToReset){
				e.SetActive(false);
			}
			Act(data);
		}
		
		Item[] _tempStock=new Item[9];
		void Act(IAction data){
			var user=UserData;
			if(user.Stamina<data.CostTime)throw new System.InvalidOperationException();
			user.DateTime=user.DateTime.Add(data.CostTime);
			user.Stamina-=data.CostTime;
			_status.Refresh(user);
		}
		public void Move(ITransport transport){
			Act(transport);
			var user=UserData;
			user.Place=transport.Destination;
			_evenSystem.SetSelectedGameObject(user.Place.gameObject,_baseEvent);
			OptionListPage.Refresh(user.Place);
			_status.Refresh(UserData);
		}
		public void Talk(IConversation scenario){
			Act(scenario);
			// _Scenario=scenario;
			ScenarioNext();
		}
		ISignature _Me;
		public bool Promise(IPromise contract,IPerson person){
			Act(contract);
			contract.Signatures.Add(_Me);
			if(!person.Sign(contract) || !contract.IsValid)return false;
			UserData.Schedule.Add(contract);
			_Console.Add("已加入行事曆",contract.Title);
			return true;
		}
		public bool Cancel(IPromise promise,IPerson person){
			Act(promise);
			if(!person.Cancel(promise))return false;
			promise.Signatures.Remove(_Me);
			if(promise.IsValid)return false;
			UserData.Schedule.Remove(promise);
			return true;
		}
		
		public bool Keep(IPromise promise,IPerson person,IInventory table){
			Act(promise);
			var okay=Utility.IsFullfill(promise.Requirement,table)
			&& UserData.DateTime> promise.BeginingDate 
			&& UserData.DateTime< promise.ExpiringDate
			&& UserData.Place==promise.Place
			&& promise.IsValid
			&& promise.Signatures.Contains(_Me)
			&& person.Keep(promise)
			;
			if(okay){
				UserData.Schedule.Remove(promise);
				UserData.Credit.Add(promise);
			}
			return okay;
		}
		void Update()
		{
			var timeSpan=new TimeSpan(0,0,0,0,(int)(Time.deltaTime*1000));
			UserData.DateTime=UserData.DateTime.Add(timeSpan);
			UserData.Stamina-=timeSpan;
			_status.Refresh(UserData);
		}
		[ContextMenu("Refresh")]
		void Refresh(){
			if(UserData.Place!=null){
				this.OptionListPage.Refresh(UserData.Place);
			}
		}
		/// 國語文件撰寫＝紙＋墨水 in 有書桌的地方
		/// 產物可能形容詞＝素材的形容詞，相同位置相同形容詞，效果會疊加，不相同的會隨機挑一個
		
		
		
		readonly List<AttributeData> _tmpAdjectives=new List<AttributeData>(Item.MaxAdjectivesCount);
		readonly List<bool> _tmpHidden=new List<bool>(Item.MaxAdjectivesCount);
		// readonly HashSet<ItemData> _requirement=new HashSet<ItemData>();
		// readonly HashSet<ItemData> _ingredient=new HashSet<ItemData>();
		[SerializeField]UnityEngine.EventSystems.EventSystem _evenSystem;
        [SerializeField]UnityEngine.EventSystems.BaseEventData _baseEvent;

        // IScenarioController IManager.ScenarioController {get{return _scenarioController;}}

        [SerializeField]UserData _UserData;
		public DeadDatabase.Conversation _Scenario;
		[SerializeField]IScenarioController _scenarioController;
		[SerializeField]UI.Component.Console _Console;
		[SerializeField]UI.Component.Dialogue _dialouge;
		[SerializeField]Place _startPlace;
		public void ScenarioNext(){
			if(_Scenario==null){
				// _Scenario=_scenarioController.Choose();
			}
			// if(_Scenario==null || _UserData.Memories.Contains(_Scenario)){
			// 	_Scenario=null;
			// 	return;
			// }
			if(Index>=_Scenario.Dialogues.Count){
				// _UserData.Memories.Add(_Scenario);
				_scenarioController.End(_Scenario);
				_Scenario=null;
				this.Index=0;
				_dialouge.gameObject.SetActive(false);
				return;
			}
			var dia=_Scenario.Dialogues[Index++];
			_Console.Add(dia.Character.Name,dia.Content);
			_dialouge.Refresh(dia);
		}
		bool TiredCheck(){
			if(UserData.Stamina.Ticks>0){				
				return true;
			}
			_TiredActions.Manager=this;
			OptionListPage.Refresh(_TiredActions);
			return false;
		}
		readonly TiredActions _TiredActions=new TiredActions();
        class TiredActions : IContainerData
        {
			public Manager Manager;
			void Sleep(){
				var UserData=Manager.UserData;
				UserData.Stamina=new System.TimeSpan(recoverStamina,0,0);
				UserData.DateTime=UserData.DateTime.AddHours(PastHour());
				Manager._Console.Add("睡");
			}
            public void Select(IItemData item)
            {
                Sleep();
            }
            public string Title {get;private set;}="好累喔不想動了";

            public string Caption  {get;private set;}="體力耗盡";
			
            public Sprite Icon{get{return null;}}

            public string Description {get;private set;}="好累喔不想動了";

            public bool UsingSlider {get{return false;}}

            public float SliderValue {get{return 0;}}
			readonly IItemData[] items=new IItemData[1]{
				new IItemData{
						Name="睡覺"
						,Description="恢復體力"
					}
			};
			int recoverStamina;
			int PastHour(){
				return (int)Mathf.Lerp(2,12,(recoverStamina-12)/4);
			}
            public IReadOnlyList<IItemData> Items {
				get{
					var UserData=Manager.UserData;
					recoverStamina=UnityEngine.Random.Range(12,16);
					items[0].Caption=Utility.IntToStringNonAllocUnder1000(PastHour());
					return items;
				}
			}
        }
        public void SelectPlace(Place place){
			if(!TiredCheck())return;
			var _detailer=OptionListPage;
			if(UserData.Place==place){
				_detailer.Refresh(place);
			}
			else{
				_transport.Datas.Clear();
				foreach(var e in UserData.Place.Transports){
					if(e.Destination!=place)continue;
					_transport.Datas.Add(e);	
				}
				_transport.Destinartion=place;
				_detailer.Refresh(_transport);
			}
		}
		TransportOptions _transport=new TransportOptions();
		IEnumerator Start()
		{
			// Instance=this;
			if(UserData.Place==null)UserData.Place=this._startPlace;
			yield return null;
			// _scenarioController.AfterMainthreadStart();
			_status.Refresh(UserData);
		}

        public void Select(IItemData item)
        {
			if(item is IExchange){
				this.ExchangePage.Refresh((IExchange)item);
			}
            // throw new NotImplementedException();
        }


        // void IScenarioPlayer.Play(IConversation scenario)
        // {
        //     // _Scenario=scenario;
        // 	ScenarioNext();
        // }

        int Index;
	}

}

namespace TRNTH.SchorsInventory
{
    public interface IManager:IScenarioPlayer{
		void StartTial(ITrialSet trial);
		ConversationBuilder ConversationBuilder{get;}
		void ShowTrade();
	}
	public interface ITrial {
		IReadOnlyCollection<Item> Requirement{get;}
		void Pass();
		void Fail();
	}
	public interface ITrialSet:IReadOnlyCollection<ITrial>{
		ISignature Judge{get;}
		void Pass();
		void Fail();
	}
	public interface IItemSelector{
		void Select(IItemData item);
	}
	public interface IContainerData:IItemSelector{
		string Title{get;}
		string Caption{get;}
		Sprite Icon{get;}
		string Description{get;}
		bool UsingSlider{get;}
		float SliderValue{get;}
		IReadOnlyList<IItemData> Items{get;}
	}
	public class IItemData	{
		public Sprite Icon;
		public string Name;
		public string Description;
		public string Caption;
	}
	public interface IAction{
		string Name{get;}
		string Description{get;}
		System.TimeSpan CostTime{get;}
		// void Execute(SjiaData sjiaData);
	}
	public interface IPriceable{
		int Price{get;}
	}
	public interface IRecipe:IAction{
		IReadOnlyList<ItemData> Ingredients{get;}
		IReadOnlyCollection<ItemData> Result{get;}
		IReadOnlyList<AttributeData> Adjectives{get;}
	}
	public interface ITransport:IAction{
        Component.Place Destination {get;}
	}
	public interface IInventory:IList<Item>{
		int Capacity{get;}
	}
	public interface ITrader{
		IPriceable ForSell{get;}
		// void Trade(IInventory table);
	}
	public class Trader{
		IInventory stock;
		Item[] _tempStock=new Item[Item.MaxAdjectivesCount];

        public IReadOnlyList<IPriceable> ForSells {get{return null;}}
		const string NotEnoughMoney="金錢不足，還差：";
		const string Success="交易成功";
        public bool Trade(IPriceable target,IInventory table,UI.Component.Console _console){
			var price=0;
			foreach(var e in table){
				var currency=(IPriceable)e;
				price+=currency.Price*e.Count;
			}
			price-=target.Price;
			if(price<0){
				_console.Add(NotEnoughMoney,TRNTH.Utility.IntToStringNonAllocUnder1000(-price));
				return false;
			}
			table.Clear();
			stock.CopyTo(_tempStock,0);
			foreach(var e in _tempStock){
				if(price<=0)break;
				var currency=e as IPriceable;
				if(currency==null)continue;
				var count=price/currency.Price;
				if(e.Count>count){
					var item=new Item{Data=e.Data,Count=(byte)count};
					e.Adjectives.CopyTo(item.Adjectives,0);
					table.Add(item);
					e.Count-=(byte)count;
					break;
				}
				table.Add(e);
				stock.Remove(e);
				price-=count*currency.Price;
			}
			_console.Add(Success);
			return true;
		}
    }	
	public interface ISignature{
		string Name{get;}
	}
	public interface IPerson:ISignature{
		bool Sign(IPromise promise);
		bool Cancel(IPromise promise);
		bool Keep(IPromise promise);
	}
    class ExamplerPerson : IPerson
    {
		const string ExamplerPersonStrName="ExamplePerson";
        public string Name {get{return ExamplerPersonStrName;}}
		ISet<IPromise> _schedule;
		const int ScheduleMax=10;
        bool IPerson.Cancel(IPromise promise)
        {	
			if(_schedule.Contains(promise)){
				_schedule.Remove(promise);
				return true;
			} 
			return false;
        }

        bool IPerson.Sign(IPromise promise)
        {
			if(_schedule.Count>=ScheduleMax)return false;
             _schedule.Add(promise);
			 return true;
        }

        bool IPerson.Keep(IPromise promise)
        {
			if(!_schedule.Contains(promise))return false;
            _schedule.Remove(promise);
			return true;
        }
    }

    public interface ICorporation:IPerson{

	}
	public interface INaturalPerson:IPerson{
		Gender Gender{get;} 
	}
	public enum Gender{
		None,Male,Female
	}
	public interface IEvent{
		string Title{get;}
		Component.Place Place{get;}
		System.DateTime BeginingDate{get;}
		System.DateTime ExpiringDate{get;}
		IReadOnlyCollection<Item> Requirement{get;}
	}
	public interface IPromise:IAction,IEvent{
		ICollection<ISignature> Signatures{get;}
		bool IsValid{get;}
	}
    [System.Serializable]class Sleep : IItemData
    {
		public void Reresh(UserData userdata){
			// manger.
			// userdata

		}
		
        public string Title{get;private set;}="睡…睡了";

        public IReadOnlyCollection<IIngredient> Ingredients {get{throw new NotImplementedException();}}

        public IReadOnlyCollection<IIngredient> Results {get{throw new NotImplementedException();}}


        public TimeSpan CostTime {get;private set;}
    }
	public class Utility:TRNTH.Utility{
		public void Craft(IRecipe recipe,IInventory table){
			var length=table.Count;
			var correctCount=0f;
			for (int i = 0; i < length; i++)
			{
				if(table[i].Data==recipe.Ingredients[i])correctCount++;
			}
			var successChance=correctCount/length;
			if(UnityEngine.Random.value>successChance)return;
			table.CopyTo(_tempStock,0);
			table.Clear();
			foreach(var e in recipe.Result){
				var newItem=new Item(){Data=e};
				length=Item.MaxAdjectivesCount;
				for (int i = 0; i < length; i++)
				{
					_tmpAdjectives.Clear();
					var reciepeAttributeData=recipe.Adjectives[i];
					TryAdd(_tmpAdjectives,reciepeAttributeData,e.AvailibleAdjectives);
					// _tmpHidden.Add(true);
					foreach(var ingredient in _tempStock){
						if(ingredient==null)continue;
						var adj=ingredient.Adjectives[i];
						if(adj==null)continue;
						TryAdd(_tmpAdjectives,adj.Data,e.AvailibleAdjectives);
						// _tmpHidden.Add(adj.Hidden);
					}
					if(_tmpAdjectives.Count<1)continue;
					var newAdj=new Adjectives(){
						Data=_tmpAdjectives.RandomChooseNonAlloc()
						,Value=(byte)_tmpAdjectives.Count
						// ,Hidden=_tmpHidden.RandomChooseNonAlloc()
						};
					newItem.Adjectives[i]=newAdj;
				}
				table.Add(newItem);
			}
		}
		readonly List<AttributeData> _tmpAdjectives=new List<AttributeData>(9);
		readonly Item[] _tempStock=new Item[9];
		void TryAdd(IList<AttributeData> list, AttributeData data,IReadonlyHashSet<AttributeData> filter){
			if(filter.Contains(data))list.Add(data);
		}
		public static bool IsFullfill(IReadOnlyCollection<Item> requirement,IEnumerable<Item> table){
			var number=0;
			foreach(var request in requirement){
				foreach(var offering in table){
					var yes=false;
					yes=offering.Data==request.Data 
					&& offering.Count>=request.Count
					;
					if(!yes)continue;
					var adjNumber=0;
					foreach(var requestAdj in request.Adjectives){
						foreach(var offeringAdj in offering.Adjectives ){
							if(requestAdj.Data==offeringAdj.Data
							|| offeringAdj.Value>requestAdj.Value
							)adjNumber++;
						}
					}
					yes=adjNumber>=request.Adjectives.Length;
					if(!yes)continue;
					number++;
				}
			}
			return number>=requirement.Count ;
		}
	}
}
