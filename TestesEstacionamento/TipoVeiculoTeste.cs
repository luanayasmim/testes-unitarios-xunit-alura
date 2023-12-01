using ProjetoEstacionamento.Models;

namespace projeto_estacionamento_testes;

public class TipoVeiculoTeste
{
    [Fact]
    public void TestaTipoVeiculo()
    {
        //Arrange
        var veiculo = new Veiculo();
        //Act
        //Assert
        Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    }
}
