using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    //Variables
    public enum Status { SUCCESS, RUNNING, FAILURE };
    public Status status;
    public List<Node> children = new List<Node>();
    public int currentChild = 0;
    public string name;

    //Constructors
    public Node() { }

    public Node(string n){
        name = n;
    }

    public virtual Status Process()
    {
        return Status.SUCCESS;
    }

    //Method to add child to the Node
    public void AddChild(Node n){
        children.Add(n);
    }
}
