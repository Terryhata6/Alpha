using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;

[CreateAssetMenu(fileName = "CheckboxArrayData", menuName = "ScriptableObjects/CheckboxArrayData", order = 1)]
public class CheckboxArrayData : SerializedScriptableObject
{
    public int Width;
    public int Height;

    [System.Serializable]
    public struct CheckboxState
    {
        [ToggleLeft]
        public bool isChecked;
    }

    [TableMatrix(DrawElementMethod = "DrawElement", HorizontalTitle = "Columns", VerticalTitle = "Rows")]
    public CheckboxState[,] checkboxStates;

    public CheckboxArrayData()
    {
        // Initialize checkboxStates in the constructor
        checkboxStates = new CheckboxState[Width, Height];
    }

    private static CheckboxState DrawElement(Rect rect, CheckboxState value)
    {
        EditorGUI.BeginChangeCheck();

        value.isChecked = EditorGUI.ToggleLeft(rect, "", value.isChecked);

        if (EditorGUI.EndChangeCheck())
        {
            // If the value has changed, perform the necessary actions.
        }

        return value;
    }

    public Vector2Int[] GetCheckedCheckboxCoordinates()
    {
        int checkedCount = 0;
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                if (checkboxStates[i, j].isChecked)
                {
                    checkedCount++;
                }
            }
        }

        Vector2Int[] coordinates = new Vector2Int[checkedCount];
        int currentIndex = 0;

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
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

    [Button("Update Table")]
    private void UpdateTable()
    {
        checkboxStates = new CheckboxState[Width, Height];
    }
}
