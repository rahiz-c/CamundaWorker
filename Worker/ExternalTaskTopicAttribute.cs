namespace CamundaWorker.Worker
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ExternalTaskTopicAttribute:Attribute
    {
        public string TopicName { get; }

        public int Retries { get; } = 5;

        public long RetryTimeout { get; } = 10 * 1000;

        public ExternalTaskTopicAttribute(string topicName)
        {
            TopicName = topicName;
        }

        public ExternalTaskTopicAttribute(string topicName, int retries, long retryTimeout)
        {
           TopicName = topicName;
           Retries = retries;
           RetryTimeout = retryTimeout;
        }
    }
}
