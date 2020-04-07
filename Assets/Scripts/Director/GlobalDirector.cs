////////////////////////////////////////////////////////////
/////   UtilityToolbar.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using System.Collections.Generic;
using UnityEngine;

public class GlobalDirector : MonoBehaviour
{
    private StateController m_stateController = null;
    public static GlobalDirector Instance {get; private set;}
    public static StateController StateController
    {
        get => Instance.m_stateController;
    }

    [RuntimeInitializeOnLoadMethod()]
    private static void OnProjectStart()
    {
        if(Instance == null)
        {
            GameObject go = new GameObject("GlobalDirector");
            Instance = go.AddComponent<GlobalDirector>();
        }
    }

    public static void HandleMessage(string message)
    {
        StateController.HandleMessage(message);
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        m_stateController = new StateController();
        m_stateController.PushState(new FSMenu());
    }

    void Update()
    {
        m_stateController.UpdateStack();
    }
}
