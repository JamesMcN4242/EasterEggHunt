////////////////////////////////////////////////////////////
/////   UIGame.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;
using TMPro;

public class UIGame : UIStateBase
{
    [SerializeField] private GridUI m_grid = null;
    [SerializeField] private TextMeshProUGUI m_eggText = null;
    [SerializeField] private TextMeshProUGUI m_timerText = null;

    public void SetUpGrid(GridData data)
    {
        m_grid.SetUpGridDate(data);
        m_grid.SetUpGrid();
    }

    public void SetEggText(int eggsFound, int totalEggs)
    {
        m_eggText.text = $"{eggsFound}/{totalEggs}";
    }

    public void SetTimeTaken(int minutes, int seconds)
    {
        string time = string.Empty;
        if(minutes > 0)
        {
            time += $"{minutes}m ";
        }
        time += $"{seconds}s";
        m_timerText.text = time;
    }
}
