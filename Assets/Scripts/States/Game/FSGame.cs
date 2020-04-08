////////////////////////////////////////////////////////////
/////   FSGame.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections.Generic;

public class FSGame : FSStateBase
{
    private UIGame m_gameUI = null;
    private GridData m_gridData = null;
    private GameSettings m_gameSettings = null;
    private List<string> m_eggSpots = null;
    private List<string> m_spotsSearched = null;
    private float m_timeFinding = 0.0f;
    private int m_eggsFound = 0;
    private bool m_readyToPop = false;

    protected override bool AquireUIFromScene()
    {
        m_gameUI = GameObject.FindObjectOfType<UIGame>();
        m_ui = m_gameUI;
        return m_ui != null;
    }

    protected override void StartPresentingState()
    {
        m_spotsSearched = new List<string>();
        m_gridData = Resources.Load<GridData>("GridData");
        m_gameSettings = Resources.Load<GameSettings>("GameSettings");
        m_gameUI.SetUpGrid(m_gridData);

        m_gameUI.SetTimeTaken(0, 0);
        m_gameUI.SetEggText(0, m_gameSettings.m_eggsToFind);
        HideEggs();
    }

    protected override void UpdateActiveState()
    {
        if(m_readyToPop)
        {
            GlobalDirector.StateController.PopState(this);
        }

        m_timeFinding += Time.deltaTime;
        int minutes = (int)m_timeFinding / 60;
        int seconds = (int)m_timeFinding % 60;
        m_gameUI.SetTimeTaken(minutes, seconds);
    }

    public override void HandleMessage(string message)
    {
        if(!m_spotsSearched.Contains(message))
        {
            m_spotsSearched.Add(message);
            GridElement gridElement = m_gameUI.gameObject.GetComponentFromChild<GridElement>(message);
            bool eggFound = m_eggSpots.Contains(message);
            gridElement.SetFound(eggFound);

            if(eggFound)
            {
                m_eggsFound++;
                m_gameUI.SetEggText(m_eggsFound, m_gameSettings.m_eggsToFind);
                m_eggSpots.Remove(message);        
                if(m_eggsFound >= m_gameSettings.m_eggsToFind)
                {
                    m_readyToPop = true;
                    FSResults results = new FSResults(m_timeFinding, m_spotsSearched.Count);
                    GlobalDirector.StateController.PushState(results);
                }    
            }     
        }   
    }

    private void HideEggs()
    {
        m_eggSpots = new List<string>(m_gameSettings.m_eggsToFind);
        while(m_eggSpots.Count < m_gameSettings.m_eggsToFind)
        {
            int columns = Random.Range(0, m_gridData.m_columns);
            int row = Random.Range(0, m_gridData.m_rows);
            string message = string.Format(m_gridData.m_buttonFormat, columns, row);
            if(!m_eggSpots.Contains(message))
            {
                m_eggSpots.Add(message);
            }
        }
    }
}
