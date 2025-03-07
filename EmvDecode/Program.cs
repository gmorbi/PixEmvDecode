// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

// Exemplo de payload EMV do PIX
string emvPayload =
    "";

// Processar o payload
Dictionary<string, string> pixData = ParsePixEmv(emvPayload);

// Exibir os dados
Console.WriteLine("Dados do PIX:");
foreach (var item in pixData)
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}

// Exemplo de como acessar campos específicos
string chavePix = GetPixKey(pixData["26"]);
Console.WriteLine($"\nChave PIX: {chavePix}");
Console.WriteLine($"Valor: {pixData.GetValueOrDefault("54", "0.00")}");
Console.WriteLine($"Beneficiário: {pixData["59"]}");
Console.WriteLine($"Cidade: {pixData["60"]}");

static Dictionary<string, string> ParsePixEmv(string emvPayload)
{
    var pixData = new Dictionary<string, string>();
    int index = 0;

    while (index < emvPayload.Length)
    {
        // Extrair o ID (2 dígitos)
        string id = emvPayload.Substring(index, 2);
        index += 2;

        // Extrair o tamanho do valor (2 dígitos)
        int length = int.Parse(emvPayload.Substring(index, 2));
        index += 2;

        // Extrair o valor
        string value = emvPayload.Substring(index, length);
        index += length;

        // Adicionar ao dicionário
        pixData[id] = value;
    }

    return pixData;
}

static string GetPixKey(string payload26)
{
    // O campo 26 contém subcampos (ID 00 e 01)
    var subFields = ParsePixEmv(payload26);
    return subFields["01"]; // A chave PIX está no subcampo 01
}