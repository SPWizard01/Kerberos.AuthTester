using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LipingShare.LCLib.Asn1Processor
{
	public class Asn1TreeNode : TreeNode
	{
		private Asn1Node asn1Node = new Asn1Node();

		public Asn1Node ANode => asn1Node;

		private Asn1TreeNode()
		{
		}

		public Asn1TreeNode(Asn1Node node, uint mask)
		{
			asn1Node = node;
			base.Text = node.GetLabel(mask);
		}

		public static void AddSubNode(Asn1TreeNode node, uint mask, TreeView treeView)
		{
			for (int i = 0; i < node.ANode.ChildNodeCount; i++)
			{
				Asn1TreeNode asn1TreeNode = new Asn1TreeNode();
				asn1TreeNode.asn1Node = node.ANode.GetChildNode(i);
				asn1TreeNode.Text = asn1TreeNode.ANode.GetLabel(mask);
				node.Nodes.Add(asn1TreeNode);
				node.Expand();
				if (treeView != null)
				{
					treeView.SelectedNode = node;
				}
				AddSubNode(asn1TreeNode, mask, treeView);
			}
		}

		public static TreeNode SearchTreeNode(TreeNode treeNode, Asn1Node node)
		{
			TreeNode treeNode2 = null;
			if (node == null)
			{
				return treeNode2;
			}
			if (((Asn1TreeNode)treeNode).ANode == node)
			{
				return treeNode;
			}
			for (int i = 0; i < treeNode.Nodes.Count; i++)
			{
				Asn1Node aNode = ((Asn1TreeNode)treeNode.Nodes[i]).ANode;
				if (aNode == node)
				{
					treeNode2 = treeNode.Nodes[i];
					break;
				}
				treeNode2 = SearchTreeNode(treeNode.Nodes[i], node);
				if (treeNode2 != null)
				{
					break;
				}
			}
			return treeNode2;
		}
	}
}
