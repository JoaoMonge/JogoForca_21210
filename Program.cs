/*
String chave = "rato"; // A palavra que o utilizador deve adivinhar

//Como as strings são dificeis de trabalha e como vamos receber uma letra de cada vez. A estruta array de caracteres adapta-se melhor ao problema
char[] resultado = new char[chave.Length]; //Criar um array que vai ter as letras que o utilizador for advinhando até ter a palavra completa

//Consoante o tamanho da palavra a advinhar vamos criar _ para cada letra, isto para mostrarmos ao utilizador a palavra e letras que já advinhou. 
for (int i = 0; i < chave.Length; i++)
{
    resultado[i] = '_';
} 


//Ciclo infinito
while (true)
{
    
    //Em cada vida o utilizador pode tentar descobrir uma letra
    
    //Imprimir o estado atual
    Console.WriteLine("Resultado: {0}",new String(resultado));
    
    //Caso a palavra já não tenha nenhum _ então paramos o ciclo
    if (!(new String(resultado).Contains("_")))
    {
        break;
    }

    
    //Pedimos ao utilizador que insira uma letra
    Console.WriteLine("Digite uma letra: ");
    char lido = Console.ReadLine()[0];
    
    
    //Verificamos se a letra existe na palavra e caso exista então coloca a letra substituindo o _ na posicao da mesma.
    for (int j = 0; j < chave.Length; j++)
    {
        if (chave[j] == lido)
        {
            resultado[j] = lido;
        }
    }

   
}


*/
//Ler Ficheiros CSV

using JogoForca_21210;

List<Palavra> palavras = new List<Palavra>();

using (StreamReader sr = new StreamReader("/Users/joaomonge/RiderProjects/JogoForca_21210/palavras.csv")) {
    string line;

    // Read and display lines from the file until 
    // the end of the file is reached. 
    while ((line = sr.ReadLine()) != null)
    {
        String[] splitted = line.Split(';');
        Palavra p = new Palavra(splitted[0], (Categoria) Int16.Parse(splitted[1]));
        palavras.Add(p);
    }
}


//Escolher uma categoria aleatoria
var rnd = new Random();
//Gerar uma Categoria aleatoria com base no quantidade de valores que este Enumerado têm
Categoria escolhida = (Categoria) rnd.Next(Enum.GetNames(typeof(Categoria)).Length);
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
Palavra chave = palavrasCategoria[rnd.Next(palavrasCategoria.Count)];

Console.WriteLine(chave.palavra);