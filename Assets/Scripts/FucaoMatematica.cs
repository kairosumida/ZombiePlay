using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FucaoMatematica
{
    //Usar um programa externo para escolher os melhores valores para influencia
    public static float ValorCrescente(float ValorMax, float ValorMin, float x, float inclinacaoDoGrafico)
    {
        return ValorMax - ((ValorMax - ValorMin) / Mathf.Pow(x, inclinacaoDoGrafico));
    }
    public static float ValorDecrescente(float ValorMax, float ValorMin, float x, float inclinacaoDoGrafico)
    {
        return (ValorMax - ValorMin) / (Mathf.Pow(x, inclinacaoDoGrafico))+ValorMin;
    }
    public static int ValorCrescenteInteiro(int ValorMax, int ValorMin, int x, float inclinadoDoGrafico)
    {
        return (int)ValorCrescente(ValorMax + 1, ValorMin, x, inclinadoDoGrafico);
    }
    public static int ValorDecrescenteInteiro(int ValorMax, int ValorMin, int x, float inclinadorDoGrafico)
    {
        return (int)ValorDecrescente(ValorMax, ValorMin, x, inclinadorDoGrafico);
    }
    public static float ValorCrescente(float ValorMax, float x)
    {
        return ValorCrescente(ValorMax, 1, x, 0.4f);
    }
    public static float ValorDecrescente(float ValorMax, float x)
    {
        return ValorDecrescente(ValorMax, 1, x, 0.4f);
    }

    public static int ValorCrescenteAlterado(float valorMax, float x, float inclinacaoDoGrafico)
    {
         int i = (int)(valorMax - ((valorMax - 0) / Mathf.Pow(x, inclinacaoDoGrafico)));
        if(i == 0) { i = 1; }

        return i+1;
    }
    //Para valores entre 2 numeros o melhor é influencia 0.28
}
