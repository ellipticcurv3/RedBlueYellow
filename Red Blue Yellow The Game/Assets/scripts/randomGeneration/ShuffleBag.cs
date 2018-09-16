using UnityEngine;
//using System;
//using System.Collections;
using System.Collections.Generic; // Om lists en dikke nairies te gebruiken heb je deze nodig

    /* Start van de ShuffleBag code */
    public class ShuffleBag : MonoBehaviour
    {
    private System.Random random = new System.Random();
        private List<char> data;

        private char currentItem;
        private int currentPosition = -1;

        private int Capacity { get { return data.Capacity; } }
        public int Size { get { return data.Count; } }

        public ShuffleBag(int initCapacity)
        {
            data = new List<char>(initCapacity);
        }

        public void Add(char item, int amount)
        {
            for (int i = 0; i < amount; i++)
                data.Add(item);

            currentPosition = Size - 1;
        }

        public char Next()
        {
            if (currentPosition < 1)
            {
                currentPosition = Size - 1;
                currentItem = data[0];

                return currentItem;
            }

            var pos = random.Next(currentPosition);

            currentItem = data[pos];
            data[pos] = data[currentPosition];
            data[currentPosition] = currentItem;
            currentPosition--;

            return currentItem;
        }


    private static Dictionary<char, double> letterFrequencies = new Dictionary<char, double>()
{
    {'E', 12.702},
    {'T', 9.056},
    {'A', 8.167},
    {'O', 7.507},
    {'I', 6.966},
    {'N', 6.769},
    {'S', 6.327},
    {'H', 6.094},
    {'R', 5.987},
    {'D', 4.253},
    {'L', 4.025},
    {'C', 2.782},
    {'U', 2.758},
    {'M', 2.406},
    {'W', 2.306},
    {'F', 2.228},
    {'G', 2.015},
    {'Y', 1.974},
    {'P', 1.929},
    {'B', 1.492},
    {'V', 0.978},
    {'K', 0.772},
    {'J', 0.153},
    {'X', 0.150},
    {'Q', 0.095},
    {'Z', 0.074}
};

    // Use this for initialization
    void Start()
    {
        var shuffleBag = new ShuffleBag(88000);

        int amount = 0;
        foreach (var letter in letterFrequencies)
        {
            amount = (int)letter.Value * 1000;
            shuffleBag.Add(letter.Key, amount);
        }

        for (int i = 0; i < 16; i++)
        {
            print("Random: " + shuffleBag.Next());
            //print('\n');
        }
    }

    // Update is called once per frame
    void Update()
    {
    }


}

