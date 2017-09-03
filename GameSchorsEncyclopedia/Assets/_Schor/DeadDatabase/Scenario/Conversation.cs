using System;
using System.Collections;
using System.Collections.Generic;
using TRNTH.SchorsInventory.UI;
using UnityEngine;
namespace TRNTH.SchorsInventory.DeadDatabase{
	[CreateAssetMenu]public class Conversation : ScriptableObject
	// , IItemData
	,IExchange
	{
		[SerializeField]string _Title;
		[SerializeField]Dialogue[] _Dialogues;
		public IReadOnlyList<Dialogue> Dialogues{get{return _Dialogues;}}
		[SerializeField]Sprite _icon;
        // Sprite IItemData.Icon {get{return _icon;}}

        public string Name {get{return _Title;}}

        public string Description{get{return _Dialogues[0].Content;}}

        // string IItemData.Caption {get{return _Dialogues[0].Character.Name;}}

        string IExchange.Title {get{return _Title;}}

		// [SerializeField]byte _CostMiniutes=5;
        IReadOnlyCollection<IIngredient> IExchange.Ingredients {get{
			var ing=UI.Ingredient.CostTimeOnly[0];
			ing.Count=(byte)_Dialogues.Length;
			ing.Unit=Unit;
			return UI.Ingredient.CostTimeOnly;
		}}
		const string Unit="分鐘";
        IReadOnlyCollection<IIngredient> IExchange.Results {get{return UI.Ingredient.Empty;}}


        TimeSpan IAction.CostTime {get{throw new NotImplementedException();}}

        // string IAction.Name => throw new NotImplementedException();

        // string IAction.Description => throw new NotImplementedException();

        // void IExchangePage.Execute()
        // {
        //     throw new System.NotImplementedException();
        // }
    }
	public enum Emotion{
		None,Annoying,Boring,Doubt,LookAside,Weird,Serious,Pride
		,Lazy,Nervous,Patient,Painfull,Speachless,
        BitterSmile,
        Smile,
        Noticed,Contempt,
        Humiliated,
        Heavy,
        Scared,
        Carefull,
        Umm,
        NervousSmile,
        Angry,
        Irritable,
        Surprised,
        Excited,
        Embarrassed,
        Thinking,
        Regretful,
        Chuckle,
        AwakeScared,
        YesYesYes,
        ActingCute,
        Happy,
        Reading,
    }
	[System.Serializable]public struct Dialogue{
		[Multiline]public string Content;
		public Character Character;
		public Emotion Emotion;
		public Dialogue(string content,Character character,Emotion emotion=Emotion.None){
			this.Content=content;
			this.Character=character;
			this.Emotion=emotion;
		}
	}
}