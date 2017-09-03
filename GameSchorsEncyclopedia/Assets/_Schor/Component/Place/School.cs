using System.Collections;
using System.Collections.Generic;
using TRNTH.SchorsInventory.DeadDatabase;
using TRNTH.SchorsInventory.UI;
using TRNTH.SchorsInventory.UI.Component;
using UnityEngine;
namespace TRNTH.SchorsInventory.Component{
	public class School : Place {
		[SerializeField]Transport _ToLab;
		[SerializeField]Conversation _Lesson;
        [SerializeField]Transport _Office;
        [SerializeField]Transport _ToLibrary;

        protected override void BeforeItems(IItemData[] _datas){
            // _datas[0]=_Lesson;
            _datas[1]=_Office;
            _datas[2]=_ToLibrary;
            _datas[3]=_ToLab;
        }
    }

}

