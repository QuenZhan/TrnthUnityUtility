using UnityEngine;
namespace TRNTH.Effects
{

    [System.Serializable]public class AfterImage:TrnthMonoBehaviour{
        [SerializeField]SpriteRenderer _SpriteRenderer;
        public void Play(SpriteRenderer rdr,Vector3 worldPosition,bool flipx){
            gobj.SetActive(true);
            tra.position=worldPosition;
            _SpriteRenderer.sprite=rdr.sprite;
            _SpriteRenderer.flipX=flipx;
        }
        public void End(){
            gobj.SetActive(false);
        }
    }
}
