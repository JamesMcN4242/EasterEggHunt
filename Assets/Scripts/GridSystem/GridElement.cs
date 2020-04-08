////////////////////////////////////////////////////////////
/////   GridElement.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;

public class GridElement : MonoBehaviour
{
    [SerializeField] private GameObject m_notFound = null;
    [SerializeField] private GameObject m_found = null;

    private bool m_hasBeenSet = false;
    public void SetFound(bool eggFoundHere)
    {
        if(!m_hasBeenSet)
        {
            m_found.SetActive(eggFoundHere);
            m_notFound.SetActive(!eggFoundHere);
            m_hasBeenSet = true;
        }
    }
}
