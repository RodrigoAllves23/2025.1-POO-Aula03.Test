namespace aula_03;

public class Televisao
{
    //O método construtor possui o mesmo nome da classe. 
    // Ele não possui retorno (nem mesmo o void)
    //Este método é executado sempre que uma instancia da classe
    //é criada.
    //Por padrão, o C# cria um método construtor publico vazio,
    //mas podemos criar métodos construtores com outras
    //visibilidades e recebendo parametros, se necessário.
    public Televisao(float tamanho)
    {
        if (tamanho < TAMANHO_MINIMO || tamanho > TAMANHO_MAXIMO)
        {
            throw new ArgumentOutOfRangeException(nameof(tamanho), $"O tamanho({tamanho}) não é suportado!");
            //Console.WriteLine($"O tamanho ({tamanho}) não é suportado! Definindo para {TAMANHO_MINIMO}.");
            //tamanho = TAMANHO_MINIMO; // Define um valor válido automaticamente
        }
        Tamanho = tamanho;
        Volume = VOLUME_PADRAO;
        _estaMudo = false; // Adicionado: TV começa sem estar muda
        Canal = CANAL_INICIAL; //Adicionado: variavel canal inicial
    }

    //Optamos pela utilização da constante para tornar o código mais legível.
    private const float TAMANHO_MINIMO = 22;
    private const float TAMANHO_MAXIMO = 80;
    private const int VOLUME_MAXIMO = 12;
    private const int VOLUME_MINIMO = 0;
    private const int VOLUME_PADRAO = 10;

    private int _ultimoVolume = VOLUME_PADRAO;
    private bool _estaMudo; // Alterado: renomeado para seguir convenção de atributos privados

    private const int CANAL_INICIAL = 5;
    private const int CANAL_MAXIMO = 199;
    private const int CANAL_MINIMO = 1;



    //Get: permite que seja executada a 
    //leitura do valor atual da propriedade
    //Set: permite que seja atibuído um 
    //valor para a propriedade

    //classes, propriedades e métodos possuem modificadores de acesso
    //public: visiveis a todo o projeto
    //internal: visiveis somente no namespace - padrão
    //protected: visiveis somente na classe e nas classes que herdam
    //private: visiveis somente na classe que foram criados
    public float Tamanho { get; }
    public int Resolucao { get; set; }
    public int Volume { get; private set; }
    public int Canal { get; set; }
    public bool Estado { get; set; }

    public void AumentarVolume()
    {
        if (_estaMudo) return; // Alterado: impede aumento de volume no modo mudo
        
        if (Volume < VOLUME_MAXIMO)
        {
            Volume++;
            _ultimoVolume = Volume;
        }
        else
        {
            Console.WriteLine("A TV já está no volume máximo permitido");
        }

    }

    public void DiminuirVolume()
    {
        if (_estaMudo) return;

            if (Volume > VOLUME_MINIMO)
            {
                Volume--;
                _ultimoVolume = Volume;
            }
            else
            {
                Console.WriteLine("A TV já está no volume mínimo permitido");
            }
    }

    //Funcionalidade mudo
    //1 botao de mudo -  toggle (on/off)
    //Volume = x; Volume = 0; Volume = x;
    public void AlternarModoMudo()
    {
        if (_estaMudo)
        {
            // Se estava mudo, restauramos o volume original
            //_ultimoVolume = Volume; //codigo professor
            //Volume = VOLUME_MINIMO; //codigo professor
            Volume = _ultimoVolume;
            Console.WriteLine($"Som restaurado. Volume atual: {Volume}");
        }
        else
        {
            // Se não estava mudo, salvamos o volume atual e zeramos
            //Volume = _ultimoVolume; //codigo professor
            _ultimoVolume = Volume;
            Volume = VOLUME_MINIMO;
            Console.WriteLine("A TV está no modo MUTE.");
        }
        _estaMudo = !_estaMudo; // Alterado: alterna entre mudo e normal
    }

    //Funcionalidade Alterando Canais 
    public void AumentarCanal()
    {
        if (Canal < CANAL_MAXIMO)
        {
            Canal++;
        }
        else
        {
            Canal = CANAL_MINIMO;
        }
        Console.WriteLine($"Canal alterado para {Canal}");// Alterado: Mostra o canal atual
    }

    public void DiminuirCanal()
    {
        if (Canal > CANAL_MINIMO)
        {
            Canal--;
        }
        else
        {
            Canal = CANAL_MAXIMO;
        }
        Console.WriteLine($"Canal alterado para {Canal}"); // Alterado: Mostra o canal atual
    }

    //Funcionalidade Selecionar canal pelo numero 
    public void SelecionarCanal(int numero)
    {
        if (numero >= CANAL_MINIMO && numero <= CANAL_MAXIMO)
        {
            Canal = numero;
        }
        else
        {
            //codigo menos legivel
            //throw new ArgumentOutOfRangeException(nameof(numero), "Canal não encontrado. Canais disponiveis no momento estão entre: " + CANAL_MINIMO +"e"+ CANAL_MAXIMO + "!!!" );

            //Código com legibilidade melhor, usa o try-catch ERRO
            throw new ArgumentOutOfRangeException(nameof(numero),
            $"Canal não encontrado. Canais disponíveis no momento estão entre {CANAL_MINIMO} e {CANAL_MAXIMO}.");

            //Impresão simples não usa o try-catch
            //Console.WriteLine($"Erro: Canal {numero} não encontrado. Canais disponíveis: {CANAL_MINIMO} a {CANAL_MAXIMO}.");

        }
    }
}