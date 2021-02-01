using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tester : MonoBehaviour
{
    float[] TestFloats = new float[3];
    int i = 0;

    NeuralNetScript.NeuralNetwork net = new NeuralNetScript.NeuralNetwork(new int[] { 3, 55, 55, 1 });

    public TextMeshProUGUI outputText;

    public void AppleButtonClick()
    {
        if(i < 3)
        {
            TestFloats[i] = 0;
            i++;
        }
    }

    public void KiwiButtonClick()
    {
        if (i < 3)
        {
            TestFloats[i] = 1;
            i++;
        }
    }

    public void BannanaButtonClick()
    {
        if (i < 3)
        {
            TestFloats[i] = 2;
            i++;
        }
    }

    public void RedButtonClick()
    {
        if (i < 3)
        {
            TestFloats[i] = 3;
            i++;
        }
    }

    public void GreenButtonClick()
    {
        if (i < 3)
        {
            TestFloats[i] = 4;
            i++;
        }
    }

    public void BlueButtonClick()
    {
        if (i < 3)
        {
            TestFloats[i] = 5;
            i++;
        }
    }

    public void ClearOutput()
	{
        outputText.text = "Output";
    }

    public void CustomTestButtonClick()
    {
        outputText.text += "\n Custom Test Results:";
        outputText.text += "\n " + net.FeedForward(TestFloats)[0];
        i = 0;
    }

    public void CustomBackPropButtonClick()
    {
        outputText.text += "\n Custom Test Results:";
        outputText.text += "\n" + net.FeedForward(TestFloats)[0];
        foreach (float j in TestFloats)
        {
            if (j == 3)
                net.BackProp(new float[] { 0.3f });
            if (j == 4)
                net.BackProp(new float[] { 0.4f });
            if (j == 5)
                net.BackProp(new float[] { 0.5f });
        }
        i = 0;
    }

    public void Learn()
    {
        for (int i = 0; i < 10000; i++)
        {
            net.FeedForward(new float[] { 0, 1, 3 });
            net.BackProp(new float[] { 0.3f });

            net.FeedForward(new float[] { 0, 1, 4 });
            net.BackProp(new float[] { 0.4f });

            net.FeedForward(new float[] { 0, 1, 5 });
            net.BackProp(new float[] { 0.5f });

            net.FeedForward(new float[] { 0, 2, 3 });
            net.BackProp(new float[] { 0.3f });

            net.FeedForward(new float[] { 0, 2, 4 });
            net.BackProp(new float[] { 0.4f });

            net.FeedForward(new float[] { 0, 2, 5 });
            net.BackProp(new float[] { 0.5f });

            net.FeedForward(new float[] { 0, 3, 1 });
            net.BackProp(new float[] { 0.3f });

            net.FeedForward(new float[] { 0, 3, 2 });
            net.BackProp(new float[] { 0.3f });

            net.FeedForward(new float[] { 0, 4, 1 });
            net.BackProp(new float[] { 0.4f });

            net.FeedForward(new float[] { 0, 4, 2 });
            net.BackProp(new float[] { 0.4f });

            net.FeedForward(new float[] { 0, 5, 1 });
            net.BackProp(new float[] { 0.5f });

            net.FeedForward(new float[] { 0, 5, 2 });
            net.BackProp(new float[] { 0.5f });

            net.FeedForward(new float[] { 1, 0, 3 });
            net.BackProp(new float[] { 0.3f });

            net.FeedForward(new float[] { 1, 0, 4 });
            net.BackProp(new float[] { 0.4f });

            net.FeedForward(new float[] { 1, 0, 5 });
            net.BackProp(new float[] { 0.5f });

            net.FeedForward(new float[] { 1, 2, 3 });
            net.BackProp(new float[] { 0.3f });

            net.FeedForward(new float[] { 1, 2, 4 });
            net.BackProp(new float[] { 0.4f });

            net.FeedForward(new float[] { 1, 2, 5 });
            net.BackProp(new float[] { 0.5f });

            net.FeedForward(new float[] { 1, 3, 0 });
            net.BackProp(new float[] { 0.3f });

            net.FeedForward(new float[] { 1, 3, 2 });
            net.BackProp(new float[] { 0.3f });
        }
    }

    public void Print()
    {
        outputText.text += "\n" + net.FeedForward(new float[] { 0, 1, 3 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 0, 1, 4 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 0, 1, 5 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 0, 2, 3 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 0, 2, 4 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 0, 2, 5 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 0, 3, 1 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 0, 3, 2 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 0, 4, 1 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 0, 4, 2 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 0, 5, 1 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 0, 5, 2 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 1, 0, 3 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 1, 0, 4 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 1, 0, 5 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 1, 2, 3 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 1, 2, 4 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 1, 2, 5 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 1, 3, 0 })[0];
        outputText.text += "\n" + net.FeedForward(new float[] { 1, 3, 2 })[0];
    }

    // Use this for initialization
    void Start ()
    {
        /* 
        apple = 0 kiwi = 1 bannana = 2 red = 3 green = 4 blue = 5

        Tests:
           net.FeedForward(new float[] {5,0,1} );
           net.BackProp(new float[] { 0.5f });
           net.FeedForward(new float[] {5,0,2} );
           net.BackProp(new float[] { 0.5f });
        */
    }

    // Update is called once per frame
    void Update ()
    {

	}

}
