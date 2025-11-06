using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellstuff : MonoBehaviour
{
    private int whichMagicSelected;
    private GameObject magic;

    // Start is called before the first frame update
    void Start()
    {
        whichMagicSelected = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchMagic();
        }
    }

    private void SwitchMagic()
    {
        switch (whichMagicSelected)
        {
            case 1:
                if (magic != null)
                {
                    Destroy(magic.gameObject);
                    
                }
                magic = Instantiate(Resources.Load("Prefabs/Missile_"), transform.position, transform.rotation) as GameObject;
                magic.transform.SetParent(gameObject.transform);
                magic.transform.localPosition = new Vector3(1.5f, 2.8f, 0f);
                magic.GetComponent<Renderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
                magic.transform.localScale = Vector3.one;
                whichMagicSelected += 1;
                break;

            case 2:
                if (magic != null)
                {
                    Destroy(magic.gameObject);

                }
                magic = Instantiate(Resources.Load("Prefabs/Spreadshot_"), transform.position, transform.rotation) as GameObject;
                magic.transform.SetParent(gameObject.transform);
                magic.transform.localPosition = new Vector3(1.5f, 2.8f, 0f);
                magic.GetComponent<Renderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
                magic.transform.localScale = Vector3.one;
                whichMagicSelected += 1;
                break;
        }

        if (whichMagicSelected > 2)
        {
            whichMagicSelected = 1;
        }
    }
}
