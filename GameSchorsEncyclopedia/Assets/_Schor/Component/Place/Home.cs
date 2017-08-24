using System.Collections;
using System.Collections.Generic;
using TRNTH.SchorsInventory.DeadDatabase;
using TRNTH.SchorsInventory.UI;
using UnityEngine;
namespace TRNTH.SchorsInventory.Component{
    public class Home : Facility
    {
		// 看鏡子 , 儲物櫃，對話
		[SerializeField]Conversation _Dad;
		[SerializeField]Conversation _Mon;
		[SerializeField]Conversation _Mirror;
		[SerializeField]Conversation _Closet;

        protected override IItemData Item0 {get{return _Dad;}}

        protected override IItemData Item1 {get{return _Mon;}}

        protected override IItemData Item2 {get{return _Mirror;}}

        protected override IItemData Item3 {get{return _Closet;}}
    }

}

