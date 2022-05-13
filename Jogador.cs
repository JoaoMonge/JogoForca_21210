namespace JogoForca_21210;

public class Jogador
{
    private String nome;
    private int vida;


    private List<Palavra> palavras = new List<Palavra>();
    private String letrasErradas = ""; 


    public Jogador()
    {
        Console.WriteLine("Escreva o seu nome:");
        this.nome = Console.ReadLine();

        Console.WriteLine("Escolha a dificuldade: \n0 - Fácil\n1 - Normal\n2 - Dificil");
        int opcao = Int16.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 0:
                this.vida = 7;
                break;
            case 1:
                this.vida = 6;
                break;
            case 2:
                this.vida = 5;
                break;
            default:
                throw new Exception("Falhou a criação do Jogador parametro inválido");
        }
    }

    private void lerFicheiro()
    {
        using (StreamReader sr = new StreamReader("/Users/joaomonge/RiderProjects/JogoForca_21210/palavras.csv"))
        {
            string line;

            // Read and display lines from the file until 
            // the end of the file is reached. 
            while ((line = sr.ReadLine()) != null)
            {
                String[] splitted = line.Split(';');
                Palavra p = new Palavra(splitted[0], (Categoria)Int16.Parse(splitted[1]));
                palavras.Add(p);
            }
        }
    }

    private Palavra obterPalavraChave()
    {
        //Escolher uma categoria aleatoria
        var rnd = new Random();

//Gerar uma Categoria aleatoria com base no quantidade de valores que este Enumerado têm
        Categoria escolhida = (Categoria)rnd.Next(Enum.GetNames(typeof(Categoria)).Length);
        Console.WriteLine(escolhida);

//Lista para guardar apenas as palavras da categoria selecionada
        List<Palavra> palavrasCategoria = new List<Palavra>();

//Percorrer todas as palavras que estavam no ficheiro e adicionalas à nova lista
        foreach (var pav in palavras)
        {
            if (pav.categoria == escolhida)
            {
                palavrasCategoria.Add(pav);
            }
        }

//Obter uma chave aleatoria (Palavra que o utilizador deve advinhar)
        return palavrasCategoria[rnd.Next(palavrasCategoria.Count)];
    }

    public void jogar()
    {
        lerFicheiro();
        Palavra chave = obterPalavraChave();


//Como as strings são dificeis de trabalha e como vamos receber uma letra de cada vez. A estruta array de caracteres adapta-se melhor ao problema
        char[]
            resultado = new char[chave.palavra
                .Length]; //Criar um array que vai ter as letras que o utilizador for advinhando até ter a palavra completa

//Consoante o tamanho da palavra a advinhar vamos criar _ para cada letra, isto para mostrarmos ao utilizador a palavra e letras que já advinhou. 
        for (int i = 0; i < chave.palavra.Length; i++)
        {
            resultado[i] = '_';
        }


//Ciclo infinito
        while (this.vida > 0)
        {
            //Em cada vida o utilizador pode tentar descobrir uma letra

            //Imprimir o estado atual
            Console.WriteLine("Vidas: {1} Resultado: {0} Letras erradas: {2}", new String(resultado),this.vida,letrasErradas);

            //Caso a palavra já não tenha nenhum _ então paramos o ciclo
            if (!(new String(resultado).Contains("_")))
            {
                Console.WriteLine("Fim de jogo, ganhou!");
                return;
            }


            //Pedimos ao utilizador que insira uma letra
            Console.WriteLine("Digite uma letra: ");
            char lido = Console.ReadLine().ToUpper()[0];


            //Verificamos se a letra existe na palavra e caso exista então coloca a letra substituindo o _ na posicao da mesma.
            for (int j = 0; j < chave.palavra.Length; j++)
            {
                if (chave.palavra.ToUpper()[j] == lido)
                {
                    resultado[j] = lido;
                }
            }

            if (!(new String(resultado).Contains(lido)))
            {
                this.vida -= 1;
                letrasErradas += lido;
            }
          
        }
        
        Console.WriteLine("Fim de jogo, perdeu!");
    }
}