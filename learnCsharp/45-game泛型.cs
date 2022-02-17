using System;
using MyNamespace.solver;

namespace MyNamespace
{
    namespace TwoEatOne
    {
        class Node : INode
        {
            public IMove[] GenerateMoves()
            {
                return new Move[] { };
            }
        }

        class Move : IMove
        {
        }

        class Game
        {
            AlphaBetaSolver<Node, Move> getSolver()
            {
                return new AlphaBetaSolver<Node, Move>();
            }
        }
    }

    namespace MammalChess
    {
        class Node
        {
            public Move[] GenerateMoves()
            {
                return new Move[] { };
            }
        }

        class Move
        {
        }
    }

    namespace solver
    {
        interface IMove
        {
        }

        interface INode
        {
            IMove[] GenerateMoves();
        }

        interface ISolver<Node, Move> where Node : INode where Move : IMove
        {
            IMove Solve(Node node);
        }

        class AlphaBetaSolver<Node, Move> : ISolver<Node, Move> where Node : INode where Move : IMove
        {
            public IMove Solve(Node node)
            {
                IMove[] a = node.GenerateMoves();
                return a[0];
            }
        }
    }
}