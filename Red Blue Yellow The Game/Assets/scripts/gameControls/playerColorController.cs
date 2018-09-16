using UnityEngine;
using System;
using System.Collections;

public class playerColorController : MonoBehaviour
{
    /*  Definities
            Boolean. Waar of niet waar. True of false. Aan of uit. 1 of 0.
            Bitmask. Een enkele byte (8 bits) variabele gebruik je als 8 booleans.
                     Zo kun je tot 256 combinaties maken en van iedere positie zien of het true of false is.

        Onthoud: Boolean is true of false,
                 met een bitmask van een byte maak je in feite 8 booleans,
                 het klinkt ingewikkelder dan het is.

        Voordeel? Je hoeft niet moeilijk te doen met uitgebreid geneste if-statements want je kunt heel goed werken met een switch case
        en een switch case kan van nature ook aan meerdere voorwaarden voldoen en dan functies aanroepen.
        En je kunt in je hoofd rekenen als je een beetje binair begrijpt. Dus dan weet je: 3 in decimaal is 00000011 binair, binair is van rechts naar links dus dan zou je rood en blauw moeten hebben.
    */

    // Dit zijn de flags voor kleuren [-----YBR]
    /*
    private byte redColor = 1;       // 00000001 in binair
    private byte blueColor = 2;      // 00000010 in binair
    private byte yellowColor = 4;    // 00000100 in binair
    */
    /* Dus red + yellow = 1 + 4 = 5  =  00000101 in binair   (check door hierboven te kijken
                                                             of 5 met een rekenmachine naar binair om te zetten)
                                                                Handig toch?
                                                                In een enkele byte kunnen we zien dat we rood en geel hebben. */

    private byte inversedColor = 7;  /* 00000111 in binair, gebruikt om het tegenovergestelde te berekenen
                                           [-----YBR]              [-----YBR]
                                       bijv 00000101 XOR 00000111 = 00000010
                                                5           7           2
                                            Rood+Geel     Alles   =   Blauw
                                            
                                            maar je kunt ook 7 - 5 = 2 doen. */
    
    /*  We noemen de variabele waar de kleur in komt even currentPlayerColor.
        Misschien willen we de overige 5 bits nog gebruiken, 2
        voor extensies en dergelijke. */
        
    public byte currentPlayerColor = 0; // Declaratie & initialisatie.

  /*private ushort checkPlayerColor()
    {
        if ((currentPlayerColor & 1) == 1)
            print("We hebben rood");
        if ((currentPlayerColor & 2) == 2)
            print("We hebben blauw");
        if ((currentPlayerColor & 4) == 4)
            print("We hebben geel");
        if (currentPlayerColor == 0)
            print("We hebben niets");
        return currentPlayerColor;
    } */

    /* private void checkPlayerColorTester()
    {
        // Zogenaamd kleur rood indrukken
        currentPlayerColor = (byte)(currentPlayerColor ^ redColor);
        print("INFO => Kleur: alleen rood...");

        checkPlayerColor();

        // Zogenaamd kleur geel erbij indrukken
        currentPlayerColor = (byte)(currentPlayerColor ^ yellowColor);
        print("INFO => Kleur: rood & geel...");

        checkPlayerColor();

        // Zogenaamd kleur rood loslaten indrukken
        currentPlayerColor = (byte)(currentPlayerColor ^ redColor);
        print("INFO => Kleur: alleen geel...");

        checkPlayerColor();

        // Zogenaamd kleur blauw indrukken
        currentPlayerColor = (byte)(currentPlayerColor ^ blueColor);
        print("INFO => Kleur: blauw & geel...");

        checkPlayerColor();

        // Zogenaamd kleur geel loslaten
        currentPlayerColor = (byte)(currentPlayerColor ^ yellowColor);
        print("INFO => Kleur: alleen blauw...");

        checkPlayerColor();

        // Zogenaamd knoppen omwisselen d.m.v. een berekening (dus rood en geel blijft over)
        currentPlayerColor = (byte)(currentPlayerColor ^ inversedColor);
        print("INFO => Knoppen omgedraaid. Kleur: alleen rood & geel...");

        checkPlayerColor();
    } */

    public byte changePlayerColorState(ushort color)
    {
        // Voorbeeld: Roep changePlayerColorState(redColor); aan om rood aan/uit te zetten.
        currentPlayerColor = (byte)(currentPlayerColor ^ color);
        return currentPlayerColor;
    }

    // Use this for initialization
    void Start()
    {
        print("playerColorController => Script is succesvol geladen");

        // Zet currentPlayerColor op niks
        currentPlayerColor = 0;
        print("playerColorController => currentPlayerColor staat op " + currentPlayerColor);
    }

}
