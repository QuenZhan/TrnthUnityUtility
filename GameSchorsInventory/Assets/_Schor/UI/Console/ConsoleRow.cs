using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.SchorsInventory.UI.Component{

    public class ConsoleRow : MonoBehaviour, IListCell
    {
        int IListCell.Index {get;set;}
    }
}
