using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
// [RequireComponent(typeof(Button))]
public class TrnthUIClickOff : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler {
    public void OnPointerClick(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
		gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    // void Start () {
	// 	GetComponent<Button>().onClick.AddListener(()=>{gameObject.SetActive(false);});
	// }
}
