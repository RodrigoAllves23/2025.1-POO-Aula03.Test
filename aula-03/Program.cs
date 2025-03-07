using aula_03;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Televisao tvSala = new Televisao(22f);
Console.WriteLine($"O tamanho da tv é: {tvSala.Tamanho}");

Console.WriteLine($"O volume da tv é: {tvSala.Volume}");
tvSala.AumentarVolume();

Console.WriteLine($"O tamanho da tv é: {tvSala.Tamanho}");


tvSala.AumentarVolume();
Console.WriteLine($"O volume da tv é: {tvSala.Volume}");
tvSala.AumentarVolume();

//Deveria imprimir mudo
tvSala.AlternarModoMudo();

//Deveria imprimir 01
tvSala.AumentarVolume();
Console.WriteLine($"O volume da tv é: {tvSala.Volume}");

//Deveria imprimir mudo
tvSala.AlternarModoMudo();

//Deveria imprimir volume 01
tvSala.AlternarModoMudo();

tvSala.DiminuirVolume();
Console.WriteLine($"O volume da tv é: {tvSala.Volume}");

//Deveria imprimir volume 01
tvSala.AlternarModoMudo();






Console.WriteLine(" ");

Console.WriteLine("=== Teste de Mudo na TV ===");

//Aumenta o volume algumas vezes
tvSala.AumentarVolume();
tvSala.AumentarVolume();
Console.WriteLine($"Volume após aumentar: {tvSala.Volume}");

//Ativar Mudo
tvSala.AlternarModoMudo();
Console.WriteLine("Mudo ativado");
Console.WriteLine($"Volume atual: {tvSala.Volume}(Volume Esperado: 0)");

//Tentar aumentar o volume enquanto esta mudo
tvSala.AumentarVolume();
Console.WriteLine($"Tentativa de Aumentar o volume no Mudo: {tvSala.Volume}(Volume esperado: 0)");

//Desativar Mudo (volume deve voltar ao valor anterior)
tvSala.AlternarModoMudo();
Console.WriteLine($"Mudo desativado");
Console.WriteLine($"Volume restaurado: {tvSala.Volume}");

//Diminuir Volume Normalmente
tvSala.DiminuirVolume();
Console.WriteLine($"Volume apos diminuir: {tvSala.Volume}");

//Ativar mudo novamente
tvSala.AlternarModoMudo();
Console.WriteLine($"Mudo ativado novamente.");
Console.WriteLine($"Volume atual: {tvSala.Volume} (Volume esperado: 0)");

Console.WriteLine(" ");

Console.WriteLine("=== Teste alterando canais ===");

//Aumentar o canal uma vez
tvSala.AumentarCanal();
Console.WriteLine($"O canal atual é: {tvSala.Canal}");
tvSala.AumentarCanal();
tvSala.AumentarCanal();
Console.WriteLine($"O canal atual é: {tvSala.Canal}");

tvSala.DiminuirCanal();
Console.WriteLine($"O canal atual é: {tvSala.Canal}");
tvSala.DiminuirCanal();
tvSala.DiminuirCanal();
Console.WriteLine($"O canal atual é: {tvSala.Canal}");

//Alterando canal com um numero
tvSala.SelecionarCanal(50);
Console.WriteLine($"Canal alterado com numero: {tvSala.Canal}");

//impresão simples sem uso do try-catch
//tvSala.SelecionarCanal(200);

//impressão com try catch
try
{
    tvSala.SelecionarCanal(50);
    Console.WriteLine($"Canal alterado com numero: {tvSala.Canal}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}

try
{
    tvSala.SelecionarCanal(200); // Canal inválido
    Console.WriteLine($"Canal alterado com numero: {tvSala.Canal}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}


