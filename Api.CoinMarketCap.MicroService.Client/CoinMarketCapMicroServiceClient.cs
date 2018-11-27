﻿//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v12.0.1.0 (NJsonSchema v9.12.3.0 (Newtonsoft.Json v11.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

namespace Api.CoinMarketCap.MicroService.Client
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "12.0.1.0 (NJsonSchema v9.12.3.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class CoinMarketCapMicroServiceClient
    {
        private string _baseUrl = "";
        private System.Net.Http.HttpClient _httpClient;
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

        public CoinMarketCapMicroServiceClient(string baseUrl, System.Net.Http.HttpClient httpClient)
        {
            BaseUrl = baseUrl;
            _httpClient = httpClient;
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(() =>
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<CryptocurrencyInfoResponse> InfoAsync(string ids, string symbols)
        {
            return InfoAsync(ids, symbols, System.Threading.CancellationToken.None);
        }

        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task<CryptocurrencyInfoResponse> InfoAsync(string ids, string symbols, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1/Cryptocurrency/Info?");
            if (ids != null)
            {
                urlBuilder_.Append("ids=").Append(System.Uri.EscapeDataString(ConvertToString(ids, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (symbols != null)
            {
                urlBuilder_.Append("symbols=").Append(System.Uri.EscapeDataString(ConvertToString(symbols, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var client_ = _httpClient;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(CryptocurrencyInfoResponse);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<CryptocurrencyInfoResponse>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }

                        return default(CryptocurrencyInfoResponse);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<CryptocurrencyQuotesResponse> QuotesLatestAsync(string ids, string symbols, FiatCurrency? convert)
        {
            return QuotesLatestAsync(ids, symbols, convert, System.Threading.CancellationToken.None);
        }

        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task<CryptocurrencyQuotesResponse> QuotesLatestAsync(string ids, string symbols, FiatCurrency? convert, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1/Cryptocurrency/QuotesLatest/quotes/latest?");
            if (ids != null)
            {
                urlBuilder_.Append("ids=").Append(System.Uri.EscapeDataString(ConvertToString(ids, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (symbols != null)
            {
                urlBuilder_.Append("symbols=").Append(System.Uri.EscapeDataString(ConvertToString(symbols, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (convert != null)
            {
                urlBuilder_.Append("convert=").Append(System.Uri.EscapeDataString(ConvertToString(convert, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var client_ = _httpClient;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(CryptocurrencyQuotesResponse);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<CryptocurrencyQuotesResponse>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }

                        return default(CryptocurrencyQuotesResponse);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is System.Enum)
            {
                string name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value;
                        }
                    }
                }
            }
            else if (value is bool)
            {
                return System.Convert.ToString(value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[])value);
            }
            else if (value != null && value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            return System.Convert.ToString(value, cultureInfo);
        }
    }



    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.12.3.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CoinMarketCapAPIResponse
    {
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Status Status { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static CoinMarketCapAPIResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CoinMarketCapAPIResponse>(data);
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.12.3.0 (Newtonsoft.Json v11.0.0.0)")]
    public abstract partial class CoinMarketCapAPIResponseOfDictionaryOfStringAndCryptocurrencyInfo : CoinMarketCapAPIResponse
    {
        [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, CryptocurrencyInfo> Data { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static CoinMarketCapAPIResponseOfDictionaryOfStringAndCryptocurrencyInfo FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CoinMarketCapAPIResponseOfDictionaryOfStringAndCryptocurrencyInfo>(data);
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.12.3.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CryptocurrencyInfoResponse : CoinMarketCapAPIResponseOfDictionaryOfStringAndCryptocurrencyInfo
    {
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static CryptocurrencyInfoResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CryptocurrencyInfoResponse>(data);
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.12.3.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CryptocurrencyInfo
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("symbol", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Symbol { get; set; }

        [Newtonsoft.Json.JsonProperty("category", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Category { get; set; }

        [Newtonsoft.Json.JsonProperty("slug", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [Newtonsoft.Json.JsonProperty("logo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Logo { get; set; }

        [Newtonsoft.Json.JsonProperty("tags", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Tags { get; set; }

        [Newtonsoft.Json.JsonProperty("urls", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public UrlsSegment Urls { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static CryptocurrencyInfo FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CryptocurrencyInfo>(data);
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.12.3.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class UrlsSegment
    {
        [Newtonsoft.Json.JsonProperty("website", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Website { get; set; }

        [Newtonsoft.Json.JsonProperty("explorer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Explorer { get; set; }

        [Newtonsoft.Json.JsonProperty("source_code", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Source_code { get; set; }

        [Newtonsoft.Json.JsonProperty("message_board", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Message_board { get; set; }

        [Newtonsoft.Json.JsonProperty("chat", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Chat { get; set; }

        [Newtonsoft.Json.JsonProperty("announcement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Announcement { get; set; }

        [Newtonsoft.Json.JsonProperty("reddit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Reddit { get; set; }

        [Newtonsoft.Json.JsonProperty("twitter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Twitter { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static UrlsSegment FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UrlsSegment>(data);
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.12.3.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Status
    {
        [Newtonsoft.Json.JsonProperty("timestamp", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset Timestamp { get; set; }

        [Newtonsoft.Json.JsonProperty("error_code", Required = Newtonsoft.Json.Required.Always)]
        public int Error_code { get; set; }

        [Newtonsoft.Json.JsonProperty("error_message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Error_message { get; set; }

        [Newtonsoft.Json.JsonProperty("elapsed", Required = Newtonsoft.Json.Required.Always)]
        public int Elapsed { get; set; }

        [Newtonsoft.Json.JsonProperty("credit_count", Required = Newtonsoft.Json.Required.Always)]
        public int Credit_count { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Status FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Status>(data);
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.12.3.0 (Newtonsoft.Json v11.0.0.0)")]
    public abstract partial class CoinMarketCapAPIResponseOfDictionaryOfStringAndCryptocurrencyQuote : CoinMarketCapAPIResponse
    {
        [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, CryptocurrencyQuote> Data { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static CoinMarketCapAPIResponseOfDictionaryOfStringAndCryptocurrencyQuote FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CoinMarketCapAPIResponseOfDictionaryOfStringAndCryptocurrencyQuote>(data);
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.12.3.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CryptocurrencyQuotesResponse : CoinMarketCapAPIResponseOfDictionaryOfStringAndCryptocurrencyQuote
    {
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static CryptocurrencyQuotesResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CryptocurrencyQuotesResponse>(data);
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.12.3.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CryptocurrencyQuote
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("symbol", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Symbol { get; set; }

        [Newtonsoft.Json.JsonProperty("slug", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [Newtonsoft.Json.JsonProperty("circulating_supply", Required = Newtonsoft.Json.Required.Always)]
        public long Circulating_supply { get; set; }

        [Newtonsoft.Json.JsonProperty("total_supply", Required = Newtonsoft.Json.Required.Always)]
        public long Total_supply { get; set; }

        [Newtonsoft.Json.JsonProperty("max_supply", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long? Max_supply { get; set; }

        [Newtonsoft.Json.JsonProperty("date_added", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset Date_added { get; set; }

        [Newtonsoft.Json.JsonProperty("num_market_pairs", Required = Newtonsoft.Json.Required.Always)]
        public int Num_market_pairs { get; set; }

        [Newtonsoft.Json.JsonProperty("cmc_rank", Required = Newtonsoft.Json.Required.Always)]
        public int Cmc_rank { get; set; }

        [Newtonsoft.Json.JsonProperty("last_updated", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset Last_updated { get; set; }

        [Newtonsoft.Json.JsonProperty("quote", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, CryptocurrencyQuotePrice> Quote { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static CryptocurrencyQuote FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CryptocurrencyQuote>(data);
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.12.3.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CryptocurrencyQuotePrice
    {
        [Newtonsoft.Json.JsonProperty("price", Required = Newtonsoft.Json.Required.Always)]
        public decimal Price { get; set; }

        [Newtonsoft.Json.JsonProperty("volume_24h", Required = Newtonsoft.Json.Required.Always)]
        public decimal Volume_24h { get; set; }

        [Newtonsoft.Json.JsonProperty("percent_change_1h", Required = Newtonsoft.Json.Required.Always)]
        public decimal Percent_change_1h { get; set; }

        [Newtonsoft.Json.JsonProperty("percent_change_24h", Required = Newtonsoft.Json.Required.Always)]
        public decimal Percent_change_24h { get; set; }

        [Newtonsoft.Json.JsonProperty("percent_change_7d", Required = Newtonsoft.Json.Required.Always)]
        public decimal Percent_change_7d { get; set; }

        [Newtonsoft.Json.JsonProperty("market_cap", Required = Newtonsoft.Json.Required.Always)]
        public decimal Market_cap { get; set; }

        [Newtonsoft.Json.JsonProperty("last_updated", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset Last_updated { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static CryptocurrencyQuotePrice FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CryptocurrencyQuotePrice>(data);
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.12.3.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum FiatCurrency
    {
        USD = 0,

        AUD = 1,

        BRL = 2,

        CAD = 3,

        CHF = 4,

        CLP = 5,

        CNY = 6,

        CZK = 7,

        DKK = 8,

        EUR = 9,

        GBP = 10,

        HKD = 11,

        HUF = 12,

        IDR = 13,

        ILS = 14,

        INR = 15,

        JPY = 16,

        KRW = 17,

        MXN = 18,

        MYR = 19,

        NOK = 20,

        NZD = 21,

        PHP = 22,

        PKR = 23,

        PLN = 24,

        RUB = 25,

        SEK = 26,

        SGD = 27,

        THB = 28,

        TRY = 29,

        TWD = 30,

        ZAR = 31,

    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "12.0.1.0 (NJsonSchema v9.12.3.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class SwaggerException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + response.Substring(0, response.Length >= 512 ? 512 : response.Length), innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "12.0.1.0 (NJsonSchema v9.12.3.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class SwaggerException<TResult> : SwaggerException
    {
        public TResult Result { get; private set; }

        public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}