using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The Path.
/// </summary>
public class DijKstraPath
{

	/// <summary>
	/// The nodes.
	/// </summary>
	protected List<Vertex> m_Nodes = new List<Vertex> ();
	
	/// <summary>
	/// The length of the path.
	/// </summary>
	protected float m_Length = 0f;

	/// <summary>
	/// Gets the nodes.
	/// </summary>
	/// <value>The nodes.</value>
	public virtual List<Vertex> nodes
	{
		get
		{
			return m_Nodes;
		}
	}

	/// <summary>
	/// Gets the length of the path.
	/// </summary>
	/// <value>The length.</value>
	public virtual float length
	{
		get
		{
			return m_Length;
		}
	}

	/// <summary>
	/// Bake the path.
	/// Making the path ready for usage, Such as caculating the length.
	/// </summary>
	public virtual void Bake ()
	{
		List<Vertex> calculated = new List<Vertex> ();
		m_Length = 0f;
		for ( int i = 0; i < m_Nodes.Count; i++ )
		{
			Vertex node = m_Nodes [ i ];
			for ( int j = 0; j < node.connections.Count; j++ )
			{
				Vertex connection = node.connections [ j ];
				
				// Don't calcualte calculated nodes
				if ( m_Nodes.Contains ( connection ) && !calculated.Contains ( connection ) )
				{
					
					// Calculating the distance between a node and connection when they are both available in path nodes list
					m_Length += Vector3.Distance ( node.transform.position, connection.transform.position );
				}
			}
			calculated.Add ( node );
		}
	}

	/// <summary>
	/// Returns a string that represents the current object.
	/// </summary>
	/// <returns>A string that represents the current object.</returns>
	/// <filterpriority>2</filterpriority>
	public override string ToString ()
	{
		return string.Format (
			"Nodes: {0}\nLength: {1}",
			string.Join (
				", ",
				nodes.Select ( node => node.name ).ToArray () ),
			length );
	}
	
}
