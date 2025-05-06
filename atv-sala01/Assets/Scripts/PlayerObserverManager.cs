using System;
using UnityEngine;

public static class PlayerObserverManager
{
    //Criar o canal
    public static event Action<int> OnMoedasChanged;
    
    //Postar vídeos
    public static void ChangedMoedas(int moedas)
    {
        //verifica se tem inscritos e manda notificação
        OnMoedasChanged?.Invoke(moedas);
    }
}
