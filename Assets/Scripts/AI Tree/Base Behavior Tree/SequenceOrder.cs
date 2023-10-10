using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class SequenceOrder : Node
    {
        private List<Node> SucceedNode = new List<Node>();
        public SequenceOrder() : base() { } //Calling base class constructor in C#
        public SequenceOrder(List<Node> children) : base(children)
        {

        }
        public override NodeState Evalute()
        {
            bool anyChildIsRunning = false;
            foreach (Node child in children) //not in order
            {
                if(!SucceedNode.Contains(child))
                switch (child.Evalute())// call evalute of a child
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state; // break out the function at this time
                    case NodeState.SUCCESS:
                        SucceedNode.Add(child);
                        continue; // continue the other Ob action
                    case NodeState.RUNNING:
                        anyChildIsRunning = true;
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        state = NodeState.SUCCESS;
                        return state;

                }
            }
            state = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
                
            SucceedNode.Clear();
            return state;
        }
    }
}
