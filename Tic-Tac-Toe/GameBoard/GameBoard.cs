﻿using gameBoard.Enums;
using gameBoard.Exceptions;

namespace gameBoard {
    internal class GameBoard {
        public int Columns { get; private set; }
        public int Rows { get; private set; }
        public Piece[,] Pieces { get; private set; }

        public GameBoard() {
            Columns = 3;
            Rows = 3;
            Pieces = new Piece[Rows, Columns];
        }

        public void AddPiece(Symbol cp, Position pos) {
            if (ExistsPieceOnPosition(pos)) {
                throw new BoardException("There is already a piece in this position");
            }
            Pieces[pos.Row, pos.Column] = new Piece(cp, pos);
        }

        // Returning a piece in a specific position
        public Piece GetPiece(Position pos) {
            return Pieces[pos.Row, pos.Column];
        }

        public Piece GetPiece(int row, int column) {
            return Pieces[row, column];
        }

        // Checks if the position is occupied by another piece
        private bool ExistsPieceOnPosition(Position pos) {
            ValidatePosition(pos);
            return GetPiece(pos) != null; // Checks if there is a piece at the parameter position
        }

        // Checks if the position is inside the tray
        private bool ValidPosition(Position pos) {           
            if (pos.Row < 0 || pos.Row >= Rows || pos.Column < 0 || pos.Column >= Columns) {
                return false;
            } else {
                return true;
            }
        }

        public void ValidatePosition(Position pos) {
            if (!ValidPosition(pos)) {
                throw new BoardException("Invalid position");
            }
        }
    }
}
