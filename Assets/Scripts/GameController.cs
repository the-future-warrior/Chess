using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    int iRow = 0, iColumn = 0;

    private SpriteRenderer sr;

    public GameObject chessBoard;

    public AudioSource whiteMove;
    public AudioSource blackMove;

    public GameObject whitePlayer;
    public GameObject blackPlayer;

    public static int row, column;

    private GameObject moveTracker;

    public static string activePlayer = "White Piece";
    public static string activeOpponent = "Black Piece";
    private string black = "Black Piece";
    private string white = "White Piece";

    // Start is called before the first frame update
    void Start()
    {
        moveTracker = GameObject.Find("MoveTracker");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HighlighterClicked(GameObject g)
    {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                // finds the highlighter from the array
                if (Highlighters.highlighters[i, j] == g)
                {
                    // checks if already highlighter is click to unhighlight it
                    if (Highlighters.highlighters[i, j].GetComponent<SpriteRenderer>().color == MoveTracker.silverCopy)
                    {
                        SetDefaultColour();
                        return;
                    }

                    // checking for blue highlighter click
                    else if (Highlighters.highlighters[i, j].GetComponent<SpriteRenderer>().color == MoveTracker.blueCopy)
                    {
                        MovePiece(iRow + 1, iColumn + 1, i + 1, j + 1);
                        Invoke("ChangeActivePlayer", 2);
                        return;
                    }

                    // checking for red highlighter click
                    else if (Highlighters.highlighters[i, j].GetComponent<SpriteRenderer>().color == MoveTracker.redCopy)
                    {
                        DestroyOpponentPiece(i + 1, j + 1);
                        MovePiece(iRow + 1, iColumn + 1, i + 1, j + 1);
                        Invoke("ChangeActivePlayer", 2);
                        return;
                    }

                    // activates the movetracker for available moves
                    else if (Pieces.pieces[i, j] != null && Pieces.pieces[i, j].tag == activePlayer)
                    {
                        SetDefaultColour();
                        sr = Highlighters.highlighters[i, j].GetComponent<SpriteRenderer>();
                        sr.color = MoveTracker.silverCopy;

                        //moveTracker.GetComponent<MoveTracker>().Rook(i + 1, j + 1);
                        FindPieceName(i + 1, j + 1);
                        iRow = i; iColumn = j;
                        return;
                    }
                }
            }
        }
    }

    // changes all highlighter colour to default invsible
    void SetDefaultColour()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                sr = Highlighters.highlighters[i, j].GetComponent<SpriteRenderer>();
                sr.color = new Color(0, 0, 0, 0);
            }
        }
    }

    // finds the exact name of the chess piece
    void FindPieceName(int row, int column)
    {
        row--; column--;

        string nameOfPiece = "null";

        // storing names of different pieces in array
        string[] piecesName = new string[6];
        piecesName[0] = "Rook";
        piecesName[1] = "Knight";
        piecesName[2] = "Bishop";
        piecesName[3] = "King";
        piecesName[4] = "Queen";
        piecesName[5] = "Pawn";

        // original name of the piece
        string originalName = Pieces.pieces[row, column].name + " ";
        string s;

        // creates substring of the words
        for (int i = 0; i < originalName.Length; i++)
        {
            if (originalName[i].Equals(' '))
            {
                s = originalName.Substring(0, i);
                originalName = originalName.Substring(i, (originalName.Length - i));
                i = 0;

                // checks all the words and compares with piece name
                for (int j = 0; j < piecesName.Length; j++)
                {
                    if (string.Compare(piecesName[j], s.Trim()) == 0)
                    {
                        nameOfPiece = piecesName[j];
                        CheckWhichPiece(++row, ++column, nameOfPiece);
                    }
                }
            }
        }
    }

    // checking for piece and calling respective functions
    void CheckWhichPiece(int row, int column, string name)
    {
        switch (name)
        {
            case "Rook":
                moveTracker.GetComponent<MoveTracker>().Rook(row, column);
                break;

            case "Knight":
                moveTracker.GetComponent<MoveTracker>().Knight(row, column);
                break;

            case "Bishop":
                moveTracker.GetComponent<MoveTracker>().Bishop(row, column);
                break;

            case "King":
                moveTracker.GetComponent<MoveTracker>().King(row, column);
                break;

            case "Queen":
                moveTracker.GetComponent<MoveTracker>().Queen(row, column);
                break;

            case "Pawn":
                moveTracker.GetComponent<MoveTracker>().Pawn(row, column);
                break;
        }
    }

    // moving the piece from initial to final position
    void MovePiece(int initialRow, int initialColumn, int finalRow, int finalColumn)
    {
        initialRow--; initialColumn--; finalRow--; finalColumn--;
        
        // transforming the position of the chess piece
        Pieces.pieces[initialRow, initialColumn].transform.position = Highlighters.highlighters[finalRow, finalColumn].transform.position;

        // play movement sound
        if (activePlayer == "White Piece")
            whiteMove.Play();
        else
            blackMove.Play();

        // reinitializing the array elements
        Pieces.pieces[finalRow, finalColumn] = Pieces.pieces[initialRow, initialColumn];
        Pieces.pieces[initialRow, initialColumn] = null;

        SetDefaultColour();


    }

    // destroys the opponent piece
    void DestroyOpponentPiece(int row, int column)
    {
        row--; column--;

        // destroying opponent piece
        Destroy(Pieces.pieces[row, column]);
    }

    // changes the active player
    void ChangeActivePlayer()
    {
        if (activePlayer == "White Piece")
        {
            activePlayer = "Black Piece";
            activeOpponent = "White Piece";

            whitePlayer.SetActive(false);
            blackPlayer.SetActive(true);
        }
        else
        {
            activePlayer = "White Piece";
            activeOpponent = "Black Piece";

            blackPlayer.SetActive(false);
            whitePlayer.SetActive(true);
        }

        chessBoard.transform.Rotate(0, 0, 180f);
    }
}