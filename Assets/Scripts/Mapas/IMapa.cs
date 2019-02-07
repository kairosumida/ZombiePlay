using UnityEngine;

public interface IMapa
{
    Vector3 Construir(Vector3 posicao);
    void SetNivel(int nivel);
}
