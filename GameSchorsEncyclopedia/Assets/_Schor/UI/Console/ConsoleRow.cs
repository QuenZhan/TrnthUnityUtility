using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TRNTH.SchorsInventory.UI.Component{

    public class ConsoleRow : MonoBehaviour
    , IListCell
    {
        int IListCell.Index {get;set;}
        public Text[] Contents;
        [SerializeField]Animator _animator;
        const string Show="Show";
        public void PlayAnimation(){
            _animator.Play(Show);
        }
    }
}
