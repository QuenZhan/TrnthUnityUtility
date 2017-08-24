using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TRNTH.SchorsInventory.UI{
	
	public interface IItemSelector{
		void Select(IItemData item);
	}
	
}
namespace TRNTH.SchorsInventory.UI.Component{
	public class OptionList : MonoBehaviour {
		[SerializeField]Text _Title;
		[SerializeField]Image _Icon;
		[SerializeField]Text _Caption;
		[SerializeField]Text _Description;
		[SerializeField]Option[] _options;
		[SerializeField]Slider _slier;
		public void Refresh(IContainerData data){
			gameObject.SetActive(true);
			_Title.text=data.Title;
			_Icon.sprite=data.Icon;
			_Caption.text=data.Caption;
			_Description.text=data.Description;
			_slier.gameObject.SetActive(data.UsingSlider);
			_slier.value=data.SliderValue;
			_cellDataDictionary.Clear();
			var length=_options.Length;
			for (int i = 0; i < length; i++)
			{
				if(i>=data.Items.Count){
					_options[i].gameObject.SetActive(false);
					continue;
				}
				var itemData=data.Items[i];
				var cell=_options[i];
				_cellDataDictionary.Add(cell,itemData);
				cell.Container=this;
				cell.Refresh(itemData);
			}
		}
		readonly Dictionary<Option,IItemData> _cellDataDictionary=new Dictionary<Option, IItemData>();
		public IItemSelector Executeor;
		public void Select(Option cell){
			if(Executeor==null)return;
			IItemData data=null;
			_cellDataDictionary.TryGetValue(cell,out data);
			if(data==null)return;
			Executeor.Select(data);
		}
	}

}
