using ProjetoEstacionamento.Models;
using Xunit.Abstractions;

namespace projeto_estacionamento_testes;

public class PatioTeste : IDisposable
{
    //Setup
    public ITestOutputHelper _output;
    private Veiculo _veiculo;
    private Patio _estacionamento;
    private Operador _operador;

    public PatioTeste(ITestOutputHelper output)
    {
        //Exibindo mensagem no console de teste (Standard output)
        _output = output;
        _output.WriteLine("Construtor invocado");

        _veiculo = new Veiculo();
        _operador = new Operador();
        _estacionamento = new Patio();

        _operador.Nome = "Arthur";
    }

    [Fact]
    public void ValidaFaturamentoEstacionamentoComUmVeiculo()
    {
        //Arrange
        //var estacionamento = new Patio();
        //var veiculo = new Veiculo();
        _veiculo.Proprietario = "Luana Yasmim";
        _veiculo.Tipo = TipoVeiculo.Automovel;
        _veiculo.Modelo = "Fusca";
        _veiculo.Cor = "Azul";
        _veiculo.Placa = "lua-2003";

        _estacionamento.Operador = _operador;
        
        _estacionamento.RegistrarEntradaVeiculo(_veiculo);
        _estacionamento.RegistrarSaidaVeiculo(_veiculo.Placa);

        //Act
        double faturamento = _estacionamento.TotalFaturado();

        //Assert
        Assert.Equal(2, faturamento);

    }

    [Theory]
    [InlineData("Luana Yasmim", "ASD-1234", "Azul", "Fusca")]
    [InlineData("Fernanda", "QWE-7890", "Prata", "Jeep")]
    [InlineData("Severina", "RTY-7264", "Vermelho", "Idea")]
    [InlineData("José Miguel", "GHJ-5678", "Vermelho", "Argo")]
    public void ValidaFaturamentoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
    {
        //Arrange
        //var estacionamento = new Patio();

        //var veiculo = new Veiculo();
        _veiculo.Proprietario = proprietario;
        _veiculo.Tipo = TipoVeiculo.Automovel;
        _veiculo.Modelo = modelo;
        _veiculo.Cor = cor;
        _veiculo.Placa = placa;

        _estacionamento.Operador = _operador;

        _estacionamento.RegistrarEntradaVeiculo(_veiculo);
        _estacionamento.RegistrarSaidaVeiculo(_veiculo.Placa);

        //Act
        double faturamento = _estacionamento.TotalFaturado();

        //Assert
        Assert.Equal(2, faturamento);

    }

    //Princípios do TDD
    /*
     1) Implementar um teste que falhe
     2) Não escrever mais nada além do necessário para um teste falhar
     3) Não escrever nada além do necessário para o teste passar
     */

    [Theory]
    [InlineData("Luana Yasmim", "ASD-1234", "Azul", "Fusca")]
    public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string proprietario, string placa, string cor, string modelo)
    {
        //Arrange
        //var estacionamento = new Patio();

        //var veiculo = new Veiculo();
        _veiculo.Proprietario = proprietario;
        _veiculo.Tipo = TipoVeiculo.Automovel;
        _veiculo.Modelo = modelo;
        _veiculo.Cor = cor;
        _veiculo.Placa = placa;

        _estacionamento.Operador = _operador;

        _estacionamento.RegistrarEntradaVeiculo(_veiculo);

        //Act
        var consultado = _estacionamento.PesquisaVeiculo(_veiculo.IdTicket);

        //Assert
        Assert.Contains("### Ticket Estacionamento ###", consultado.Ticket);
    }

    [Fact]
    public void AlterarDadosVeiculo()
    {
        //Arrage
        //var estacionamento = new Patio();
        //var veiculo = new Veiculo();

        _veiculo.Proprietario = "Luana Yasmim";
        _veiculo.Tipo = TipoVeiculo.Automovel;
        _veiculo.Modelo = "Fusca";
        _veiculo.Cor = "Azul";
        _veiculo.Placa = "lua-2003";

        _estacionamento.Operador = _operador;

        _estacionamento.RegistrarEntradaVeiculo(_veiculo);

        //Veiculo Alterado
        var veiculoAlterado = new Veiculo();
        veiculoAlterado.Proprietario = "Luana Yasmim";
        veiculoAlterado.Tipo = TipoVeiculo.Automovel;
        veiculoAlterado.Modelo = "Fusca";
        veiculoAlterado.Cor = "Branco";
        veiculoAlterado.Placa = "lua-2003";

        //Act
        var alterado = _estacionamento.AlterarDadosVeiculo(veiculoAlterado);

        //Assert
        Assert.Equal(alterado.Cor, veiculoAlterado.Cor);

    }

    public void Dispose()
    {
        _output.WriteLine("Dispose invocado");
    }
}