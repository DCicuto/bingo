using System;

int numeroMaxSorteio = 99;
int rodada = 0;
int qtdLinhas = 5;
int qtdColunas = 5;
int pontosJogador1 = 0, pontosJogador2 = 0;
int[] numerosSorteados = new int[numeroMaxSorteio];
int[] numeroAtual = new int[numeroMaxSorteio];

// declarei a matriz das cartelas dos jogadores 
int[,] cartelaJogador1 = new int[qtdLinhas, qtdColunas];
int[,] cartelaJogador2 = new int[qtdLinhas, qtdColunas];

bool existeLinhaCompleta = false;
bool existeColunaCompleta = false;
bool existeVencedor = false;

int[] gerarNumerosSemRepeticoes(int qtdNumeros)
{
    int[] numeros = new int[qtdNumeros];

    int numero = new Random().Next(1, numeroMaxSorteio + 1);
    numeros[0] = numero;

    for (int i = 1; i < qtdNumeros; i++)
    {
        numero = new Random().Next(1, numeroMaxSorteio + 1);
        for (int j = 0; j < i; j++)
        {
            if (numero == numeros[j])
            {
                i--;
                break;
            }
            else
            {
                numeros[i] = numero;
            }
        }
    }

    return numeros;
}


int[,] preencheCartela() //função que preenche a cartela com 25 numeros aleatorios
{
    int[] numeros = gerarNumerosSemRepeticoes(25);
    int posicaoNumero = 0;

    int[,] cartela = new int[qtdLinhas, qtdColunas];
   
    for (int linha = 0; linha < qtdLinhas; linha++)
    {
        for (int coluna = 0; coluna < qtdColunas; coluna++)
        {
            cartela[linha, coluna] = numeros[posicaoNumero];
            posicaoNumero++;
        }
    }

    return cartela;
}
//abaixo função que imprime valor das cartelas
void imprimeCartela(int[,] cartela, string titulo)
{
    Console.WriteLine(titulo);
    for (int linha = 0; linha < qtdLinhas; linha++)

    {
        Console.WriteLine();
        for (int coluna = 0; coluna < qtdColunas; coluna++)
        {
            Console.Write(cartela[linha, coluna] + " ");
        }
    }
}
//abaixo preenche os numeros sorteados e guarda. 
//chamei os numeros das linhas de item. (arrays são as linhas das cartelas)
void sortearNumeros()
{
    for (int item = 0; item < numeroMaxSorteio; item++)
    {
        Random rand = new Random();// Sorteia um número que ainda não foi sorteado
        numerosSorteados[item] = new Random().Next(1, numeroMaxSorteio + 1);
    }
}

// marcar a cartela ja existente caso encontre o numero, substituindo o numero original por -1
void marcaNumero(int[,] cartela, int numero)
{
    for (int linha = 0; linha < qtdLinhas; linha++)
    {
        for (int coluna = 0; coluna < qtdColunas; coluna++)
        {
            if (cartela[linha, coluna] == numero)
            {
                cartela[linha, coluna] = -1;
                return;
            }
        }
    }
}

bool verificaLinha(int[,] cartela)
{
    // verificar as linhas
    for (int linha = 0; linha < qtdLinhas; linha++)
    {
        for (int coluna = 0; coluna < qtdColunas; coluna++)
        {
            if (cartela[linha, coluna] != -1)
            {
                // caso encontre algum valor na linha que seja diferente de -1 (numero sorteado),
                // ele ira retornar false e parar essa busca
                return false;
            }
        }
        // caso todos os numeros sejam iguais a -1, a linha esta completa e retorna true
        return true;
    }
    //Caso a cartela nào entre na iteração vai retornar falso
    return false;
}

bool verificaColuna(int[,] cartela)
{
    //verficiar colunas
    for (int coluna = 0; coluna < qtdColunas; coluna++)
    {
        for (int linha = 0; linha < qtdLinhas; linha++)
        {
            if (cartela[linha, coluna] != -1)   
            {
                // caso encontrar algum valor na coluna que seja diferente de -1 (numero sorteado),
                // ele ira retornar false e parar essa busca
                return false;
            }
        }
        // caso todos os numeros sejam iguais a -1, a coluna esta completa e retorna true
        return true;
    }
    //Caso a cartela nào entre na iteração vai retornar falso
    return false;
}

