////////////////////////////////////////////////////////////
/////   FSResults.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;

public class FSResults : FSStateBase
{
    private const string k_menuMessage = "backToMenu";

    private UIResults m_resultUI = null;
    private float m_timeSearching;
    private int m_areasInvestigated;

    public FSResults(float timeSearching, int areasInvestigated)
    {
        m_timeSearching = timeSearching;
        m_areasInvestigated = areasInvestigated;
    }
    
    protected override bool AquireUIFromScene()
    {
        m_resultUI = GameObject.FindObjectOfType<UIResults>();
        m_ui = m_resultUI;
        return m_ui != null;
    }

    protected override void StartPresentingState()
    {
        int minutes = (int)m_timeSearching / 60;
        int seconds = (int)m_timeSearching % 60;
        m_resultUI.SetTimeText(minutes, seconds);
        m_resultUI.SetAreasInvestigatedText(m_areasInvestigated);
    }    

    public override void HandleMessage(string message)
    {
        if(message == k_menuMessage)
        {
            GlobalDirector.StateController.PopState(this);
        }
    }
}
