////////////////////////////////////////////////////////////
/////   FSGame.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;

public class FSGame : FSStateBase
{
    private UIGame m_gameUI = null;
    private GridData m_gridData = null;
    private float m_timeFinding = 0.0f;

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

        m_gameUI.SetTimeTaken(0, 0);
        m_gameUI.SetEggText(0, 10);
    }
    
    protected override void UpdateActiveState()
    {
        m_timeFinding += Time.deltaTime;
        int minutes = (int)m_timeFinding / 60;
        int seconds = (int)m_timeFinding % 60;
        m_gameUI.SetTimeTaken(minutes, seconds);
    }

    public override void HandleMessage(string message)
    {
        Debug.Log(message);
    }
}
