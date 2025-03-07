using aula_03;

namespace aula_03.Test;

[TestClass]
public class TelevisaoTest
{
    [TestMethod]
    public void Dado_Tamanho_21_Deve_Retornar_Excecao()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Televisao(21f), $"O tamanho(21) não é suportado!");
    }

    [TestMethod]
    public void Dado_Tamanho_81_Deve_Retornar_Excecao()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Televisao(81f), $"O tamanho(81) não é suportado!");
    }

    [TestMethod]
    public void Dado_Tamanho_25_Deve_Criar_Instancia()
    {
        const float tamanho = 25f;

        Televisao televisao = new Televisao(tamanho);
        Assert.IsInstanceOfType(televisao, typeof(Televisao));
        Assert.AreEqual(tamanho, televisao.Tamanho);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Volume_10()
    {
        const int volumePadrao = 10;

        Televisao televisao = new Televisao(25f);
        Assert.AreEqual(volumePadrao, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_11_Apos_Aumentar_Volume()
    {
        Televisao televisao = new Televisao(25f);
        televisao.AumentarVolume();
        Assert.AreEqual(11, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_09_Apos_Diminuir_Volume()
    {
        Televisao televisao = new Televisao(25f);
        televisao.DiminuirVolume();
        Assert.AreEqual(09, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_0_Ao_Mutar()
    {
        Televisao televisao = new Televisao(25f);
        televisao.AlternarModoMudo();
        Assert.AreEqual(0, televisao.Volume);
    }


    [TestMethod]
    public void Deve_Restaurar_Volume_Anterior_Ao_Desmutar()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo(); // Muta
        televisao.AlternarModoMudo(); // Desmuta

        Assert.AreEqual(volumeInicial, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Manter_Estado_Correto_Com_Multiplas_Alternancias_Mudo()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo(); // Muta
        Assert.AreEqual(0, televisao.Volume);

        televisao.AlternarModoMudo(); // Desmuta
        Assert.AreEqual(volumeInicial, televisao.Volume);

        televisao.AlternarModoMudo(); // Muta novamente
        Assert.AreEqual(0, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ignorar_Mudancas_Volume_Durante_Mudo()
    {
        Televisao televisao = new Televisao(25f);

        televisao.AlternarModoMudo();
        televisao.AumentarVolume();
        televisao.DiminuirVolume();

        Assert.AreEqual(0, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Manter_Mudo_Ao_Tentar_Alterar_Volume()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo();
        televisao.AumentarVolume();

        Assert.AreEqual(0, televisao.Volume);

        televisao.AlternarModoMudo();
        Assert.AreEqual(volumeInicial, televisao.Volume);
    }

    //Testes Alternando Canais
    [TestMethod]
    public void AumentarCanal_DeveIncrementarCanal()
    {
        var tv = new Televisao(32);
        int canalInicial = tv.Canal;

        tv.AumentarCanal();

        Assert.AreEqual(canalInicial + 1, tv.Canal);
    }

    [TestMethod]
    public void AumentarCanal_DeveVoltarParaMinimo_QuandoAtingirMaximo()
    {
        var tv = new Televisao(32);
        tv.Canal = 199;

        tv.AumentarCanal();

        Assert.AreEqual(1, tv.Canal);
    }

    [TestMethod]
    public void DiminuirCanal_DeveDecrementarCanal()
    {
        var tv = new Televisao(32);
        tv.Canal = 10;

        tv.DiminuirCanal();

        Assert.AreEqual(9, tv.Canal);
    }

    [TestMethod]
    public void DiminuirCanal_DeveVoltarParaMaximo_QuandoAtingirMinimo()
    {
        var tv = new Televisao(32);
        tv.Canal = 1;

        tv.DiminuirCanal();

        Assert.AreEqual(199, tv.Canal);
    }

}