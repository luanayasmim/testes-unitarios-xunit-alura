using ProjetoEstacionamento.Models;

namespace projeto_estacionamento_testes;

public class VeiculoTeste
{
    [Fact]
    public void TestaVeiculoAcelerar()
    {
        //Padrão AAA - (Arrange, Act, Assert)

        //Arrange
        /*
         Nesta etapa nós configuramos tudo o que é necessário para que o nosso teste possa rodar,
         inicializamos variáveis, criamos alguns test doubles como Mocks ou Spies dentre outras coisas
         */
        var veiculo = new Veiculo();

        //Act
        /*
         Esta etapa é onde rodamos de fato o nosso teste. Chamamos alguma função ou método que queremos por a prova.
         */
        veiculo.Acelerar(10);

        //Assert
        /*
         É onde verificamos se a operação realizada na etapa anterior (Act) surtiu o resultado esperado. 
         Assim sabemos se o teste passa ou falha.
         */
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaVeiculoFrear()
    {
        //Arrange
        var veiculo = new Veiculo();
        
        //Act
        veiculo.Frear(10);
        
        //Assert
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }
}