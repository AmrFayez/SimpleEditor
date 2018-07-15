using System;

public class TreeNode<TItem>
{
   

    public TItem Value { get; set; }
    public int Key { get; set; }
    public TreeNode<TItem> Left { get; set; }
    public TreeNode<TItem> Right { get; set; }
    public TreeNode(int key, TItem value)
    {
        Value = value;
        Key = key;
    }

}
public class Tree<TItem>
{
    public TreeNode<TItem> root;//this is public so we can access this treenode from main when we display our tree using the recursive function

    public Tree()
    {
        root = null;
    }
    public void Insert(TreeNode<TItem> newNode)
    {
        //our new node to insert into the tree
        if (root == null)//if theres no root, make the first new node the root
        {
            root = newNode;
        }
        else
        {
            TreeNode<TItem> current = root;//we make a new treenode called current and assign to the root, so we start iteration from there

            TreeNode<TItem> parent = null;
            while (current != null)//while the current is not equal to null (since we have it equal to root)
            {
                parent = current;//set the parent node to point to current (which the root treenode, which will be the parent to the new item treenode)

                if (newNode.Key < current.Key)
                //if new item (Key) is less than the current node's Key, link it to the left node
                {
                    current = current.Left;
                    if (current == null)//if the current.left is null
                    {
                        parent.Left = newNode;//make parent.left store the new node
                    }
                }
                else
                {
                    current = current.Right;
                    if (current == null)
                    {
                        parent.Right = newNode;
                    }
                }
            }
        }
    }
    public void InOrderRecursiveTreeDisplay(TreeNode<TItem> root)
    {
        if (root != null)
        {
            InOrderRecursiveTreeDisplay(root.Left);

            InOrderRecursiveTreeDisplay(root.Right);
        }
    }
    public bool RecursiveFindValue(TreeNode<TItem> root, int key)
    {
        if (root != null)
        {
            RecursiveFindValue(root.Left, key);
            RecursiveFindValue(root.Right, key);
            if (root.Key == key)
            {

                return true;
            }
        }
        return false;
    }
    private TreeNode<TItem> GoToTarget(int target)//method will return target node
    {
        TreeNode<TItem> c = root;
        TreeNode<TItem> returnThis = null;
        while (c != null)
        {
            if (target < c.Key)
            {
                c = c.Left;
            }
            if (target == c.Key)
            {
                returnThis = c;
                break;
            }
            if (target > c.Key)
            {
                c = c.Right;
            }
        }
        return returnThis;
    }
    private TreeNode<TItem> ParentOfTarget(TreeNode<TItem> target)
    {
        //this method will return the parent node of the target node
        TreeNode<TItem> current = root;
        TreeNode<TItem> parent = null;
        while (current != null)
        {
            if (current.Left == target || current.Right == target)
            {
                parent = current;
                break;
            }
            if (target.Key < current.Key && current.Left != target)
            {
                current = current.Left;
            }
            if (target.Key > current.Key && current.Right != target)
            {
                current = current.Right;
            }
        }
        return parent;
    }
    public bool find(int target)
    {
        if (root != null && regular_find(target) != false)
        {
            return true;
        }
        else
        { return false; }
    }
    private bool regular_find(int target)
    {
        bool isFound = false;
        TreeNode<TItem> current = root;
        while (current != null && isFound == false)
        {
            if (current.Key == target)
            {
                isFound = true;
            }
            if (target < current.Key)
            {
                if (current.Left == null)
                {
                    break;
                }
                else
                {
                    current = current.Left;
                }
            }
            if (target > current.Key)
            {
                if (current.Right == null)
                {
                    break;
                }
                else
                {
                    current = current.Right;
                }
            }
        }
        if (isFound == true)
        {

            return true;
        }
        else
        {

            return false;
        }
    }

