using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    // // Suppose we have some input data describing a graph of relationships between parents and children over multiple generations. The data is formatted as a list of (parent, child) pairs, where each individual is assigned a unique integer identifier.
    // 
    // // For example, in this diagram, 3 is a child of 1 and 2, and 5 is a child of 4:
    // 
    // // 1   2    4
    // //  \ /   / | \
    // //   3   5  8  9
    // //    \ / \     \
    // //     6   7    11
    // 
    // // Sample input/output (pseudodata):
    // 
    // // parentChildPairs = [
    // //     (1, 3), (2, 3), (3, 6), (5, 6),
    // //     (5, 7), (4, 5), (4, 8), (4, 9), (9, 11)
    // // ]
    // 
    // // Write a function that takes this data as input and returns two collections: one containing all individuals with zero known parents, and one containing all individuals with exactly one known parent.
    // 
    // // Output may be in any order:
    // 
    // // findNodesWithZeroAndOneParents(parentChildPairs) => [
    // //   [1, 2, 4],       // Individuals with zero parents
    // //   [5, 7, 8, 9, 11] // Individuals with exactly one parent
    // // ]
    // 
    // 
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SolutionINodesWithZeroAndOneParent
    {
        static void Main(string[] args)
        {
            SolutionINodesWithZeroAndOneParent.ParentChildPairs();
        }
        public static void ParentChildPairs()
        {
            var parentChildPairs = new List<int[]>() {
            new int[]{1, 3},
            new int[]{2, 3},
            new int[]{3, 6},
            new int[]{5, 6},
            new int[]{5, 7},
            new int[]{4, 5},
            new int[]{4, 8},
            new int[]{4, 9},
            new int[]{9, 11}
            };

            Tuple <List<int> , List<int> > result = findNodesWithZeroAndOneParents(parentChildPairs);
            string temp = string.Join(",", result.Item1);
            Console.WriteLine(temp);
            temp = string.Join(",", result.Item2);
            Console.WriteLine(temp);
        }

        protected static Tuple<List<int>, List<int>> findNodesWithZeroAndOneParents(List<int[]> parentChildPairs)
        {

            HashSet<int> singleParent = new HashSet<int>();
            HashSet<int> zeroParent = new HashSet<int>();
            foreach (var pc in parentChildPairs)
            {
                bool bfoundZeroParent = false;
                foreach (var pc1 in parentChildPairs)
                {
                    if (!(pc == pc1) && pc[0] == pc1[1])
                    {
                        bfoundZeroParent = true;
                        break;
                    }
                }

                if (!bfoundZeroParent)
                {
                    zeroParent.Add(pc[0]);
                }

                if (!singleParent.Contains(pc[1]))
                {
                    singleParent.Add(pc[1]);
                }
                else
                {
                    singleParent.Remove(pc[1]);
                }
            }
            return new Tuple<List<int>, List<int>>(zeroParent.ToList<int>(), singleParent.ToList<int>() );
        }
    }
}
