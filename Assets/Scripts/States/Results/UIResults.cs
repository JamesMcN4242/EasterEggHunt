////////////////////////////////////////////////////////////
/////   UIResults.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;
using TMPro;

public class UIResults : UIStateBase
{
    [SerializeField] private TextMeshProUGUI m_timeText = null;
    [SerializeField] private TextMeshProUGUI m_investigatedText = null;

    public void SetAreasInvestigatedText(int investigated)
    {
        m_investigatedText.text = $"Searched {investigated} areas to find all the eggs";
    }

    public void SetTimeText(int minutes, int seconds)
    {
        string time = string.Empty;
        if(minutes > 0)
        {
            time += $"{minutes}m ";
        }
        time += $"{seconds}s";
        m_timeText.text = $"Found all eggs in {time}";
    }
}
