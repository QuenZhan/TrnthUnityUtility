using System;
using System.Collections;
using System.Collections.Generic;
using TRNTH.Pooling;
using UnityEngine;
using UnityEngine.UI;
namespace TRNTH.SchorsInventory.UI.Component{
	public class Facility : MonoBehaviour
	,IUIContainer<IFacilityOption,FacilityOption>
	 {
		[SerializeField]Text _name;
		[SerializeField]Text _Description;
		[SerializeField] SchorsInventory.Component.Place Place;
		[SerializeField]Transform _Parent;

		[SerializeField]List<FacilityOption> _optionCells;
		public void Refresh(SchorsInventory.Component.Place place){
			gameObject.SetActive(true);
			this.Place=place;
			_name.text=place.Name;
			_Description.text=place.Description;
			_CellToData.Clear();
			Utility.UIContainerRefresh(this);
		}
		public void Select(FacilityOption cell){
			var data=_CellToData[cell];
		}
		readonly Dictionary<FacilityOption,IFacilityOption> _CellToData=new Dictionary<FacilityOption, IFacilityOption>(); 
        void IUIContainer<IFacilityOption, FacilityOption>.UpdateCell(int index, IFacilityOption data, FacilityOption cell)
        {
			_CellToData.Add(cell,data);
			cell.gameObject.SetActive(data!=null);
			cell.Container=this;
			if(data!=null){
				cell.Name.text=data.Name;
			}
        }
		[ContextMenu("Prespawn")]void Prespawn(){
			U.PreSpawn(_Parent,_optionCells);
		}

        IReadOnlyList<IFacilityOption> IUIContainer<IFacilityOption, FacilityOption>.Datas {get{return Place.Options;}}

        IReadOnlyList<FacilityOption> IUIContainer<IFacilityOption, FacilityOption>.Cells{get{return _optionCells;}}


        // [System.Serializable]class Pool:Pooling.Pool<FacilityOption>{}

    }

}
