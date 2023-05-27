using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] MazeNode nodePrefab;
    [SerializeField] Vector2Int mazeSize;
    [SerializeField] GameObject player;
    [SerializeField] GameObject coins;
    [SerializeField] int maxCoin;

    List<MazeNode> nodes = new List<MazeNode>();
    private void Start()
    {
        GenerateMazeInstant(mazeSize);
        InitializePlayer();
        InitializeCoins();
    }

    void GenerateMazeInstant(Vector2Int size)
    {
        //create Node
        for(int x = 0; x < size.x ; x++)
        {
            for (int y = 0; y < size.y ; y++)
            {
                Vector3 nodePos = new Vector3(x - (size.x / 2f), 0 ,  y - (size.y / 2f));
                MazeNode newNode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                nodes.Add(newNode);
                
            }
        }
        
        
        List<MazeNode> completedNodes = new List<MazeNode>();
        List<MazeNode> currentPath = new List<MazeNode>();

        //Choose starting nodes
        currentPath.Add(nodes[Random.Range(0,nodes.Count)]);
        

        while (completedNodes.Count < nodes.Count)
        {
            //Check nodes next to the current node
            List<int> possibleNextNodes = new List<int>();
            List<int> possibleDirection = new List<int>();

            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;

            if(currentNodeX < size.x - 1 ){
                //Check right node
                if(!completedNodes.Contains(nodes[currentNodeIndex + size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + size.y]))
                    {
                        possibleDirection.Add(1);
                        possibleNextNodes.Add(currentNodeIndex + size.y);   
                    }

            }

            if(currentNodeX > 0)
            {
                //Check left node
                if(!completedNodes.Contains(nodes[currentNodeIndex - size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - size.y]))
                    {
                        possibleDirection.Add(2);
                        possibleNextNodes.Add(currentNodeIndex - size.y);   
                    }

            }

            if(currentNodeY < size.y - 1)
            {
                //Check up / above node
                if(!completedNodes.Contains(nodes[currentNodeIndex + 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + 1]))
                    {
                        possibleDirection.Add(3);
                        possibleNextNodes.Add(currentNodeIndex + 1);   
                    }

            }

            if(currentNodeY > 0)
            {
                //Check down / below node
                if(!completedNodes.Contains(nodes[currentNodeIndex - 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - 1]))
                    {
                        possibleDirection.Add(4);
                        possibleNextNodes.Add(currentNodeIndex - 1);   
                    }

            }

            //Choose next node
            if(possibleDirection.Count > 0)
            {
                int chosenDirection = Random.Range(0, possibleDirection.Count);
                MazeNode chosenNode = nodes[possibleNextNodes[chosenDirection]];

                switch (possibleDirection[chosenDirection])
                {
                    case 1:
                    chosenNode.RemoveWall(1);
                    currentPath[currentPath.Count - 1].RemoveWall(0);
                    break;
                    case 2:
                    chosenNode.RemoveWall(0);
                    currentPath[currentPath.Count - 1].RemoveWall(1);
                    break;
                    case 3:
                    chosenNode.RemoveWall(3);
                    currentPath[currentPath.Count - 1].RemoveWall(2);
                    break;
                    case 4:
                    chosenNode.RemoveWall(2);
                    currentPath[currentPath.Count - 1].RemoveWall(3);
                    break;
                }
                currentPath.Add(chosenNode);
                
            }else
            {
                completedNodes.Add(currentPath[currentPath.Count - 1]);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }

    private void InitializePlayer()
    {
        //Vector3 posY = new Vector3 (0,-0.335f,0); , posY, Quaternion.identity
        transform.localPosition = new Vector3(0, 0.335f , 0);
        Instantiate(player, nodes[0].transform.localPosition , Quaternion.identity);
    }

    
    private void InitializeCoins()
    {
        for (int i = 1; i < maxCoin; i++)
        {
            //Vector3 posY = new Vector3 (0,-0.335f,0); , posY, Quaternion.identity
            //transform.position = new Vector3(0, 1, 0);
            Instantiate(coins, nodes[i].transform.position , Quaternion.identity);
        }
    }

    IEnumerator GenerateMaze(Vector2Int size)
    {
        List<MazeNode> nodes = new List<MazeNode>();

        //create Node
        for(int x = 0; x < size.x ; x++)
        {
            for (int y = 0; y < size.y ; y++)
            {
                Vector3 nodePos = new Vector3(x - (size.x / 2f), 0 ,  y - (size.y / 2f));
                MazeNode newNode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                nodes.Add(newNode);

                yield return null;
            }
        }

        List<MazeNode> currentPath = new List<MazeNode>();
        List<MazeNode> completedNodes = new List<MazeNode>();


        //Choose starting nodes
        currentPath.Add(nodes[Random.Range(0,nodes.Count)]);
        currentPath[0].SetState(NodeState.Current);

        while (completedNodes.Count < nodes.Count)
        {
            //Check nodes next to the current node
            List<int> possibleNextNodes = new List<int>();
            List<int> possibleDirection = new List<int>();

            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;

            if(currentNodeX < size.x - 1 ){
                //Check right node
                if(!completedNodes.Contains(nodes[currentNodeIndex + size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + size.y]))
                    {
                        possibleDirection.Add(1);
                        possibleNextNodes.Add(currentNodeIndex + size.y);   
                    }

            }

            if(currentNodeX > 0)
            {
                //Check left node
                if(!completedNodes.Contains(nodes[currentNodeIndex - size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - size.y]))
                    {
                        possibleDirection.Add(2);
                        possibleNextNodes.Add(currentNodeIndex - size.y);   
                    }

            }

            if(currentNodeY < size.y - 1)
            {
                //Check up / above node
                if(!completedNodes.Contains(nodes[currentNodeIndex + 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + 1]))
                    {
                        possibleDirection.Add(3);
                        possibleNextNodes.Add(currentNodeIndex + 1);   
                    }

            }

            if(currentNodeY > 0)
            {
                //Check down / below node
                if(!completedNodes.Contains(nodes[currentNodeIndex - 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - 1]))
                    {
                        possibleDirection.Add(4);
                        possibleNextNodes.Add(currentNodeIndex - 1);   
                    }

            }

            //Choose next node
            if(possibleDirection.Count > 0)
            {
                int chosenDirection = Random.Range(0, possibleDirection.Count);
                MazeNode chosenNode = nodes[possibleNextNodes[chosenDirection]];

                switch (possibleDirection[chosenDirection])
                {
                    case 1:
                    chosenNode.RemoveWall(1);
                    currentPath[currentPath.Count - 1].RemoveWall(0);
                    break;
                    case 2:
                    chosenNode.RemoveWall(0);
                    currentPath[currentPath.Count - 1].RemoveWall(1);
                    break;
                    case 3:
                    chosenNode.RemoveWall(3);
                    currentPath[currentPath.Count - 1].RemoveWall(2);
                    break;
                    case 4:
                    chosenNode.RemoveWall(2);
                    currentPath[currentPath.Count - 1].RemoveWall(3);
                    break;
                }

                currentPath.Add(chosenNode);
                chosenNode.SetState(NodeState.Current);
            }else
            {
                completedNodes.Add(currentPath[currentPath.Count - 1]);

                currentPath[currentPath.Count - 1].SetState(NodeState.Completed);
                currentPath.RemoveAt(currentPath.Count - 1);
            }

            yield return null;
        }
    } 
}
