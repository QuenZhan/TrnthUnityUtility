using System.Collections.Generic;
using UnityEngine;

namespace TRNTH.SchorsInventory.Component
{
    [System.Serializable]public class TransportOptions : IContainerData
    {
        public IList<Transport> Datas{
            get{
                return _Datas;
            }				
        }
        readonly List<Transport> _Datas=new List<Transport>();
        public Place Destinartion;
        string IContainerData.Title {
            get{
                return Goto;
            }
        }
        const string Goto="前往…";

        string IContainerData.Caption {get{return Destinartion.Name;}}

        Sprite IContainerData.Icon {get{return Destinartion.Icon;}}

        string IContainerData.Description{get{return string.Empty;}}

        bool IContainerData.UsingSlider {get{return false;}}

        float IContainerData.SliderValue {get{return 0;}}

        IReadOnlyList<IItemData> IContainerData.Items{
            get{
                return _Datas;
            }
        }
        // public UI ExchangePage;
        public void Select(IItemData item)
        {
            Transport transport=(Transport)item;
            // ExchangePage.Refresh(transport);
            // throw new System.NotImplementedException();
        }
    }
}
