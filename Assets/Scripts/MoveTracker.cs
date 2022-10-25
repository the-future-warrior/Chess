using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTracker : MonoBehaviour
{
    public static bool isRook = false;
    public static bool isKnight = false;
    public static bool isBishop = false;
    public static bool isKing = false;
    public static bool isQueen = false;
    public static bool isPawn = false;

    public static bool done = false;

    // colours of the highlighters
    public Color blue;
    public Color silver;
    public Color red;

    public static Color blueCopy;
    public static Color silverCopy;
    public static Color redCopy;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        blueCopy = blue;
        silverCopy = silver;
        redCopy = red;
    }

    // Update is called once per frame
    void Update()
    {
        if (Highlighters.assigned && !done)
        {
            done = true;
            //Pawn(3, 4);
        }
    }

    // Rook Piece
    public void Rook(int row, int column)
    {
        row--; column--;

        // assigning default piece colour to the highlighter
        AssignColour(row, column, silver);

        // checking rows & columns
        CheckArea(row - 1, column, -1, 0, true);
        CheckArea(row + 1, column, +1, 0, true);
        CheckArea(row, column - 1, 0, -1, true);
        CheckArea(row, column + 1, 0, +1, true);
    }

    // Bishop Piece
    public void Bishop(int row, int column)
    {
        row--; column--;

        // assigning default piece colour to the highlighter
        AssignColour(row, column, silver);

        // checking diagonals
        CheckArea(row - 1, column - 1, -1, -1, true);
        CheckArea(row + 1, column + 1, +1, +1, true);
        CheckArea(row + 1, column - 1, +1, -1, true);
        CheckArea(row - 1, column + 1, -1, +1, true);
    }

    // Queen Piece
    public void Queen(int row, int column)
    {
        row--; column--;

        // assigning default piece colour to the highlighter
        AssignColour(row, column, silver);

        // checking rows & columns
        CheckArea(row - 1, column, -1, 0, true);
        CheckArea(row + 1, column, +1, 0, true);
        CheckArea(row, column - 1, 0, -1, true);
        CheckArea(row, column + 1, 0, +1, true);

        // checking diagonals
        CheckArea(row - 1, column - 1, -1, -1, true);
        CheckArea(row + 1, column + 1, +1, +1, true);
        CheckArea(row + 1, column - 1, +1, -1, true);
        CheckArea(row - 1, column + 1, -1, +1, true);
    }

    // King Piece
    public void King(int row, int column)
    {
        row--; column--;

        // assigning default piece colour to the highlighter
        AssignColour(row, column, silver);

        // checking rows & columns
        CheckArea(row - 1, column, 0, 0, false);
        CheckArea(row + 1, column, 0, 0, false);
        CheckArea(row, column - 1, 0, 0, false);
        CheckArea(row, column + 1, 0, 0, false);

        // checking diagonals
        CheckArea(row - 1, column - 1, 0, 0, false);
        CheckArea(row + 1, column + 1, 0, 0, false);
        CheckArea(row + 1, column - 1, 0, 0, false);
        CheckArea(row - 1, column + 1, 0, 0, false);
    }

    // Knight Piece
    public void Knight(int row, int column)
    {
        row--; column--;

        // assigning default piece colour to the highlighter
        AssignColour(row, column, silver);

        // checking for the vertical area
        CheckArea(row - 2, column - 1, 0, 0, false);
        CheckArea(row - 2, column + 1, 0, 0, false);
        CheckArea(row + 2, column - 1, 0, 0, false);
        CheckArea(row + 2, column + 1, 0, 0, false);

        // checking for the horizontal area
        CheckArea(row - 1, column - 2, 0, 0, false);
        CheckArea(row + 1, column - 2, 0, 0, false);
        CheckArea(row - 1, column + 2, 0, 0, false);
        CheckArea(row + 1, column + 2, 0, 0, false);
    }

    // Pawn Piece
    public void Pawn(int row, int column)
    {
        row--; column--;
        int r, c, delta;

        if (GameController.activePlayer == "White Piece")
        {
            delta = +1;
        }
        else
        {
            delta = -1;
        }

        r = row - delta; c = column;

        // assigning default piece colour to the highlighter
        AssignColour(row, column, silver);

        // 1st forward row
        if (r >= 0 && r <= 7 && c >= 0 && c <= 7 && Pieces.pieces[r, c] == null)
        {
            AssignColour(r, c, blue);
        }

        // first time two forward rows
        if(false)
        {
            r = r - delta;
            if (r >= 0 && r <= 7 && c >= 0 && c <= 7 && Pieces.pieces[r, c] == null)
            {
                AssignColour(r, c, blue);
            }
        }

        // checking for opponent
        r = row; c = column;
        r -= delta; c -= delta;
        if(r >= 0 && r <= 7 && c >= 0 && c <= 7 && Pieces.pieces[r, c] != null && Pieces.pieces[r, c].tag == GameController.activeOpponent)
        {
            AssignColour(r, c, red);
        }

        r = row; c = column;
        r -= delta; c += delta;
        if (r >= 0 && r <= 7 && c >= 0 && c <= 7 && Pieces.pieces[r, c] != null && Pieces.pieces[r, c].tag == GameController.activeOpponent)
        {
            AssignColour(r, c, red);
        }
    }

    // getting the sprite renderer component of the respective piece & assiging passed colour
    void AssignColour(int row, int column, Color color)
    {
        sr = Highlighters.highlighters[row, column].GetComponent<SpriteRenderer>();
        sr.color = color;
    }

    // checks the surrounding area of the piece for available moves
    void CheckArea(int r, int c, int deltaRow, int deltaColumn, bool checkAllArea)
    {
        bool keepChecking = true;

        while (keepChecking)
        {
            if (r >= 0 && r <= 7 && c >= 0 && c <= 7 && Pieces.pieces[r, c] == null)
            {
                AssignColour(r, c, blue);

                // modifying the row & column values for area checking
                r += deltaRow;
                c += deltaColumn;

                // checking if it is a king, horse or pawn
                if (checkAllArea == false)
                    return;
            }
            else
            {
                keepChecking = false;

                // checking for opponent pieces
                if(r >= 0 && r <= 7 && c >= 0 && c <= 7 && Pieces.pieces[r, c].tag == GameController.activeOpponent)
                {
                    AssignColour(r, c, red);
                }
            }
        }
    }
}
