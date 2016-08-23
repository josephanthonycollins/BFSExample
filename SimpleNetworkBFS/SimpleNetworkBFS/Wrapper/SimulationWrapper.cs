using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleNetworkBFS.Structures;
using SimpleNetworkBFS.Data;
using SimpleNetworkBFS.Algorithms;

namespace SimpleNetworkBFS.Wrapper
{
    //Class used to run the simulations i.e. given the parsed data set, generate the relevant Matrix/Graph and run the simulation
    public class SimulationWrapper
    {
        private ParseData data;

        public ParseData Data
        {
            get { return data; }
            set { data = value; }
        }

        public SimulationWrapper(ParseData dataObject)
        {
            this.Data = dataObject;
        }

        public int RunSimulation()
        {
            if (Data.UniqueListOfNodes.Count == null || Data.UniqueListOfNodes.Count < 2)
            {
                Console.WriteLine("\n\nTrivial or non-existent graph, exiting.");
                return 0;
            }

            //Get the user to enter the starting and destination node
            int startNode = getUserToEnterNode(1);
            int destinationNode = getUserToEnterNode(2);

            if (startNode == destinationNode)
            {
                Console.WriteLine("\n\nTrivial case, i.e. distance from node to itself is 0, exiting.");
                return 0;
            }

            Console.WriteLine("\n\nRunning simulation.");

            //Generate and populate the GraphAdjList object
            GraphAdjList graph = new GraphAdjList(Data.UniqueListOfNodes.Count());
            for (int i = 0; i < Data.IndexI.Count; i++)
            {
                graph.AddEdge(Data.IndexI[i], Data.IndexJ[i]);
            }

            BreadthFirstSearch bfs = new BreadthFirstSearch(graph, startNode,destinationNode);

            if(bfs.distTo[destinationNode]!=-1)
                Console.WriteLine("\n\nNode {0} and Node {1} linked after {2} steps. Exiting.", startNode, destinationNode,bfs.distTo[destinationNode]);
            else
                Console.WriteLine("\n\nNode {0} and Node {1} are not linked. Exiting.", startNode, destinationNode);

            return 1;
        }


        public int getUserToEnterNode(int selection)
        {
            string str = "";
            int node = 0;
            Console.Write("\nTo choose node {0}, enter an integer between 0 and {1}:", selection, Data.UniqueListOfNodes.Count - 1);
            str = Console.ReadLine();
            bool val = int.TryParse(str, out node);
            while (!val)
            {
                Console.Write("\nInvalid Input. Please enter an integer between 0 and {1}: ", 0, Data.UniqueListOfNodes.Count - 1);
                str = Console.ReadLine();
                val = int.TryParse(str, out node);
            }
            return node;
        }

    }
}
