using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighters : MonoBehaviour
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
    public static GameObject[,] highlighters = new GameObject[8, 8];

    public static bool assigned = false;

    // Start is called before the first frame update
    void Start()
    {
        Assign2DArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Assign2DArray()
    {
        for(int j = 0; j < 8; j++)
        {
            for(int i = 0; i < 8; i++)
            {
                if (j == 0)
                {
                    highlighters[i, j] = column1[i];
                }

                if (j == 1)
                {
                    highlighters[i, j] = column2[i];
                }

                if (j == 2)
                {
                    highlighters[i, j] = column3[i];
                }

                if (j == 3)
                {
                    highlighters[i, j] = column4[i];
                }

                if (j == 4)
                {
                    highlighters[i, j] = column5[i];
                }

                if (j == 5)
                {
                    highlighters[i, j] = column6[i];
                }

                if (j == 6)
                {
                    highlighters[i, j] = column7[i];
                }

                if (j == 7)
                {
                    highlighters[i, j] = column8[i];
                }
            }
        }
        assigned = true;
    }
}
