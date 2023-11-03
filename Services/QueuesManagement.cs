using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using ImageProcessing2.API.Services.Interfaces;

//namespace ImageProcessing2.API.Services;

public class QueuesManagement : IQueuesManagement
{
    public async Task<bool> SendMessage<T>(T serviceMessage, string queue, string connectionString)
    {
        var queueClient = new QueueClient(connectionString, queue);

        var msgBody = JsonSerializer.Serialize(serviceMessage);

        await queueClient.SendMessageAsync(msgBody);

        return true;
    }
}