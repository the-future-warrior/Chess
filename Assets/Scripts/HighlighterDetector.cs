using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlighterDetector : MonoBehaviour
{
    private SpriteRenderer sr;

    public static int row, column;

    private GameObject moveTracker;

    private GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        moveTracker = GameObject.Find("MoveTracker");
        gameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        gameController.GetComponent<GameController>().HighlighterClicked(gameObject);
    }
}
