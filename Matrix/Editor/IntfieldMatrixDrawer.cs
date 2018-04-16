using UnityEditor;
using UnityEngine;

namespace TRNTH{

	[CustomPropertyDrawer(typeof(IntFieledMatrix))]
	public class IngredientDrawer : PropertyDrawer
	{
		// Draw the property inside the given rect
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			// Using BeginProperty / EndProperty on the parent property means that
			// prefab override logic works on the entire property.
			EditorGUI.BeginProperty(position, label, property);

			// Draw label
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			// Don't make child fields be indented
			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			var _intProperty=property.FindPropertyRelative("_ints");
			var width=property.FindPropertyRelative("_width").intValue;
			var length=_intProperty.arraySize;
			var cellSize=30;
			for (int i = 0; i < length; i++)
			{
				var x=i%cellSize;
				var y=i/cellSize;
				var rect = new Rect(position.x+x, position.y+y, cellSize, cellSize);
				EditorGUI.PropertyField(rect, _intProperty.GetArrayElementAtIndex(i), GUIContent.none);
			}

			// Calculate rects
			var amountRect = new Rect(position.x, position.y, 30, position.height);
			var unitRect = new Rect(position.x + 35, position.y, 50, position.height);
			var nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

			// Draw fields - passs GUIContent.none to each so they are drawn without labels
			EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("amount"), GUIContent.none);
			EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("unit"), GUIContent.none);
			EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);

			// Set indent back to what it was
			EditorGUI.indentLevel = indent;

			EditorGUI.EndProperty();
		}
	}
}
// IngredientDrawer