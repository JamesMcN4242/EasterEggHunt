////////////////////////////////////////////////////////////
/////   FSMenu.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;

public class FSMenu : FSStateBase
{
    private const string k_startGameMsg = "StartGame";

    protected override bool AquireUIFromScene()
    {
        m_ui = GameObject.FindObjectOfType<UIMenu>();
        return m_ui != null;
    }

    public override void HandleMessage(string message)
    {
        switch(message)
        {
            case k_startGameMsg:
                GlobalDirector.StateController.PushState(new FSGame());
                break;
        }
    }
}