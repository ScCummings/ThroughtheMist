using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePuzzleBox : MonoBehaviour
{

    Sprite EmptyPiece = Resources.Load<Sprite>("EmptyPiece");      //FULL
    Sprite RubyPiece = Resources.Load<Sprite>("RubyPiece");    //-1
    Sprite TurquoisePiece = Resources.Load<Sprite>("TurquoisePiece");  //-2
    Sprite AmythystPiece = Resources.Load<Sprite>("AmythystPiece");
    Sprite DiamondPiece = Resources.Load<Sprite>("DiamondPiece");
    Sprite EmeraldPiece = Resources.Load<Sprite>("EmeraldPiece");
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Made it into on trigger stay");
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
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
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<Image>().sprite = AmythystPiece;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            GetComponent<Image>().sprite = DiamondPiece;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            GetComponent<Image>().sprite = EmeraldPiece;
        }
    }
}
