using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The Node.
/// </summary>
public class Vertex : MonoBehaviour
{

    /// <summary>
    /// The connections (neighbors).
    /// </summary>
    [SerializeField]
    protected List<Vertex> m_Connections = new List<Vertex>();

    /// <summary>
    /// Gets the connections (neighbors).
    /// </summary>
    /// <value>The connections.</value>
    public virtual List<Vertex> connections
    {
        get
        {
            return m_Connections;
        }
    }

    public Vertex this[int index]
    {
        get
        {
            return m_Connections[index];
        }
    }

}
