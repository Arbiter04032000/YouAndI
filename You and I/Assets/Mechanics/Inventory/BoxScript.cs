using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public Inventory inventory;
    public Dialogue dialogueFail;
    public Dialogue dialogueSuccess;
    public SpriteRenderer selfSprite;
    public Sprite spriteFull;
    int i;

    public void Interact()
    {
        i = 0;
        foreach(bool coin in inventory.coins)
        {
            print(coin);
            if (coin == false)
            {
                FindObjectOfType<DialogueMan>().startDialogue(dialogueFail, this.gameObject);
                return;
            }

            if (coin == true)
            {
                i++;
            }
        }

        if(i == 3)
        {
            FindObjectOfType<DialogueMan>().startDialogue(dialogueSuccess, this.gameObject);
            selfSprite.sprite = spriteFull;
        }
    }
}
