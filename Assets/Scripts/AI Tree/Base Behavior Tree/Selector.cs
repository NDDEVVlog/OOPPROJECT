using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    /*Selector Nodes execute their children from left to right.
     * They stop executing when one of their children succeeds. 
     * If a Selector's child succeeds, the Selector succeeds. 
     * If all the Selector's children fail, the Selector fails.*/
    public class Selector : Node
    {
        public Selector() : base() { }
        public Selector(List<Node> children) : base(children)
        {

        }
        public override NodeState Evalute()
        {
            
            foreach (Node child in children)
            {
                switch (child.Evalute())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        continue;
                    default:
                        continue;

                }
            }
            state = NodeState.FAILURE;
            return state;

            //create a Selector then analyst this
        }


    }
}
