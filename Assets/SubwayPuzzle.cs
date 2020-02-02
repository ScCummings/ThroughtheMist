using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubwayPuzzle : MonoBehaviour
{
    public Sprite EmptyPiece;      
    public Sprite RubyPiece;    
    public Sprite TurquoisePiece;    
    public Sprite AmythystPiece;
    public Sprite DiamondPiece;
    public Sprite EmeraldPiece;
    public bool isComplete;
    // Start is called before the first frame update
    void Start()
    {
        isComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision) {
        Debug.Log("Made it into on trigger stay");
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("zero input recognized");
            GetComponent<Image>().sprite = EmptyPiece;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetComponent<Image>().sprite = RubyPiece;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<Image>().sprite = TurquoisePiece;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<Image>().sprite = AmythystPiece;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GetComponent<Image>().sprite = DiamondPiece;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GetComponent<Image>().sprite = EmeraldPiece;
        }
        isComplete = true;
    }
}
