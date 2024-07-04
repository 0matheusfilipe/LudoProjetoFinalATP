class Peao
{
    private int posicao;
    private bool estaEmJogo;
    private bool estaNaCasaFinal;
    private int distanciaPercorrida;
    public int Posicao 
    { 
        get { return posicao; } 
        set { posicao = value; } 
    }
    public bool EstaEmJogo 
    {
        get { return estaEmJogo; }
        set { estaEmJogo = value; }
    }
    public bool EstaNaCasaFinal 
    {
        get { return estaNaCasaFinal; }
        set { estaNaCasaFinal = value; }
    }
    public int DistanciaPercorrida
    {
        get { return distanciaPercorrida; }
        set { distanciaPercorrida = value; }
    }

    public Peao()
    {
        Posicao = -1;
        EstaEmJogo = false;
        EstaNaCasaFinal = false;
        DistanciaPercorrida = 0;
    }
}
