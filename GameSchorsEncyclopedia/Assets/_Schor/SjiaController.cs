using System;
using System.Collections;
using System.Collections.Generic;
using TRNTH.SchorsInventory.DeadDatabase;
using TRNTH.SchorsInventory.RuntimeDatabase;
using TRNTH.SchorsInventory.UI.Component;
using UnityEngine;
namespace TRNTH.SchorsInventory{
	public interface IManager{
		SjiaData UserData{get;}
		IScenarioController ScenarioController {get;}
	}
	public interface IContainerData{
		string Title{get;}
		string Caption{get;}
		Sprite Icon{get;}
		string Description{get;}
		bool UsingSlider{get;}
		float SliderValue{get;}
		IReadOnlyList<IItemData> Items{get;}
	}
	public interface IItemData	{
		Sprite Icon{get;}
		string Name{get;}
		string Description{get;}
		string Caption{get;}
	}
	public interface IAction{
		string Name{get;}
		string Description{get;}
		System.TimeSpan CostTime{get;}
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
		// IPriceable Priceable{get;}
	}
	public interface IInventory:IList<Item>{
		int Capacity{get;}
	}
	public interface ITrader{
		IReadOnlyList<IPriceable> ForSell{get;}
		void Trade(int index,IInventory table);
	}
	public class Trader:ITrader{
		IInventory stock;
		Item[] _tempStock=new Item[Item.MaxAdjectivesCount];

        public IReadOnlyList<IPriceable> ForSell {get{return null;}}

        public void Trade(IPriceable target,IInventory table){
			var price=0;
			foreach(var e in table){
				var currency=(IPriceable)e;
				price+=currency.Price*e.Count;
			}
			price-=target.Price;
			if(price<0)throw new System.InvalidOperationException();
			if(price==0)return;
			table.Clear();
			if(target is Item){
				var item=(Item)target;
				table.Add(item);
				stock.Remove(item);
			}
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
		}
        void ITrader.Trade(int index, IInventory table)
        {
			Trade(ForSell[index],table);
            // throw new NotImplementedException();
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
    class PersonBasic : IPerson
    {
		const string ExamplerPerson="ExamplePerson";
        public string Name {get{return ExamplerPerson;}}
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
	public interface IPromise:IAction{
		string Title{get;}
		System.DateTime BeginingDate{get;}
		System.DateTime ExpiringDate{get;}
		Component.Place Place{get;}
		ICollection<ISignature> Signatures{get;}
		bool IsValid{get;}
		IReadOnlyCollection<Item> Requirement{get;}
	}
}
namespace TRNTH.SchorsInventory.Component{
	public class SjiaController : MonoBehaviour
	,IManager
	,IScenarioPlayer {
		[SerializeField]Status _status; 
		[SerializeField]GameObject[] _ExchangeToReset;
		static public IManager Instance{get;private set;}
		public OptionList OptionListPage;
		public Exchange ExchangePage;

        public SjiaData UserData {get{return _UserData;}}
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
		// public void Move(ITransport transport,ITrader driver,IInventory cashierTable){
		// 	driver.Trade(driver,cashierTable);
		// }
		public void Move(ITransport transport){
			Act(transport);
			var user=UserData;
			user.Place=transport.Destination;
			_evenSystem.SetSelectedGameObject(user.Place.gameObject,_baseEvent);
			OptionListPage.Refresh(user.Place);
			_status.Refresh(UserData);
		}
		public void Talk(Conversation scenario){
			Act(scenario);
			_Scenario=scenario;
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
			var number=0;
			foreach(var request in promise.Requirement){
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
			Act(promise);
			var okay=number>=promise.Requirement.Count 
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
		/// 國語文件撰寫＝紙＋墨水 in 有書桌的地方
		/// 產物可能形容詞＝素材的形容詞，相同位置相同形容詞，效果會疊加，不相同的會隨機挑一個
		public void Craft(IRecipe recipe,IInventory table){
			Act(recipe);
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
					_tmpHidden.Clear();
					var reciepeAttributeData=recipe.Adjectives[i];
					TryAdd(_tmpAdjectives,reciepeAttributeData,e.AvailibleAdjectives);
					_tmpHidden.Add(true);
					foreach(var ingredient in _tempStock){
						if(ingredient==null)continue;
						var adj=ingredient.Adjectives[i];
						if(adj==null)continue;
						TryAdd(_tmpAdjectives,adj.Data,e.AvailibleAdjectives);
						_tmpHidden.Add(adj.Hidden);
					}
					if(_tmpAdjectives.Count<1)continue;
					var newAdj=new Adjectives(){
						Data=_tmpAdjectives.RandomChooseNonAlloc()
						,Value=(byte)_tmpAdjectives.Count
						,Hidden=_tmpHidden.RandomChooseNonAlloc()
						};
					newItem.Adjectives[i]=newAdj;
				}
				table.Add(newItem);
			}
		}
		
		void TryAdd(IList<AttributeData> list, AttributeData data,IReadonlyHashSet<AttributeData> filter){
			if(filter.Contains(data))list.Add(data);
		}
		readonly List<AttributeData> _tmpAdjectives=new List<AttributeData>(Item.MaxAdjectivesCount);
		readonly List<bool> _tmpHidden=new List<bool>(Item.MaxAdjectivesCount);
		// readonly HashSet<ItemData> _requirement=new HashSet<ItemData>();
		// readonly HashSet<ItemData> _ingredient=new HashSet<ItemData>();
		[SerializeField]UnityEngine.EventSystems.EventSystem _evenSystem;
        [SerializeField]UnityEngine.EventSystems.BaseEventData _baseEvent;

        IScenarioController IManager.ScenarioController {get{return _scenarioController;}}

        [SerializeField]SjiaData _UserData;
		public DeadDatabase.Conversation _Scenario;
		[SerializeField]BeforeLeaving _scenarioController;
		[SerializeField]UI.Component.Console _Console;
		[SerializeField]UI.Component.Dialogue _dialouge;
		[SerializeField]Place _startPlace;
		public void ScenarioNext(){
			if(_Scenario==null){
				_Scenario=_scenarioController.Choose();
			}
			if(_Scenario==null || _UserData.Memories.Contains(_Scenario)){
				_Scenario=null;
				return;
			}
			if(Index>=_Scenario.Dialogues.Count){
				_UserData.Memories.Add(_Scenario);
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
		IEnumerator Start()
		{
			Instance=this;
			if(UserData.Place==null)UserData.Place=this._startPlace;
			yield return null;
			_scenarioController.AfterMainthreadStart();
			_status.Refresh(UserData);
		}
		

        void IScenarioPlayer.Play(Conversation scenario)
        {
            _Scenario=scenario;
			ScenarioNext();
        }

        int Index;
	}

}
