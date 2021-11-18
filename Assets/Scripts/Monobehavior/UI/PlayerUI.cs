using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    GameObject playerPanel;
    #region Display Model
    [SerializeField] Image topHead;
    [SerializeField] Image head;
    [SerializeField] Image neck;
    [SerializeField] Image upperBody;
    [SerializeField] Image body;
    [SerializeField] Image lowerBody;
    [SerializeField] Image legs;
    [SerializeField] Image feet;
    [SerializeField] Image hair;
    [SerializeField] Image self;
    #endregion

    #region
    [SerializeField] Image itemTopHead;
    [SerializeField] Image itemHead;
    [SerializeField] Image itemNeck;
    [SerializeField] Image itemUpperBody;
    [SerializeField] Image itemBody;
    [SerializeField] Image itemLowerBody;
    [SerializeField] Image itemLegs;
    [SerializeField] Image itemFeet;
    #endregion

    void Start() {
        playerPanel = this.gameObject;
    }

    public void ShowPlayerUI(Sprite[] itemsInUse) {
        if (itemsInUse[0] != null) {
            itemTopHead.enabled = topHead.enabled = true;
            itemTopHead.sprite = topHead.sprite = itemsInUse[0];
        } else
            itemTopHead.enabled = topHead.enabled = false;

        if (itemsInUse[1] != null) {
            itemHead.enabled = head.enabled = true;
            itemHead.sprite = head.sprite = itemsInUse[1];
        } else
            itemHead.enabled = head.enabled = false;

        if (itemsInUse[2] != null) {
            itemNeck.enabled = neck.enabled = true;
            itemNeck.sprite = neck.sprite = itemsInUse[2];
        } else
            itemNeck.enabled = neck.enabled = false;

        if (itemsInUse[3] != null) {
            itemUpperBody.enabled = upperBody.enabled = true;
            itemUpperBody.sprite = upperBody.sprite = itemsInUse[3];
        } else
            itemUpperBody.enabled = upperBody.enabled = false;

        if (itemsInUse[4] != null) {
            itemBody.enabled = body.enabled = true;
            itemBody.sprite = body.sprite = itemsInUse[4];
        } else
            itemBody.enabled = body.enabled = false;

        if (itemsInUse[5] != null) {
            itemLowerBody.enabled = lowerBody.enabled = true;
            itemLowerBody.sprite = lowerBody.sprite = itemsInUse[5];
        } else
            itemLowerBody.enabled = lowerBody.enabled = false;

        if (itemsInUse[6] != null) {
            itemLegs.enabled = legs.enabled = true;
            itemLegs.sprite = legs.sprite = itemsInUse[6];
        } else
            itemLegs.enabled = legs.enabled = false;

        if (itemsInUse[7] != null) {
            itemFeet.enabled = feet.enabled = true;
            itemFeet.sprite = feet.sprite = itemsInUse[7];
        } else
            itemFeet.enabled = feet.enabled = false;

        if (itemsInUse[8] != null) {
            this.hair.enabled = true;
            this.hair.sprite = itemsInUse[8];
        } else
            this.hair.enabled = false;

        if (itemsInUse[9] != null) {
            self.enabled = true;
            self.sprite = itemsInUse[9];
        } else
            self.enabled = false;
    }
}
