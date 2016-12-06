using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SpawnEnemyClass))]
public class EnemySpawner : PropertyDrawer
{

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		label = EditorGUI.BeginProperty(position, label, property);
		Rect contentPosition = EditorGUI.PrefixLabel(position, label);
		if (position.height > 16f)
		{
			position.height = 16f;
			EditorGUI.indentLevel += 1;
			contentPosition = EditorGUI.IndentedRect(position);
			contentPosition.y += 18f;
		}
		contentPosition.width *= 0.5f;
		EditorGUI.indentLevel = 0;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("enemy"), GUIContent.none);
		contentPosition.x += contentPosition.width;
		contentPosition.width /= 1.5f;
		EditorGUIUtility.labelWidth = 40f;

		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("time"));
		EditorGUI.EndProperty();
	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
		return Screen.width < 333 ? (16f + 18f) : 16f;
	}
}
