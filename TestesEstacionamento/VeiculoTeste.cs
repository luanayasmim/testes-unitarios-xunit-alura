using ProjetoEstacionamento.Models;
using Xunit.Abstractions;

namespace projeto_estacionamento_testes;

public class VeiculoTeste : IDisposable
{
    //Setup
    public ITestOutputHelper _output;
    private Veiculo _veiculo;

    public VeiculoTeste(ITestOutputHelper output)
    {
        //Exibindo mensagem no console de teste (Standard output)
        _output = output;
        _output.WriteLine("Construtor invocado");

        _veiculo = new Veiculo();
    }

    //A propriedade DisplayName permite adicionar um nome de exibi��o para o teste
    //[Fact(DisplayName = "Teste n�1")]
    //[Trait("Funcionalidade", "Acelerar")]
    [Fact]
    public void TestaVeiculoAcelerarComParametro10()
    {
        //Padr�o AAA - (Arrange, Act, Assert)

        //Arrange
        /*
         Nesta etapa n�s configuramos tudo o que � necess�rio para que o nosso teste possa rodar,
         inicializamos vari�veis, criamos alguns test doubles como Mocks ou Spies dentre outras coisas
         */
        //var veiculo = new Veiculo();

        //Act
        /*
         Esta etapa � onde rodamos de fato o nosso teste. Chamamos alguma fun��o ou m�todo que queremos por a prova.
         */
        _veiculo.Acelerar(10);

        //Assert
        /*
         � onde verificamos se a opera��o realizada na etapa anterior (Act) surtiu o resultado esperado. 
         Assim sabemos se o teste passa ou falha.
         */
        Assert.Equal(100, _veiculo.VelocidadeAtual);
    }

    //[Fact(DisplayName = "Teste n�2")]
    //[Trait("Funcionalidade", "Frear")] //Anota��o para agrupamento
    [Fact]
    public void TestaVeiculoFrearComParametro10()
    {
        //Arrange
        //var veiculo = new Veiculo();

        //Act
        _veiculo.Frear(10);
        
        //Assert
        Assert.Equal(-150, _veiculo.VelocidadeAtual);
    }

    //O skip faz com que o gerenciador de teste ignore(ou pule) o teste
    //[Fact(DisplayName = "Teste n�3" ,Skip = "O teste ainda n�o foi implementado. Ignorar")]
    [Fact(Skip = "O teste ainda n�o foi implementado. Ignorar")]
    public void ValidaNomeProprietarioVeiculo()
    {

    }

    //[Theory]
    //[ClassData(typeof(Veiculo))]
    //public void TestaVeiculoClass(Veiculo modelo)
    //{
    //    var veiculo = new Veiculo();

    //    veiculo.Acelerar(10);
    //    modelo.Acelerar(10);

    //    Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
    //}

    [Fact]
    public void ValidaFichaInformacao()
    {
        //Arrange
        _veiculo = new Veiculo
        {
            Proprietario = "Luana Yasmim",
            Tipo = TipoVeiculo.Automovel,
            Modelo = "Fusca",
            Cor = "Azul",
            Placa = "LUA-2003"
        };

        //Act
        string dados = _veiculo.ToString();

        //Assert
        Assert.Contains("Ficha do Ve�culo:", dados);
    }

    //Verificando o uso de exce��es
    [Fact]
    public void TestaNomeProprietarioComMenosDeTresCaracteres()
    {
        //Arrange
        var nomeProprietario = "la";

        //Assert
        Assert.Throws<FormatException>(
            //Act
            () => new Veiculo(nomeProprietario)
        );
    }

    [Fact]
    public void TestaExcecaoDoQuartoCaractereDaPlaca()
    {
        //Arrange
        var placa = "ASDF1234";

        //Act
        var mensagem = Assert.Throws<FormatException>(() => new Veiculo().Placa = placa);

        //Assert
        Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
    }

    //M�todo utilizado para encerrar objetos e vari�veis
    public void Dispose()
    {
        _output.WriteLine("Dispose invocado");
    }
}