class Jogador
{
    public string Cor { get; }
    public Peao[] Peoes { get; }
    public int SeisConsecutivos { get; set; }
    public int CasaInicial { get; }

    public Jogador(string cor, int casaInicial)
    {
        Cor = cor;
        Peoes = new Peao[4] { new Peao(), new Peao(), new Peao(), new Peao() };
        SeisConsecutivos = 0;
        CasaInicial = casaInicial;
    }
}
