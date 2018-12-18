using System;
using System.Net.Http;
using Xunit;

namespace adc.integration.tests
{
    public class Test: IDisposable
    {
        private readonly HttpClient _httpClient;
        public Test()
        {
            _httpClient = new HttpClient();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        [Fact]
        public void Succeed_when_make_an_api_request()
        {
            var response = _httpClient.GetAsync("http://localhost:8080/api/utc")
                .GetAwaiter()
                .GetResult();

            Assert.NotNull(response);
        }
    }
}
