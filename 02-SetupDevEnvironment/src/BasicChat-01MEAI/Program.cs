using Azure;
using Azure.AI.Inference;
using Microsoft.Extensions.AI;

IChatClient client = new ChatCompletionsClient(
        endpoint: new Uri("https://models.github.ai/inference"),
        new AzureKeyCredential(Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? throw new InvalidOperationException("Missing GITHUB_TOKEN environment variable. Ensure you followed the instructions to setup a GitHub Token to use GitHub Models.")))
        .AsChatClient("openai/gpt-4.1");

var response = await client.GetResponseAsync("デジタル・ナレッジ株式会社の情報を教えてください。");

Console.WriteLine(response.Message);