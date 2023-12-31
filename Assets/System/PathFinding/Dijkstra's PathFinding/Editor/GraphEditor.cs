﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CustomEditor ( typeof ( DijKstraGraph ) )]
public class GraphEditor : Editor
{
	
	protected DijKstraGraph m_Graph;
	protected Vertex m_From;
	protected Vertex m_To;
	protected Follower m_Follower;
	protected DijKstraPath m_Path = new DijKstraPath ();

	void OnEnable ()
	{
		m_Graph = target as DijKstraGraph;
	}

	void OnSceneGUI ()
	{
		if ( m_Graph == null )
		{
			return;
		}
		for ( int i = 0; i < m_Graph.nodes.Count; i++ )
		{
			Vertex node = m_Graph.nodes [ i ];
			for ( int j = 0; j < node.connections.Count; j++ )
			{
				Vertex connection = node.connections [ j ];
				if ( connection == null )
				{
					continue;
				}
				float distance = Vector3.Distance ( node.transform.position, connection.transform.position );
				Vector3 diff = connection.transform.position - node.transform.position;
				Handles.Label ( node.transform.position + ( diff / 2 ), distance.ToString (), EditorStyles.whiteBoldLabel );
				if ( m_Path.nodes.Contains ( node ) && m_Path.nodes.Contains ( connection ) )
				{
					Color color = Handles.color;
					Handles.color = Color.green;
					Handles.DrawLine ( node.transform.position, connection.transform.position );
					Handles.color = color;
				}
				else
				{
					Handles.DrawLine ( node.transform.position, connection.transform.position );
				}
			}
		}
	}

	public override void OnInspectorGUI ()
	{
		m_Graph.nodes.Clear ();
		/*foreach ( Transform child in m_Graph.transform )
		{
			Vertex node = child.GetComponent<Vertex> ();
			if ( node != null )
			{
				m_Graph.nodes.Add ( node );
			}
		}
		*/
		foreach (Vertex child in FindObjectsOfType<Vertex>())
		{

			if (child != null)
			{
				m_Graph.nodes.Add(child);
			}
		}
		base.OnInspectorGUI ();
		EditorGUILayout.Separator ();
		m_From = ( Vertex )EditorGUILayout.ObjectField ( "From", m_From, typeof ( Vertex ), true );
		m_To = ( Vertex )EditorGUILayout.ObjectField ( "To", m_To, typeof ( Vertex ), true );
		m_Follower = ( Follower )EditorGUILayout.ObjectField ( "Follower", m_Follower, typeof ( Follower ), true );
		if ( GUILayout.Button ( "Show Shortest Path" ) )
		{
			m_Path = m_Graph.GetShortestPath ( m_From, m_To );
			if ( m_Follower != null )
			{
				m_Follower.Follow ( m_Path );
			}
			Debug.Log ( m_Path );
			SceneView.RepaintAll ();
		}
		// ND part from now	
		if (GUILayout.Button("Create Vertex"))
        {
			GameObject newOb = new GameObject("Vertex");
			newOb.transform.parent = m_Graph.transform;
			var newVertex = newOb.AddComponent<Vertex>();
			m_Graph.nodes.Add(newVertex);

        }

	}
	
}
