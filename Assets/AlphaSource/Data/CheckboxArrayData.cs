using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityEditor;

[CreateAssetMenu(fileName = "CheckboxArrayData", menuName = "ScriptableObjects/CheckboxArrayData", order = 1)]
public class CheckboxArrayData : SerializedScriptableObject
{
    [System.Serializable]
    public struct CheckboxState
    {
        [ToggleLeft]
        public bool isChecked;
    }

    [TableMatrix(DrawElementMethod = "DrawElement", HorizontalTitle = "Columns", VerticalTitle = "Rows")]
    public CheckboxState[,] checkboxStates = new CheckboxState[7, 7];

    private static CheckboxState DrawElement(Rect rect, CheckboxState value)
    {
        EditorGUI.BeginChangeCheck();

        value.isChecked = EditorGUI.ToggleLeft(rect, "", value.isChecked);

        if (EditorGUI.EndChangeCheck())
        {
            // Если значение изменилось, выполните необходимые действия.
        }

        return value;
    }

    public Vector2Int[] GetCheckedCheckboxCoordinates()
    {
        int checkedCount = 0;
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (checkboxStates[i, j].isChecked)
                {
                    checkedCount++;
                }
            }
        }

        Vector2Int[] coordinates = new Vector2Int[checkedCount];
        int currentIndex = 0;

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (checkboxStates[i, j].isChecked)
                {
                    coordinates[currentIndex] = new Vector2Int(i, j);
                    currentIndex++;
                }
            }
        }

        return coordinates;
    }
}