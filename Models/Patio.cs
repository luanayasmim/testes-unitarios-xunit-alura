namespace console_estacionamento.Models;

public class Patio
{
    private Operador _operadorPatio;
    public Patio()
    {
        Faturado = 0;
        veiculos = new List<Veiculo>();
    }
    private List<Veiculo> veiculos;
    private double faturado;
    public double Faturado { get => faturado; set => faturado = value; }
    public List<Veiculo> Veiculos { get => veiculos; set => veiculos = value; }
    public Operador OperadorPatio { get => _operadorPatio; set => _operadorPatio = value; }
    public double TotalFaturado()
    {
        return this.Faturado;
    }

    public string MostrarFaturamento()
    {
        string totalfaturado = String.Format("Total faturado até o momento :::::::::::::::::::::::::::: {0:c}", this.TotalFaturado());
        return totalfaturado;
    }

    public void RegistrarEntradaVeiculo(Veiculo veiculo)
    {
        veiculo.HoraEntrada = DateTime.Now;
        veiculo.Ticket = this.GerarTicket(veiculo);
        this.Veiculos.Add(veiculo);
    }

    public string RegistrarSaidaVeiculo(String placa)
    {
        Veiculo encontrado = null;
        string registro = string.Empty;

        foreach (Veiculo v in this.Veiculos)
        {
            if (v.Placa == placa)
            {
                v.HoraSaida = DateTime.Now;
                TimeSpan tempo = v.HoraSaida - v.HoraEntrada;
                double valorCobrado = 0;
                if (v.Tipo == TipoVeiculo.Automovel)
                {
                    /// o método Math.Ceiling(), aplica o conceito de teto da matemática onde o valor máximo é o inteiro imediatamente posterior a ele.
                    /// Ex.: 0,9999 ou 0,0001 teto = 1
                    /// Obs.: o conceito de chão é inverso e podemos utilizar Math.Floor();
                    valorCobrado = Math.Ceiling(tempo.TotalHours) * 2;

                }
                else if (v.Tipo == TipoVeiculo.Motocicleta)
                {
                    valorCobrado = Math.Ceiling(tempo.TotalHours) * 1;
                }
                registro = string.Format(" Hora de entrada: {0: HH: mm: ss}\n " +
                                         "Hora de saída: {1: HH:mm:ss}\n " +
                                         "Permanência: {2: HH:mm:ss} \n " +
                                         "Valor a pagar: {3:c}", v.HoraEntrada, v.HoraSaida, new DateTime().Add(tempo), valorCobrado);
                encontrado = v;
                this.Faturado = this.Faturado + valorCobrado;
                break;
            }

        }
        if (encontrado != null)
        {
            this.Veiculos.Remove(encontrado);
        }
        else
        {
            return "Não há veículo com a placa informada.";
        }

        return registro;
    }

    public Veiculo AlteraDadosVeiculo(Veiculo veiculoAlterado)
    {
        // Como estamos trabalhando com array de objetos,
        // Podemos utilizar os recursos do `Linq to Objetcs` do .NET
        var veiculoTemp = (from veiculo in this.Veiculos
                           where veiculo.Placa == veiculoAlterado.Placa
                           select veiculo).SingleOrDefault();
        veiculoTemp.AlteraDadosVeiculo(veiculoAlterado);
        return veiculoTemp;

    }

    public Veiculo PesquisaVeiculoPorTicket(string ticket)
    {
        // Como estamos trabalhando com array de objetos,
        // Podemos utilizar os recursos do `Linq to Objetcs` do .NET
        var encontrado = (from veiculo in this.Veiculos
                          where veiculo.IdTicket == ticket
                          select veiculo).SingleOrDefault();
        return encontrado;
    }

    public Veiculo PesquisaVeiculoPorPlaca(string placa)
    {
        // Como estamos trabalhando com array de objetos,
        // Podemos utilizar os recursos do `Linq to Objetcs` do .NET
        var encontrado = (from veiculo in this.Veiculos
                          where veiculo.Placa == placa
                          select veiculo).SingleOrDefault();
        return encontrado;
    }

    private string GerarTicket(Veiculo veiculo)
    {
        // Vamos criar um Id aletório para o Ticket usando a Classe GUID e vamos padronizar com o tamanho de 6 caracteres.
        string identificador = new Guid().ToString().Substring(0, 5);
        veiculo.IdTicket = identificador;
        string ticket = "### Ticket Estacionameno Alura ###" +
                       $">>> Identificador: {identificador}" +
                       $">>> Data/Hora de Entrada: {DateTime.Now}" +
                       $">>> Placa Veículo: {veiculo.Placa}" +
                       $">>> Operador: {this.OperadorPatio.Matricula}";
        return ticket;
    }
}