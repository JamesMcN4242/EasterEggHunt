////////////////////////////////////////////////////////////
/////   FSMenu.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;
using TMPro;

public class UIGame : UIStateBase
{
    [SerializeField] private TextMeshProUGUI m_centreText = null;

    public void SetMessage(string message)
    {
        m_centreText.text = message;
    }
}
