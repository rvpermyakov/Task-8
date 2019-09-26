using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph2 {
	class Program {
		//Проверка наличия цветов у вершин
		static bool AllNodesInColour(int[] colours) {
			for (int i = 0; i < colours.Length; i++)
				if (colours[i] == -1)
					return false;
			return true;
		}

		//Проверка соседей с идентичным цветом
		static bool NeighboursWithSameColour(int node, int colour, int[,] graph, int[] colours) {
			for (int i = 0; i < graph.GetLength(0); i++)
				if (graph[node, i] == 1 && colours[i] == colour)
					return true;

			return false;
		}

		static void Paint(int[,] graph, int[] colours) {
			int colour = 1;
			while (!AllNodesInColour(colours)) {
				for (int i = 0; i < colours.Length; i++) {
					if (colours[i] == -1 && !NeighboursWithSameColour(i, colour, graph, colours))
						colours[i] = colour;
				}
				colour++;
			}
		}

		static void Main(string[] args) {
			Console.Write("N = ");
			int n = int.Parse(Console.ReadLine());
			int[,] graphMatrix = new int[n,n]; //Граф представлен в виде матрицы смежности

			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++) {
					Console.Write("[{0}][{1}] = ", i, j);
					graphMatrix[i, j] = int.Parse(Console.ReadLine());
				}
			}

			int[] nodes = new int[n];
			for (int i = 0; i < n; i++)
				nodes[i] = -1;

			Paint(graphMatrix, nodes);

			Console.WriteLine();
			for (int i = 0; i < nodes.Length; i++)
				Console.WriteLine("[{0}] = {1}", i, nodes[i]);

			Console.ReadKey();
		}
	}
}
