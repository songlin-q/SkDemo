// See https://aka.ms/new-console-template for more information
#pragma warning disable SKEXP0010
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.Extensions.DependencyInjection;





var zhiPuKey = "dcb061af3cb84187ac3aa5f703899709.OxcLgQNLFP411aWz";

var builder = Kernel.CreateBuilder();
var zhipuEndpoint = new Uri("https://open.bigmodel.cn/api/paas/v4/");
builder.AddOpenAIChatCompletion(
    modelId: "glm-4-flash",
    apiKey: zhiPuKey,
    endpoint: zhipuEndpoint
    );

var kernel = builder.Build();

while (true)
{

    Console.WriteLine("请输入你的问题:");
    var redContext = Console.ReadLine();


    if (redContext.ToString() == "bye")
    {

        Console.WriteLine("感谢你的使用，再见！");
        return;
    }


    var response = await kernel.InvokePromptAsync(redContext);


    Console.WriteLine($"回复内容:{response}");

}


