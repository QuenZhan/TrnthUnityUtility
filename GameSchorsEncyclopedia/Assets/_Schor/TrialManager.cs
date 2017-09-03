using System.Collections.Generic;
namespace TRNTH.SchorsInventory
{
    class TrialManager
    {
		Utility _utility=new Utility();
		ITrialSet trialset;
		ITrial trial{get{return enumerator.Current;}}
		UI.Component.Console _console;
		public void StartTial(ITrialSet trialset){
			_console.Add(trialset.Judge.Name,MsgStartTrial);
			this.trialset=trialset;
			enumerator=trialset.GetEnumerator();
			enumerator.MoveNext();
			PassScoreThreshold=trialset.Count*6/10;
			Refresh();
		}
		const string MsgStartTrial="向你發出了挑戰。";
		IEnumerator<ITrial> enumerator;
		void Refresh(){
			_console.Add(MsgRequirementTitle);
			foreach(var e in trial.Requirement){
				_console.Add(e.Data.Name,Utility.IntToStringNonAllocUnder1000(e.Count));
			}
			_console.Add(MsgEndOfRequirement);
		}
		const string MsgComplete="考驗結束，顯示結果";
		const string MsgPass="通過！";
		const string MsgFail="失敗！";
		const string MsgSlash="/";
		const string MsgEndOfRequirement="以上。";
		// const 
		void ShowResult(){
			_console.Add(MsgComplete);
			_console.Add(Utility.IntToStringNonAllocUnder1000(score),MsgSlash,Utility.IntToStringNonAllocUnder1000(PassScoreThreshold));
			_console.Add(score>PassScoreThreshold?MsgPass:MsgFail);
		}
		int PassScoreThreshold;
		int score;
        const string MsgRequirementTitle="去吧！考題！請提供下列指定物品：";
		IInventory table;
		// IInventory _craftingTable;
		const string MsgSubmitAnswer="思嘉使用了交出考卷";
        public void Answer(){
			_console.Add(MsgSubmitAnswer);
			var pass=Utility.IsFullfill(trial.Requirement,table);
			if(pass){
				trial.Pass();
				score++;
			}
			else trial.Fail();
			if(enumerator.MoveNext()){
				Refresh();
				return;
			}
			pass=score>PassScoreThreshold;
			if(pass){
				trialset.Pass();
			}
			else{
				trialset.Fail();
			}
			ShowResult();
		}
		public IRecipe Recipe;
		public void Craft(){
			_utility.Craft(Recipe,table);
		}
	}
}
