using Com.ThoughtWorks.TDD;

namespace Test
{
    public class MessageGatewayStub : MessageGateway
    {
        public string Recipient { get; private set; }
        public string Content { get; private set; }

        public void Send(string recipient, string content)
        {
            Recipient = recipient;
            Content = content;
        }
    }
}