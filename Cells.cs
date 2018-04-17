using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.Components
{
    public interface ICellsManager
	{
		void CellDown(int index);
        void CellHover(int index);
    }
	public sealed class Cells : MonoBehaviour {
		 public void Init(ICellsManager manager){
            var length=_cells.Count;
            for (int i = 0; i < length; i++)
            {
                _cells[i].Index=i;
                _cells[i].Manager=manager;
            }
        }
		public void GetCells<T>(MutableNonAllocList<T> list) where T:MonoBehaviour{
			var length=_cells.Count;
			list.Clear();
			for (int i = 0; i < length; i++)
			{
				var cell=_cells[i].GetComponent<T>();
				if(cell==null)continue;
				list.Add(cell);
			}
		}
		public void GetCells<T>(IList<T> list) where T:MonoBehaviour{
			var length=_cells.Count;
			list.Clear();
			for (int i = 0; i < length; i++)
			{
				var cell=_cells[i].GetComponent<T>();
				if(cell==null)continue;
				list.Add(cell);
			}
		}
		[SerializeField]Cell _cellPrefab;
		[SerializeField]Transform _parent;
		[ContextMenu("RegenerateCells")]
		void RegenerateCells(){
			#if UNITY_EDITOR
			if(!_parent)_parent=transform;
			var parent=_parent;
			var length=_cells.Count;
			for (int i = 0; i < length; i++)
			{
				if(_cells[i])DestroyImmediate(_cells[i].gameObject);
				var newCell= UnityEditor.PrefabUtility.InstantiatePrefab(_cellPrefab) as Cell;
				newCell.transform.SetParent(parent);
				newCell.transform.Freeze();
				_cells[i]=newCell;
			}
			var gridSnap=GetComponent<GridSnap>();
			if(gridSnap)gridSnap.Layout();
			#endif
		}
		[SerializeField]List<Cell> _cells=new List<Cell>();
	}

}
