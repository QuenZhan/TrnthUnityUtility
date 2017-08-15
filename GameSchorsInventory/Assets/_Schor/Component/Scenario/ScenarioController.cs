using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.SchorsInventory{
	public interface IScenarioController{
		void AfterMainthreadStart();
		void End(DeadDatabase.Scenario scenario);
		void ChangePlace(Component.Place place);
		void SelectPlace(Component.Place place);
	}
}
namespace TRNTH.SchorsInventory.Component{
public class ScenarioController:MonoBehaviour  {
	public virtual void Update(){

	}	
}

}
