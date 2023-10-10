using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviorTree
{   
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    public class Node
    {
        protected NodeState state;

        public Node parent;
        protected List<Node> children = new List<Node>();

        private Dictionary<string, object> dataContext = new Dictionary<string, object>();

        public Node() { parent = null; }

        public Node(List<Node> children)
        {   
            foreach(Node child in children)
            {
                //check every node added in and make it child
                Attach(child);
            }
        }

        private void Attach(Node node)
        {   
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evalute() => NodeState.FAILURE; //return failure in defualt

        public void SetData(string key, object value)
        {
            dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            if (dataContext.TryGetValue(key, out value))
                return value;

            Node node = parent;
            
            //check somewhere in the branch not in single note
            while (node != null)
            {
                value = node.GetData(key);
                if (value != null)
                    return value;
                node = node.parent;
            }
            return null;
        }
        public bool ClearData(string key)
        {
            
            if (dataContext.ContainsKey(key))
            {
                dataContext.Remove(key);
                return true;

            }

            Node node = parent;

            while (node != null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                    return true;
                node = node.parent;
            }
            return false;
        }
    }
}