bool verificarCartelaCheia(int[,] cartela)
{
    // verificar as linhas
    for (int linha = 0; linha < qtdLinhas; linha++)
    {
        for (int coluna = 0; coluna < qtdColunas; coluna++)
        {
            if (cartela[linha, coluna] != -1)
            {
                // caso encontrar algum valor na linha que seja diferente de -1 (numero sorteado),
                // ele ira retornar false e parar essa busca
                return false;
            }
        }
    }
    // caso todos os numeros sejam iguais a -1, a linha esta completa e retorna true
    return true;
    //Caso a cartela nào entre na iteração vai retornar falso
    // return false;
}

void checarCartelas()
{
    if (!existeLinhaCompleta)
    {
        bool jogador1LinhaCompleta = verificaLinha(cartelaJogador1);
        bool jogador2LinhaCompleta = verificaLinha(cartelaJogador2);
        if (jogador1LinhaCompleta)
        {
            pontosJogador1 = pontosJogador1 + 1;
            existeLinhaCompleta = true;

        }
        else if (jogador2LinhaCompleta)
        {
            pontosJogador2 = pontosJogador2 + 1;
            existeLinhaCompleta = true;

        }
    }

    if (!existeColunaCompleta)
    {
        bool jogador1ColunaCompleta = verificaColuna(cartelaJogador1);
        bool jogador2ColunaCompleta = verificaColuna(cartelaJogador2);
        if (jogador1ColunaCompleta)
        {
            pontosJogador1 = pontosJogador1 + 1;
            existeColunaCompleta = true;

        }
        else if (jogador2ColunaCompleta)
        {
            pontosJogador2 = pontosJogador2 + 1;
            existeColunaCompleta = true;

        }
    }

    if (existeLinhaCompleta && existeColunaCompleta)
    {
        bool jogador1CartelaCompleta = verificarCartelaCheia(cartelaJogador1);
        bool jogador2CartelaCompleta = verificarCartelaCheia(cartelaJogador2);
        if (jogador1CartelaCompleta)
        {
            pontosJogador1 = pontosJogador1 + 5;
            Console.WriteLine("\n\nO jogador 1 foi o vencedor com: " + pontosJogador1 + " pontos.");
            existeVencedor = true;
        }
        else if (jogador2CartelaCompleta)
        {
            pontosJogador2 = pontosJogador2 + 5;
            Console.WriteLine("\n\nO jogador 2 foi o vencedor com: " + pontosJogador2 + " pontos.");
            existeVencedor = true;
        }
    }

    /*if (pontosJogador1 > pontosJogador2)
    {
        Console.WriteLine("\n\nO jogador 1 foi o vencedor com: " + pontosJogador1 + " pontos.");
        existeVencedor = true;
    }
    else if (pontosJogador2 > pontosJogador1)
    {
        Console.WriteLine("\n\nO jogador 2 foi o vencedor com: " + pontosJogador2 + " pontos.");
        existeVencedor = true;
    }*/
}

void bingo()
{
    // chamando as funções de controle do jogo

    //  chamando funcoes para preencher as cartelas
    cartelaJogador1 = preencheCartela();
    cartelaJogador2 = preencheCartela();

    // chamando funcao para sortear os numeros
    numerosSorteados = gerarNumerosSemRepeticoes(numeroMaxSorteio);

    //abaixo chamando a função que imprime as cartelas
    imprimeCartela(cartelaJogador1, "\n\n Cartela jogador 1");
    imprimeCartela(cartelaJogador2, "\n\n Cartela jogador 2");

    for (int indice = 0; indice < numeroMaxSorteio; indice++)
    {
        if (!existeVencedor)
        {
            numeroAtual[indice] = numerosSorteados[indice];
            rodada++;

            marcaNumero(cartelaJogador1, numeroAtual[indice]);
            marcaNumero(cartelaJogador2, numeroAtual[indice]);

            checarCartelas();
        }
    }

    

    // for para chamar as funcoes de marcar os numeros ja sorteados nas cartelas dos jogadores
    /*for (int item = 0; item < numeroMaxSorteio; item++)
    {
        
    }*/

    //abaixo chamando a função que imprime as cartelas marcadas
    imprimeCartela(cartelaJogador1, "\n\n Cartela marcada jogador 1");
    imprimeCartela(cartelaJogador2, "\n\n Cartela marcada jogador 2");


    
}

// chamada da funcao para rodar o jogo bingo
bingo();
Console.ReadLine();


