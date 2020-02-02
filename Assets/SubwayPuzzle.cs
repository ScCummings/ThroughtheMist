using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubwayPuzzle : MonoBehaviour {
    [System.Serializable]
    public enum Gemstone {
        EMPTY,
        RUBY,
        TURQUOISE,
        AMYTHYST,
        DIAMOND,
        EMERALD
    };
    public Sprite EmptyPiece;
    public Sprite RubyPiece;
    public Sprite TurquoisePiece;
    public Sprite AmythystPiece;
    public Sprite DiamondPiece;
    public Sprite EmeraldPiece;
    public Gemstone desiredGemstone;
    public bool isComplete = false;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    [PunRPC] public void ChangeGemstone(Gemstone gemstone) {
        switch (gemstone) {
            case Gemstone.EMPTY:
                GetComponent<SpriteRenderer>().sprite = EmptyPiece;
                if (desiredGemstone == Gemstone.EMPTY) {
                    isComplete = true;
                }
                else {
                    isComplete = false;
                }
                break;
            case Gemstone.RUBY:
                GetComponent<SpriteRenderer>().sprite = RubyPiece;
                if (desiredGemstone == Gemstone.RUBY) {
                    isComplete = true;
                }
                else {
                    isComplete = false;
                }
                break;
            case Gemstone.TURQUOISE:
                GetComponent<SpriteRenderer>().sprite = TurquoisePiece;
                if (desiredGemstone == Gemstone.TURQUOISE) {
                    isComplete = true;
                } else {
                    isComplete = false;
                }
                break;
            case Gemstone.AMYTHYST:
                GetComponent<SpriteRenderer>().sprite = AmythystPiece;
                if (desiredGemstone == Gemstone.AMYTHYST) {
                    isComplete = true;
                } else {
                    isComplete = false;
                }
                break;
            case Gemstone.DIAMOND:
                GetComponent<SpriteRenderer>().sprite = DiamondPiece;
                if (desiredGemstone == Gemstone.DIAMOND) {
                    isComplete = true;
                } else {
                    isComplete = false;
                }
                break;
            case Gemstone.EMERALD:
                GetComponent<SpriteRenderer>().sprite = EmeraldPiece;
                if (desiredGemstone == Gemstone.EMERALD) {
                    isComplete = true;
                } else {
                    isComplete = false;
                }
                break;
        }

    }

    private void OnTriggerStay2D(Collider2D collision) {
        Debug.Log("Made it into on trigger stay");
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            Debug.Log("zero input recognized");
            if(GameManager.Instance != null && GameManager.Instance.isNetworked) {
                GetComponent<PhotonView>().RequestOwnership();
                PhotonView photonView = PhotonView.Get(GetComponent<PhotonView>());
                photonView.RPC("ChangeGemstone", RpcTarget.All, Gemstone.EMPTY);
            } else {
                ChangeGemstone(Gemstone.EMPTY);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (GameManager.Instance != null && GameManager.Instance.isNetworked) {
                GetComponent<PhotonView>().RequestOwnership();
                PhotonView photonView = PhotonView.Get(GetComponent<PhotonView>());
                photonView.RPC("ChangeGemstone", RpcTarget.All, Gemstone.RUBY);
            } else {
                ChangeGemstone(Gemstone.RUBY);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (GameManager.Instance != null && GameManager.Instance.isNetworked) {
                GetComponent<PhotonView>().RequestOwnership();
                PhotonView photonView = PhotonView.Get(GetComponent<PhotonView>());
                photonView.RPC("ChangeGemstone", RpcTarget.All, Gemstone.TURQUOISE);
            } else {
                ChangeGemstone(Gemstone.TURQUOISE);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            if (GameManager.Instance != null && GameManager.Instance.isNetworked) {
                GetComponent<PhotonView>().RequestOwnership();
                PhotonView photonView = PhotonView.Get(GetComponent<PhotonView>());
                photonView.RPC("ChangeGemstone", RpcTarget.All, Gemstone.AMYTHYST);
            } else {
                ChangeGemstone(Gemstone.AMYTHYST);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            if (GameManager.Instance != null && GameManager.Instance.isNetworked) {
                GetComponent<PhotonView>().RequestOwnership();
                PhotonView photonView = PhotonView.Get(GetComponent<PhotonView>());
                photonView.RPC("ChangeGemstone", RpcTarget.All, Gemstone.DIAMOND);
            }
            else {
                ChangeGemstone(Gemstone.DIAMOND);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            if (GameManager.Instance != null && GameManager.Instance.isNetworked) {
                GetComponent<PhotonView>().RequestOwnership();
                PhotonView photonView = PhotonView.Get(GetComponent<PhotonView>());
                photonView.RPC("ChangeGemstone", RpcTarget.All, Gemstone.EMERALD);
            } else {
                ChangeGemstone(Gemstone.EMERALD);
            }
        }
    }
}
