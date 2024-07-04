class Jogador
{
    private string cor;
    private Peao[] peoes;
    private int seisConsecutivos;
    private int casaInicial;
    public string Cor
    {
        get { return cor; }
    }
    public Peao[] Peoes
    {
        get { return peoes; }
    }
    public int SeisConsecutivos
    {
        get { return seisConsecutivos; }
        set { seisConsecutivos = value; }
    }
    public int CasaInicial
    {
        get { return casaInicial; }
    }

    public Jogador(string cor, int casaInicial)
    {
        this.cor = cor;
        this.peoes = new Peao[4] { new Peao(), new Peao(), new Peao(), new Peao() };
        SeisConsecutivos = 0;
        this.casaInicial = casaInicial;
    }
}
