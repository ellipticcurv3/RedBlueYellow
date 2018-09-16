using UnityEngine;
using System.Collections;

public class PCKeyboardInput : MonoBehaviour {


    // De publics. De waarden van deze variabelen komen in zichtbaar in de engine.

    public static GameObject    character;          // Het character waarop kleuren veranderen & (nu nog) verplaatsingen gebeuren
     
    public GameObject           PauseMenu;

    public KeyCode  redKey      = KeyCode.Alpha1,         // Toets voor rood      = cijfertoets 1 boven toetsenbord
                    blueKey     = KeyCode.Alpha2,         // Toets voor blauw     = cijfertoets 2 boven toetsenbord
                    yellowKey   = KeyCode.Alpha3,         // Toets voor geel      = cijfertoets 3 boven toetsenbord
                    menuKey     = KeyCode.Escape;         //

    public Sprite[] playerSprites;                      // Array met sprites voor de speler, sprites aangeven in editor

    public float   movementSpeed    = 9.0f;             // Snelheid van het verplaatsen

    // De privates. Oftewel: waarden van variabelen die alleen intern in dit script gebruikt worden.

    // De eerste is een const, oftewel een variabele met een vaste waarde die na het compileren niet te veranderen is vanuit een functie
    // Dit was nodig omdat een switch case in C# alleen om kan gaan met constants.

    private const byte  redColor    = 1,                // Character met rood   = 00000001 in binair
                        blueColor   = 2,                // Character met blauw  = 00000010 in binair
                        yellowColor = 4;                // Character met geel   = 00000100 in binair
                                                        // Characters combineren is mogelijk, we doen dit bitmasken

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        print("PCKeyBoardinput => Script met succes geladen");
        PauseMenu.SetActive(false);                 //Deactiveert menu vanaf startup
    }

    private void changeColor(byte color)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = playerSprites[0];

        spriteRenderer.sprite = playerSprites[color];

    }
    private void checkArrowButtons()
    {
        if (Input.GetKeyUp (menuKey)) {
            PauseMenu.SetActive (!PauseMenu.activeSelf); 
        }
    }

    public static byte currentPressedKeys;

    public void checkColorButtons()
    {
        currentPressedKeys = 0;    // Zet huidige toetsen op 0

        if (Input.GetKey(redKey))
        {
            currentPressedKeys += redColor;    // Voeg rood toe indien ingedrukt
        }

        if (Input.GetKey(blueKey))
        {
            currentPressedKeys += blueColor;    // Voeg blauw toe indien ingedrukt
        }

        if (Input.GetKey(yellowKey))
        {
            currentPressedKeys += yellowColor;    // Voeg geel toe indien ingedrukt
        }

        changeColor(currentPressedKeys);
    }

    // Update is called once per frame
    void Update () {
        checkArrowButtons();
        checkColorButtons();
    }
}
