using ProjetoEstacionamento.Models;

namespace projeto_estacionamento_testes;

public class PatioTeste
{
    [Fact]
    public void ValidaFaturamento()
    {
        //Arrange
        var estacionamento = new Patio();
        var veiculo = new Veiculo();
        veiculo.Proprietario = "Luana Yasmim";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Modelo = "Fusca";
        veiculo.Cor = "Azul";
        veiculo.Placa = "lua-2003";

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        //Act
        double faturamento = estacionamento.TotalFaturado();

        //Assert
        Assert.Equal(2, faturamento);

    }

    [Theory]
    [InlineData("Luana Yasmim", "ASD-1234", "Azul", "Fusca")]
    [InlineData("Fernanda", "QWE-7890", "Prata", "Jeep")]
    [InlineData("Severina", "RTY-7264", "Vermelho", "Idea")]
    [InlineData("José Miguel", "GHJ-5678", "Vermelho", "Argo")]
    public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
    {
        //Arrange
        var estacionamento = new Patio();

        var veiculo = new Veiculo();
        veiculo.Proprietario = proprietario;
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Modelo = modelo;
        veiculo.Cor = cor;
        veiculo.Placa = placa;

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        //Act
        double faturamento = estacionamento.TotalFaturado();

        //Assert
        Assert.Equal(2, faturamento);

    }

}
