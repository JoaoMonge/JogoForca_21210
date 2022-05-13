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



//Ler Ficheiros CSV

using JogoForca_21210;

using (StreamReader sr = new StreamReader("/Users/joaomonge/RiderProjects/JogoForca_21210/palavras.csv")) {
    string line;

    // Read and display lines from the file until 
    // the end of the file is reached. 
    while ((line = sr.ReadLine()) != null)
    {
        String[] splitted = line.Split(';');
        Palavra p = new Palavra(splitted[0], (Categoria) Int16.Parse(splitted[1]));
        Console.WriteLine(p.categoria);
    }
}

*/

//Categoria sorteada = 