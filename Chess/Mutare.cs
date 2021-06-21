using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Mutare
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Value { get; set; }
        public int AttackValue { get; set; }
        public bool IsAttack { get; set; }
        public int KingPosition { get; set; }

        public Mutare()
        {
            To = 0;
            From = 0;
        }
        public Mutare(int from, int to)
        {
            this.From = from;
            this.To = to;
        }
        public Mutare(int from, int to, int value, bool attack)
        {
            this.From = from;
            this.To = to;
            this.Value = value;
            this.IsAttack = attack;
        }
        public bool IsValidMove(List<Mutare> validMoves)
        {
            foreach (Mutare m in validMoves)
            {
                if (m.To == this.To && m.From == this.From)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsCheckMove(List<Mutare> validMoves, int pos, int dest, MainGame m, CuloarePiesa playerculoare)
        {

            MakeMoveLight(pos, dest, m);

            List<Mutare> list2 = new List<Mutare>();


            if (CuloarePiesa.Alb == playerculoare)
            {
                list2 = m.GetToateMutarilePosibileBlack(m);
                string sfpartida = m.NumePiesaafisaj(m.DatePartidaCastig.NumePiesa, CuloarePiesa.Alb);
                // if white king position is same as black's destination position, 
                // this would result in check, return true
                for (int i = 0; i < m.DatePartidaCastig.NumarColoane * m.DatePartidaCastig.NumarRanduri; i++)
                {
                    if (String.Compare(m.pieceIdBoard[i].PieceName, sfpartida) == 0)
                    {
                        foreach (Mutare move2 in list2)
                        {
                            if (m.pieceIdBoard[i].PiecePosition == move2.To)
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            else
            {
                list2 = m.GetToateMutarilePosibileWhite(m);
                string sfpartida = m.NumePiesaafisaj(m.DatePartidaCastig.NumePiesa, CuloarePiesa.Negru);
                // if white king position is same as black's destination position, 
                // this would result in check, return true
                for (int i = 0; i < m.DatePartidaCastig.NumarColoane * m.DatePartidaCastig.NumarRanduri; i++)
                {
                    if (String.Compare(m.pieceIdBoard[i].PieceName, sfpartida) == 0)
                    {
                        foreach (Mutare move2 in list2)
                        {
                            if (m.pieceIdBoard[i].PiecePosition == move2.To)
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            return false;
        }
        public bool OpponentInCheck(List<Mutare> validMoves, int pos, int dest, MainGame m, CuloarePiesa playerculoare)
        {
            MakeMoveLight(pos, dest, m);

            List<Mutare> list2 = new List<Mutare>();


            if (CuloarePiesa.Alb != playerculoare)
            {
                list2 = m.GetToateMutarilePosibileBlack(m);
                string sfpartida = m.NumePiesaafisaj(m.DatePartidaCastig.NumePiesa, CuloarePiesa.Alb);
                // if white king position is same as black's destination position, 
                // this would result in check, return true
                for (int i = 0; i < m.DatePartidaCastig.NumarColoane * m.DatePartidaCastig.NumarRanduri; i++)
                {
                    if (String.Compare(m.pieceIdBoard[i].PieceName, sfpartida) == 0)
                    {
                        foreach (Mutare move2 in list2)
                        {
                            if (m.pieceIdBoard[i].PiecePosition == move2.To)
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            else
            {
                list2 = m.GetToateMutarilePosibileWhite(m);
                string sfpartida = m.NumePiesaafisaj(m.DatePartidaCastig.NumePiesa, CuloarePiesa.Negru);
                // if white king position is same as black's destination position, 
                // this would result in check, return true
                for (int i = 0; i < m.DatePartidaCastig.NumarColoane * m.DatePartidaCastig.NumarRanduri; i++)
                {
                    if (String.Compare(m.pieceIdBoard[i].PieceName, sfpartida) == 0)
                    {
                        foreach (Mutare move2 in list2)
                        {
                            if (m.pieceIdBoard[i].PiecePosition == move2.To)
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            return false;
        }

        internal void MakeMoveLight(int pos, int dest, MainGame m)
        {
            m.pieceIdBoard[dest].PieceName = m.pieceIdBoard[pos].PieceName;
            m.pieceIdBoard[pos].PieceName = "-";
            m.pieceIdBoard[dest].PieceValue = m.pieceIdBoard[pos].PieceValue;
            m.pieceIdBoard[pos].PieceValue = 0;

        }

        internal List<Mutare> EvaluareMutare(int adancime, MainGame m)
        {
            List<Mutare> ret = new List<Mutare>();
            List<Mutare> generator = new List<Mutare>();
            if (m.DatePartidaCastig.Culoare == CuloarePiesa.Negru)
                generator = m.GetToateMutarilePosibileWhite(m);
            else
                generator = m.GetToateMutarilePosibileBlack(m);
            List<Mutare> newGameMoves = generator.OrderByDescending(o => o.Value).ToList();
            int alpha = Int32.MinValue;
            int beta = Int32.MaxValue;
            int bestMove = alpha;
            Mutare bestMoveFound = new Mutare();
            bool immediateAttack = false;
            for (int j = 0; j < newGameMoves.Count; j++)
            {
                Mutare myMove = newGameMoves[j];
                string tempToName = m.pieceIdBoard[myMove.To].PieceName;
                int tempToValue = m.pieceIdBoard[myMove.To].PieceValue;
                string tempFromName = m.pieceIdBoard[myMove.From].PieceName;
                int tempFromValue = m.pieceIdBoard[myMove.From].PieceValue;
                AttackValue = 0;

                //Make the move
                ExecutaMutarea(m, myMove);

                //check for immediate attack
                immediateAttack = CheckForImmediateAttack(m, immediateAttack, myMove, tempToValue);

                // if none, get the best move
                if (!immediateAttack)
                {
                    int value = MinMax(adancime - 1, false, alpha, beta, m);

                    if (value >= bestMove)
                    {
                        if (bestMoveFound.To == 0 && bestMoveFound.From == 0)
                        {
                            bestMoveFound = myMove;
                        }
                        bestMoveFound = myMove;
                        ret.Add(bestMoveFound);
                        bestMove = value;
                    }
                }

                UndoMove(m, myMove, tempToName, tempToValue, tempFromName, tempFromValue);

                immediateAttack = false;
            }
            List<Mutare> retturnList = ret.OrderBy(o => o.Value).ToList();
            return retturnList;


        }

        private void ExecutaMutarea(MainGame m, Mutare myMove)
        {
            m.pieceIdBoard[myMove.To].PieceName = m.pieceIdBoard[myMove.From].PieceName;
            m.pieceIdBoard[myMove.To].PieceValue = m.pieceIdBoard[myMove.From].PieceValue;
            m.pieceIdBoard[myMove.From].PieceName = "-";
            m.pieceIdBoard[myMove.From].PieceValue = 0;
        }
        private static bool CheckForImmediateAttack(MainGame m, bool skip, Mutare myMove, int tempToValue)
        {
            List<Mutare> pnewGameMoves;
            if (m.DatePartidaCastig.Culoare == CuloarePiesa.Alb)
                pnewGameMoves = m.GetToateMutarilePosibileWhite(m);
            else
                pnewGameMoves = m.GetToateMutarilePosibileBlack(m);
            foreach (Mutare mov in pnewGameMoves)
            {
                if (mov.To == myMove.To)
                {
                    if (tempToValue <= Math.Abs(m.pieceIdBoard[myMove.To].PieceValue))
                    {
                        skip = true;
                    }
                }
            }
            return skip;
        }
        private static void UndoMove(MainGame b, Mutare myMove, string tempToName, int tempToValue, string tempFromName, int tempFromValue)
        {
            b.pieceIdBoard[myMove.From].PieceName = tempFromName;
            b.pieceIdBoard[myMove.From].PieceValue = tempFromValue;
            b.pieceIdBoard[myMove.To].PieceName = tempToName;
            b.pieceIdBoard[myMove.To].PieceValue = tempToValue;
        }
        public int MinMax(int depth, bool isMaximiser, int alpha, int beta, MainGame m)
        {
            //end of specified traversal length, evaluate board
            if (depth == 0)
            {
                int k = -EvaluateBoard(m);
                return k;
            }

            List<Mutare> newGameMoves = new List<Mutare>();
            List<Mutare> pnewGameMoves = new List<Mutare>();
            
            if (isMaximiser)
            {
                if (m.DatePartidaCastig.Culoare == CuloarePiesa.Negru)
                    pnewGameMoves = m.GetToateMutarilePosibileWhite(m);
                else
                    pnewGameMoves = m.GetToateMutarilePosibileBlack(m);
                newGameMoves = pnewGameMoves.OrderByDescending(o => o.Value).ToList();
                int bestMove = Int32.MinValue;
                for (int i = 0; i < newGameMoves.Count; i++)
                {
                    Mutare myMove = newGameMoves[i];
                    string tempToName = m.pieceIdBoard[myMove.To].PieceName;
                    int tempToValue = m.pieceIdBoard[myMove.To].PieceValue;
                    string tempFromName = m.pieceIdBoard[myMove.From].PieceName;
                    int tempFromValue = m.pieceIdBoard[myMove.From].PieceValue;
                    int minValue = m.pieceIdBoard[myMove.To].PieceValue;

                    ExecutaMutarea(m, myMove);

                    bestMove = Math.Max(bestMove, MinMax(depth - 1, false, alpha, beta, m));

                    UndoMove(m, myMove, tempToName, tempToValue, tempFromName, tempFromValue);

                    alpha = Math.Max(alpha, bestMove);
                    if (alpha >= beta)
                    {
                        break;
                    }
                }
                return bestMove;
            }

            else
            {
                if (m.DatePartidaCastig.Culoare != CuloarePiesa.Negru)
                    pnewGameMoves = m.GetToateMutarilePosibileWhite(m);
                else
                    pnewGameMoves = m.GetToateMutarilePosibileBlack(m);
                newGameMoves = pnewGameMoves.OrderByDescending(o => o.Value).ToList();
                int bestMove = Int32.MaxValue;

                for (int i = 0; i < newGameMoves.Count; i++)
                {
                    Mutare myMove = newGameMoves[i];
                    int maxValue = m.pieceIdBoard[myMove.To].PieceValue;
                    string tempToName = m.pieceIdBoard[myMove.To].PieceName;
                    int tempToValue = m.pieceIdBoard[myMove.To].PieceValue;
                    string tempFromName = m.pieceIdBoard[myMove.From].PieceName;
                    int tempFromValue = m.pieceIdBoard[myMove.From].PieceValue;
                    int minValue = m.pieceIdBoard[myMove.To].PieceValue;

                    ExecutaMutarea(m, myMove);
                    bestMove = Math.Min(bestMove, MinMax(depth - 1, true, alpha, beta, m));
                    UndoMove(m, myMove, tempToName, tempToValue, tempFromName, tempFromValue);

                    beta = Math.Min(beta, bestMove);

                    if (alpha >= beta)
                    {
                        break;
                    }
                }
                return bestMove;
            }
        }

        private int EvaluateBoard(MainGame m)
        {
            int totalEvaluation = 0;
            for (int i = 0; i < m.DatePartidaCastig.NumarColoane*m.DatePartidaCastig.NumarRanduri; i++)
            {
                totalEvaluation += m.pieceIdBoard[i].PieceValue;
            }
            totalEvaluation += AttackValue;

            return totalEvaluation;
        }
    }
}
