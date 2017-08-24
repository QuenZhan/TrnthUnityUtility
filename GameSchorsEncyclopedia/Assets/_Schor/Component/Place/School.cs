using System.Collections;
using System.Collections.Generic;
using TRNTH.SchorsInventory.DeadDatabase;
using TRNTH.SchorsInventory.UI;
using TRNTH.SchorsInventory.UI.Component;
using UnityEngine;
namespace TRNTH.SchorsInventory.Component{
	public class School : Facility {
		// [SerializeField]SchoolLab _ToLab;
		// [SerializeField]SchoolLibrary _ToLibrary;
		[SerializeField]Conversation _Lesson;
		[SerializeField]Exchange _exchangePage;

        protected override IItemData Item0 {get{return _Lesson;}}

        protected override IItemData Item1 {get{return null;}}

        protected override IItemData Item2 {get{return null;}}

        protected override IItemData Item3 {get{return null;}}
    }

}

