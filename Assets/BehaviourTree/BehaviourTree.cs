using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : Node             // Behaviour Tree inherits from Node
{

    // Behaviour Tree Constructor
    public BehaviourTree(){
        name = "Tree";                        // Name of this class "Tree"
    }

    // Constructor with one parameter
    public BehaviourTree(string n){            // Any name the BehaviourTree Node has
        name = n;
    }

    public override Status Process()
    {
        return children[currentChild].Process();
    }
    
    struct NodeLevel 
    {
        public int Level;
        public Node node;
    }

    // Method to print the Tree Nodes
    public void PrintTree()
    {
        // Can solve this using recursion or without recursion. This solution is without recursion
        
        string treePrintout = "";                                   // emptry string
        Stack<NodeLevel> nodeStack = new Stack<NodeLevel>();           // new stack of Nodes
        Node currentNode = this;                                        // This is the currentNode
        nodeStack.Push(new NodeLevel { Level = 0, node = currentNode } );         // Push - Add this currentNode to the stack

        while (nodeStack.Count != 0){                                // while stack not empty do the following

            NodeLevel nextNode = nodeStack.Pop();                    // nextNode will remove one Node from the stack top
            treePrintout += new string ('-', nextNode.Level) + nextNode.node.name + "\n";
            for (int i = nextNode.node.children.Count - 1; i >= 0; i--)          // Decrement from the bottom node (stack top)
            {
                nodeStack.Push( new NodeLevel { Level = nextNode.Level + 1, node = nextNode.node.children[i] });
            }
        }
        Debug.Log(treePrintout);    // output to the console
    }
}