    public TreeNode<TItem> Search(int target)
    {
        bool isFound = false;
        TreeNode<TItem> current = root;
        while (current != null && isFound == false)
        {
            if (current.Key == target)
            {
                isFound = true;
                return current;
            }
            if (target < current.Key)
            {
                if (current.Left == null)
                {
                    break;
                }
                else
                {
                    current = current.Left;
                }
            }
            if (target > current.Key)
            {
                if (current.Right == null)
                {
                    break;
                }
                else
                {
                    current = current.Right;
                }
            }
        }
        if (isFound == true)
        {

            return current;
        }
        else
        {

            return null;
        }

    }


    public void Remove(int target)
    {
        if (root == null || find(target) == false)//before we can remove, check to see if it exists
        {

            return;
        }
        else
        {
            //Private Remove method called here
            return;
        }
    }
    private int Private_Remove(int target)//private remove method does all work, returns the integer value removed
    {
        int temp;
        TreeNode<TItem> targetNode = GoToTarget(target);
        //case 1, removing the root
        if (targetNode == root)
        {
            if (targetNode.Left == null && targetNode.Right == null)
            {
                temp = root.Key;
                root = null;
                return temp;
            }
            if (targetNode.Left != null)
            {
                //replace top with left if a left-right node dne, else go far right as possible
                //delete left
                TreeNode<TItem> current = root.Left;

                temp = root.Key;
                if (root.Left.Right == null)//if theres no right child of the left child...
                { root.Key = root.Left.Key; }
                else //if there is, we go left and then far right until...
                {
                    while (current != null)
                    { //we replace the root node with 2nd highest value
                        if (current.Right.Right == null)
                        { root.Key = current.Right.Key; break; }
                        current = current.Right;
                    }
                    if (current.Right != null) { current.Right = current.Right.Right; }//works
                    else { current.Right = null; }
                    return temp;
                }

                if (root.Left.Left == null)
                {
                    root.Left = null;
                }
                else { root.Left = root.Left.Left; }
                return temp;
            }
            if (targetNode.Right != null)
            {
                temp = root.Key;
                root.Key = root.Right.Key;
                if (root.Right.Right == null)
                {
                    root.Right = null;
                }
                else { root.Right = root.Right.Right; }
                return temp;
            }
        }

        //case 2 , removing nonroot
        if (targetNode.Left == null && targetNode.Right == null)
        {//target has no children
            if (ParentOfTarget(targetNode).Left == targetNode)
            {
                temp = targetNode.Key;
                ParentOfTarget(targetNode).Left = null;
            }
            else
            {
                temp = targetNode.Key;
                ParentOfTarget(targetNode).Right = null;
            }
            return temp;
        }
        //target has 1 child
        if (targetNode.Left != null && targetNode.Right == null)
        {
            temp = targetNode.Key;
            ParentOfTarget(targetNode).Right = targetNode.Left;
            //ParentOfTarget(targetNode).left = targetNode.left;//HERE
            return temp;

        }
        if (targetNode.Right != null && targetNode.Left == null)
        {
            temp = targetNode.Key;
            //here if parent is the root, make it left = target->right
            if (ParentOfTarget(targetNode) == root)
            {
                ParentOfTarget(targetNode).Left = targetNode.Right;
            }
            else
                ParentOfTarget(targetNode).Right = targetNode.Right;

            return temp;

        }
        //target node has 2 children
        if (targetNode.Left != null && targetNode.Right != null)
        {
            if (ParentOfTarget(targetNode).Left == targetNode)
            {
                //take child.left and replace target
                temp = targetNode.Key;
                targetNode.Key = targetNode.Left.Key;
                targetNode.Left = null;
                return temp;
            }
            else
            {
                temp = targetNode.Key;
                targetNode.Key = targetNode.Left.Key;
                //check if left->left not null...
                if (targetNode.Left.Left != null)
                {
                    targetNode.Left = targetNode.Left.Left;
                }
                else
                    targetNode.Left = null;
                return temp;
            }

        }
        return Int32.MinValue;
    }
}