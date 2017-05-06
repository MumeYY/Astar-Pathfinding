﻿//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class SebGrid : MonoBehaviour {
//    private static SebGrid s_Instance = null;
//    public static SebGrid instance
//    {
//        get
//        {
//            if (s_Instance == null)
//            {
//                s_Instance = FindObjectOfType(typeof(SebGrid))
//                as SebGrid;
//                if (s_Instance == null)
//                    Debug.Log("Could not locate a GridManager " +
//                    "object. \n You have to have exactly " +
//                    "one GridManager in the scene.");
//            }
//            return s_Instance;
//        }
//    }
//    public LayerMask unwalkableMask;
//	public Vector2 gridWorldSize;
//	public float nodeRadius;
//	Node[,] grid;

//	float nodeDiameter;
//	int gridSizeX, gridSizeZ;


//	void Awake() {
//		nodeDiameter = nodeRadius*2;
//		gridSizeX = Mathf.RoundToInt(gridWorldSize.x/nodeDiameter);
//		gridSizeZ = Mathf.RoundToInt(gridWorldSize.y/nodeDiameter);
//		CreateGrid();
//	}

//	void CreateGrid() {
//		grid = new Node[gridSizeX,gridSizeZ];
//		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.up * gridWorldSize.y/2;

//		for (int x = 0; x < gridSizeX; x ++) {
//			for (int z = 0; z < gridSizeZ; z ++) {
//				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (z * nodeDiameter + nodeRadius);
//				bool walkable = !(Physics.CheckSphere(worldPoint,nodeRadius,unwalkableMask));
//				grid[x,z] = new Node(walkable,worldPoint, x,z);
//			}
//		}
//	}

//	public List<Node> GetNeighbours(Node node) {
//		List<Node> neighbours = new List<Node>();

//		for (int x = -1; x <= 1; x++) {
//			for (int z = -1; z <= 1; z++) {
//				if (x == 0 && z == 0)
//					continue;

//				int checkX = node.gridX + x;
//				int checkZ = node.gridY + z;

//				if (checkX >= 0 && checkX < gridSizeX && checkZ >= 0 && checkZ < gridSizeZ) {
//					neighbours.Add(grid[checkX,checkZ]);
//				}
//			}
//		}

//		return neighbours;
//	}
	

//	public Node NodeFromWorldPoint(Vector3 worldPosition) {
//		float percentX = (worldPosition.x + gridWorldSize.x/2) / gridWorldSize.x;
//		float percentZ = (worldPosition.y + gridWorldSize.y/2) / gridWorldSize.y;
//		percentX = Mathf.Clamp01(percentX);
//		percentZ = Mathf.Clamp01(percentZ);

//		int x = Mathf.RoundToInt((gridSizeX-1) * percentX);
//		int z = Mathf.RoundToInt((gridSizeZ-1) * percentZ);
//		return grid[x,z];
//	}

//	public List<Node> path;
//	//void OnDrawGizmos() {
//	//	Gizmos.DrawWireCube(transform.position,new Vector3(gridWorldSize.x, gridWorldSize.y,1));

//	//	if (grid != null) {
//	//		foreach (SebNode n in grid) {
//	//			Gizmos.color = (n.walkable)?Color.white:Color.red;
//	//			if (path != null)
//	//				if (path.Contains(n))
//	//					Gizmos.color = Color.black;
//	//			Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-.1f));
//	//		}
//	//	}
// //       for (int i = 0; i < SebPathfinding.openList.Count; i++)
// //       {
// //           Gizmos.DrawCube(SebPathfinding.openList[i].worldPosition, Vector3.one * (nodeDiameter - .1f));

// //       }
// //       Gizmos.color = Color.red;
// //       for (int i = 0; i < SebPathfinding.closedList.Count; i++)
// //       {
// //           Gizmos.DrawCube(SebPathfinding.closedList[i].worldPosition, Vector3.one * (nodeDiameter - .1f) * 0.3f);
// //       }
// //   }
//}