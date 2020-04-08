////////////////////////////////////////////////////////////
/////   FSMenu.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;
using TMPro;

public class UIGame : UIStateBase
{
    [SerializeField] private TextMeshProUGUI m_centreText = null;
    [SerializeField] private Grid m_grid = null;

    public void SetMessage(string message)
    {
        m_centreText.text = message;
    }

    public void SetUpGrid(GridData data)
    {
        m_grid.SetUpGridDate(data);
        m_grid.SetUpGrid();
    }
}
