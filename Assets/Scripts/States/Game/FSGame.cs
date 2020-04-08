////////////////////////////////////////////////////////////
/////   FSGame.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;

public class FSGame : FSStateBase
{

    private const float k_timeBetweenStates = 3.0f;

    private UIGame m_gameUI = null;
    private GridData m_gridData = null;
    private float m_timeBetweenStates = k_timeBetweenStates;

    protected override bool AquireUIFromScene()
    {
        m_gameUI = GameObject.FindObjectOfType<UIGame>();
        m_ui = m_gameUI;
        return m_ui != null;
    }

    protected override void StartPresentingState()
    {
        m_gridData = Resources.Load<GridData>("GridData");
        m_gameUI.SetUpGrid(m_gridData);
        m_gameUI.SetMessage("Imagine if there was a game here!");
    }

    protected override void UpdatePresentingState()
    {
        m_timeBetweenStates -= Time.deltaTime;
        if(m_timeBetweenStates <= 0.0f)
        {
            m_timeBetweenStates = k_timeBetweenStates;
            EndPresentingState();
        }
    }

    protected override void StartActiveState()
    {
        m_gameUI.SetMessage("I mean obviously there isn't a game here");
    }

    protected override void UpdateActiveState()
    {
        m_timeBetweenStates -= Time.deltaTime;
        if(m_timeBetweenStates <= 0.0f)
        {
            m_timeBetweenStates = k_timeBetweenStates;
            GlobalDirector.StateController.PopState(this);
        }
    }

    protected override void StartDismissingState()
    {
        m_gameUI.SetMessage("But like, could you imagine if there was!?");
    }

    protected override void UpdateDismissingState()
    {        
        m_timeBetweenStates -= Time.deltaTime;
        if(m_timeBetweenStates <= 0.0f)
        {
            EndDismissingState();
        }
    }

    public override void HandleMessage(string message)
    {
        Debug.Log(message);
    }
}
