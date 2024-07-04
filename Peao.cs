class Peao
{
    public int Posicao { get; set; }
    public bool EstaEmJogo { get; set; }
    public bool EstaNaCasaFinal { get; set; }
    public int DistanciaPercorrida { get; set; }

    public Peao()
    {
        Posicao = -1;
        EstaEmJogo = false;
        EstaNaCasaFinal = false;
        DistanciaPercorrida = 0;
    }
}
