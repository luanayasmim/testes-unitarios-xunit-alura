using ProjetoEstacionamento.Models;

namespace projeto_estacionamento_testes;

public class VeiculoTeste
{
    [Fact]
    public void TestaVeiculoAcelerar()
    {
        //Padr�o AAA - (Arrange, Act, Assert)

        //Arrange
        /*
         Nesta etapa n�s configuramos tudo o que � necess�rio para que o nosso teste possa rodar,
         inicializamos vari�veis, criamos alguns test doubles como Mocks ou Spies dentre outras coisas
         */
        var veiculo = new Veiculo();

        //Act
        /*
         Esta etapa � onde rodamos de fato o nosso teste. Chamamos alguma fun��o ou m�todo que queremos por a prova.
         */
        veiculo.Acelerar(10);

        //Assert
        /*
         � onde verificamos se a opera��o realizada na etapa anterior (Act) surtiu o resultado esperado. 
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