using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.Components{
	public class Cells : MonoBehaviour {
		public void GetCells<T>(MutableNonAllocList<T> list) where T:MonoBehaviour{
			var length=_cells.Count;
			list.Clear();
			for (int i = 0; i < length; i++)
			{
				var cell=_cells[i] as T;
				if(cell==null)continue;
				list.Add(cell);
			}
		}
		[SerializeField]MonoBehaviour _cellPrefab;
		[SerializeField]Transform _parent;
		[ContextMenu("RegenerateCells")]
		void RegenerateCells(){
			#if UNITY_EDITOR
			var parent=_parent;
			var length=_cells.Count;
			for (int i = 0; i < length; i++)
			{
				if(_cells[i])DestroyImmediate(_cells[i].gameObject);
				var newCell= UnityEditor.PrefabUtility.InstantiatePrefab(_cellPrefab) as MonoBehaviour;
				newCell.transform.SetParent(parent);
				newCell.transform.Freeze();
				_cells[i]=newCell;
			}
			var gridSnap=GetComponent<GridSnap>();
			if(gridSnap)gridSnap.Layout();
			#endif
		}
		[SerializeField]List<MonoBehaviour> _cells=new List<MonoBehaviour>();
	}

}
