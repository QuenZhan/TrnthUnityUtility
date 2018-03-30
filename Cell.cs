using UnityEngine;
using UnityEngine.EventSystems;
namespace TRNTH.Components
{
    public class Cell:MonoBehaviour,IPointerDownHandler,IPointerUpHandler{
		public int Index;
		public ICellsManager Manager;
        public void OnPointerDown(PointerEventData eventData)
        {
            if(Manager==null)throw new System.ArgumentNullException("Manager is requied, please assign first");
            Manager.CellDown(Index);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            // throw new System.NotImplementedException();
        }
    }

}
