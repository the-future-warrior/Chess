using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    // stores all the columns
    public GameObject[] column1 = new GameObject[8];
    public GameObject[] column2 = new GameObject[8];
    public GameObject[] column3 = new GameObject[8];
    public GameObject[] column4 = new GameObject[8];
    public GameObject[] column5 = new GameObject[8];
    public GameObject[] column6 = new GameObject[8];
    public GameObject[] column7 = new GameObject[8];
    public GameObject[] column8 = new GameObject[8];


    // stores all the boxes in 2D array;
    public static GameObject[,] pieces = new GameObject[8, 8];

    // Start is called before the first frame update
    void Start()
    {
        Assign2DArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public static int x = 7, y = 3;
    void Assign2DArray()
    {
        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                if (j == 0)
                {
                    pieces[i, j] = column1[i];
                }

                if (j == 1)
                {
                    pieces[i, j] = column2[i];
                }

                if (j == 2)
                {
                    pieces[i, j] = column3[i];
                }

                if (j == 3)
                {
                    pieces[i, j] = column4[i];
                }

                if (j == 4)
                {
                    pieces[i, j] = column5[i];
                }

                if (j == 5)
                {
                    pieces[i, j] = column6[i];
                }

                if (j == 6)
                {
                    pieces[i, j] = column7[i];
                }

                if (j == 7)
                {
                    pieces[i, j] = column8[i];
                }
            }
        }
        //Destroy(pieces[x-1, y-1]);
    }
}
