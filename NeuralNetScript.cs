using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetScript : MonoBehaviour
{
    public class NeuralNetwork
    {
        int[] layer;
        public Layer[] layers;
        public NeuralNetwork(int[] layercount)
        {
            layer = new int[layercount.Length];
            for (int i = 0; i < layer.Length; i++)
            {
                layer[i] = layercount[i];
            }

            layers = new Layer[layercount.Length - 1];

            for (int i = 0; i < layers.Length; i++)
            {
                layers[i] = new Layer(layercount[i], layercount[i + 1]);
            }
        }

        public float[] FeedForward(float[] ins)
        {
            layers[0].FeedForward(ins);

            for (int i = 1; i < layers.Length; i++)
            {
                layers[i].FeedForward(layers[i - 1].outs);
            }

            return layers[layers.Length - 1].outs;
        }

        public void BackProp(float[] expected)
        {
            for (int i = layers.Length - 1; i >= 0; i--)
            {
                if (i == layers.Length - 1)
                {
                    layers[i].BackPropOutput(expected);
                }
                else
                {
                    layers[i].BackPropHidden(layers[i + 1].gamma, layers[i + 1].weights);
                }
            }

            for (int i = 0; i < layers.Length; i++)
            {
                layers[i].UpdateWeights();
            }
        }

        public class Layer
        {
            public int numins;
            public int numouts;
            public float lr = 0.005f;

            public float[] ins;
            public float[] outs;
            public float[,] weights;
            public float[,] deltaweights;
            public float[] gamma;
            public float[] error;
            public static System.Random random = new System.Random();

            public Layer(int numberofinputs, int numberofoutputs)
            {
                numins = numberofinputs;
                numouts = numberofoutputs;

                ins = new float[numins];
                outs = new float[numouts];
                weights = new float[numouts, numins];
                deltaweights = new float[numouts, numins];
                gamma = new float[numouts];
                error = new float[numouts];

                InitializeWeights();
            }

            public void InitializeWeights()
            {
                for (int i = 0; i < numouts; i++)
                {
                    for (int j = 0; j < numins; j++)
                    {
                        weights[i, j] = (float)random.NextDouble() - 0.5f;
                    }
                }
            }

            public float[] FeedForward(float[] ins)
            {
                this.ins = ins;

                for (int i = 0; i < numouts; i++)
                {
                    outs[i] = 0;
                    for (int j = 0; j < numins; j++)
                    {
                        outs[i] += ins[j] * weights[i, j];
                    }

                    outs[i] = (float)Math.Tanh(outs[i]);
                }

                return outs;
            }

            public float TanHDer(float value)
            {
                return 1 - (value * value);
            }

            public void BackPropOutput(float[] expected)
            {
                for (int i = 0; i < numouts; i++)
                {
                    error[i] = outs[i] - expected[i];
                }

                for (int i = 0; i < numouts; i++)
                {
                    gamma[i] = error[i] * TanHDer(outs[i]);
                }

                for (int i = 0; i < numouts; i++)
                {
                    for (int j = 0; j < numins; j++)
                    {
                        deltaweights[i, j] = gamma[i] * ins[j];
                    }
                }
            }

            public void BackPropHidden(float[] gammaforward, float[,] weightsforward)
            {
                for (int i = 0; i < numouts; i++)
                {
                    gamma[i] = 0;

                    for (int j = 0; j < gammaforward.Length; j++)
                    {
                        gamma[i] += gammaforward[j] * weightsforward[j, i];
                    }
                    gamma[i] *= TanHDer(outs[i]);
                }

                for (int i = 0; i < numouts; i++)
                {
                    for (int j = 0; j < numins; j++)
                    {
                        deltaweights[i, j] = gamma[i] * ins[j];
                    }
                }
            }

            public void UpdateWeights()
            {
                for (int i = 0; i < numouts; i++)
                {
                    for (int j = 0; j < numins; j++)
                    {
                        weights[i, j] -= deltaweights[i, j] * lr;
                    }
                }
            }
        }
    }


    // Use this for initialization
    void Start ()
    {
        Debug.Log("Hello World");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
