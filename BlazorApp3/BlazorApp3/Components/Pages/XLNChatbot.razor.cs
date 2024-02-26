using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;

namespace BlazorApp3.Components.Pages
{   
    partial class XLNChatbot
    {
        List<Message> messages = new List<Message>();
        string textInput = string.Empty;

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        public class Message // message stored as an object to hold content and submission time
        {
            public string Content = string.Empty;
            public DateTime SubmissionTime { get; set; }
        }
        private async Task SendMessage(string content)
        {
            //Console.WriteLine("Sending message: " + content);
            //await Task.Delay(1);
            Console.WriteLine("Sending message: " + content);
            if (!string.IsNullOrEmpty(content))
            {
                var message = new Message
                {
                    Content = content,
                    SubmissionTime = DateTime.Now
                };
                messages.Add(message);
                textInput = string.Empty; // clears input after submit
                await Task.Delay(1);
                await JSRuntime.InvokeVoidAsync("scrollToBottom"); //auto scroll to bottom with javascript
            }
        }
        void OnKeyUp(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                SendMessage(textInput);
            }
        }

        private string hoveredMessage = string.Empty;
        private string currentTime = string.Empty;

        private void ShowTime(DateTime submissionTime)
        {
            hoveredMessage = submissionTime.ToString("HH:mm:ss");
            currentTime = DateTime.Now.ToString("HH:mm:ss");
            StateHasChanged();
        }

        private void ClearTime()
        {
            hoveredMessage = string.Empty; // clears when leaving message hover
            currentTime = string.Empty;
        }
    }
}

