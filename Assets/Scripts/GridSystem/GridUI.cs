////////////////////////////////////////////////////////////
/////   GridUI.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;

public class GridUI : MonoBehaviour
{
    [SerializeField] 
    private GameObject m_gridElement = null;
    private int m_rows = 2;
    private int m_columns = 3;
    private string m_buttonMsgFormat = string.Empty;

    public void SetUpGridDate(GridData gridData)
    {
        m_columns = gridData.m_columns;
        m_rows = gridData.m_rows;
        m_buttonMsgFormat = gridData.m_buttonFormat;
    }

    public void SetUpGrid()
    {
        DeleteAllChildren();
        float yMin = 0.0f;
        float yOffset = 1.0f/m_rows;
        float xOffset = 1.0f/m_columns;

        for(int i = 0; i < m_rows; i++)
        {
            float xMin = 0.0f;
            for(int j = 0; j < m_columns; j++)
            {
                RectTransform rect = Object.Instantiate(m_gridElement, this.transform).GetComponent<RectTransform>();
                rect.anchorMin = new Vector2(xMin, yMin);
                rect.anchorMax = new Vector2(xMin + xOffset, yOffset + yMin);
                xMin += xOffset;

                if(!string.IsNullOrEmpty(m_buttonMsgFormat))
                {
                    string message = string.Format(m_buttonMsgFormat, j, i);
                    UIButtonInteraction interaction = rect.GetComponent<UIButtonInteraction>();
                    interaction.message = message;
                    interaction.name = message;
                }
            }
            yMin += yOffset;
        }
    }

    private void DeleteAllChildren()
    {
        for(int i = transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(transform.GetChild(i).gameObject);
        }
    }
}
