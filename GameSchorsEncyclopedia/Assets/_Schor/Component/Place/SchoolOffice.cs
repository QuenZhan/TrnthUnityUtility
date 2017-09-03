using System;
using System.Collections;
using System.Collections.Generic;
using TRNTH.SchorsInventory.RuntimeDatabase;
using UnityEngine;
namespace TRNTH.SchorsInventory.Component
{
    public class SchoolOffice : Place {
		[SerializeField]Enrollment _Semester1Enrollment;
		[SerializeField]Certificate _Certificate;
		readonly HashSet<ISignature> _SemesterStudents=new HashSet<ISignature>();
		protected void Refresh(System.DateTime datatime,ISignature signature,IItemData[] _datas){
			if(datatime.Hour<9 || datatime.Hour>17 ){
				_datas[0]=null;
				return;
			}
			if(!_SemesterStudents.Contains(signature)){
				_datas[0]=_Semester1Enrollment;
			}
		}
	}
    class Certificate 
    {
        public string Title {get;set;}

        public DateTime BeginingDate {get;set;}

        public DateTime ExpiringDate {get;set;}

        public Place Place {get;set;}

        public ICollection<ISignature> Signatures {get;set;}

        public bool IsValid {get;set;}

		public readonly IList<Item> Requirement=new List<Item>();
        // IReadOnlyCollection<Item> IPromise.Requirement {get;}

        public string Name {get;set;}

        public string Description {get;set;}

        public TimeSpan CostTime {get;set;}
    }
    class Lesson:Event{
		// public void Participate(IInventory ){

		// }
	}
	class FirstLanguageLesson{
		IScenarioPlayer scenarioPlayer;
		ConversationBuilder conversationBuilder;
		FirstLessonConversation conversation;
		public void Learn(){
			conversationBuilder.Conversation=conversation;
			conversationBuilder.FirstLesson();
			scenarioPlayer.Play(conversation);
		}
        class Trial : ITrial
        {
			public IScenarioPlayer scenarioPlayer;
			public ConversationBuilder conversationBuilder;

            public IReadOnlyCollection<Item> Requirement { get; set;}

            public virtual void Fail(){}
            public virtual void Pass(){}
        }
        class FirstLessonConversation : Conversation,ITrialSet
        {
			IManager manager;
			Item[] TrailItemsBoPoMo;
			readonly List<ITrial> trials=new List<ITrial>();

            public int Count{get{return trials.Count;}}

            public ISignature Judge {get;set;}

            public override void End()
            {
				trials.Clear();
				trials.Add(new Trial{
					Requirement=new Item[]{TrailItemsBoPoMo[0]}
				});
				trials.Add(new Trial{
					Requirement=new Item[]{TrailItemsBoPoMo[1]}
				});
				trials.Add(new Trial{
					Requirement=new Item[]{TrailItemsBoPoMo[2]}
				});
				ITrialSet trial=this;
                manager.StartTial(trial);
            }

            public void Fail()
            {
                // EndTrial();
            }
			// Conversation conversation;
			void EndTrial(IManager manager,int score){
				// manager.ConversationBuilder.Conversation=conversation;
				if(score>2){
					manager.ConversationBuilder.FirstTrailPass();
				}else{
					manager.ConversationBuilder.FirstTrailFail();
				}
				manager.Play(manager.ConversationBuilder.Conversation);
			}

            public IEnumerator<ITrial> GetEnumerator()
            {
                return trials.GetEnumerator();
            }

            public void Pass()
            {
                // EndTrial();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                 return trials.GetEnumerator();
            }
        }
    }
	class Event:IEvent{
		public string Title {get{return Name;}}

        public DateTime BeginingDate {get;set;}

        public DateTime ExpiringDate {get;set;}

        public Place Place {get;set;}

		public readonly Item[] Requirement=new Item[4];

        public string Name {get;set;}

        public string Description {get;set;}

        public TimeSpan CostTime {get;set;}

        IReadOnlyCollection<Item> IEvent.Requirement {get{return Requirement;}}
    }
    class Enrollment :  IItemData,IAction,ITrader,IPriceable
    {
		public Event CompletmentExamination=new Event{
			Name="期末考"
			};
		// public Item LanguagePassCertificate;
		// public Item ForeingLanguageCertificate;
		// public Item HerbCertificate;
		public Item StudentIdentification;
		public Lesson[] Lessons=new Lesson[]{
			new Lesson{Name="本國語言"}
			,new Lesson{Name="算數"}
			,new Lesson{Name="藥草"}
		};
		Trader _trader;
		Sprite _sprite;
        public Sprite Icon{get{return _sprite;}}

        public string Name {get;private set;}="入學註冊";

        public string Description{get;private set;}="註冊購買這學期的入學證書";

        public string Caption{get;private set;}="交易";

        public TimeSpan CostTime {get{return new TimeSpan(0,2,0);}}

        public IPriceable ForSell {get{return this;}}

        public int Price {get{return 3533;}}


        public void Refresh(Place school){
			foreach(var e in Lessons){
				e.Requirement[0]=StudentIdentification;
				e.CostTime=new TimeSpan(2,0,0);
				e.Place=school;
			}
			// var requirement=this.CompletmentExamination.Requirement;
			// requirement.Add(LanguagePassCertificate);
			// requirement.Add(ForeingLanguageCertificate);
			// requirement.Add(HerbCertificate);
		}
        public void Trade(IInventory table,UserData _user,UI.Component.Console _console)
        {
            if(!_trader.Trade(ForSell,table,_console))return;
			_user.Schedule.Add(CompletmentExamination);
			foreach(var e in Lessons){
				_user.Schedule.Add(e);
			}
			_console.Add(Rigestered);
			table.Add(StudentIdentification);
        }

        // void ITrader.Trade(IInventory table)
        // {
        //     throw new NotImplementedException();
        // }

        const string Rigestered="已註冊成功，請明天開始來上課喔";
    }

}