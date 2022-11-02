using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace SKIT.FlurlHttpClient.Wechat.Api
{
    public static class WechatApiClientExecuteChannelsExtensions
    {
        #region ECBasics
        /// <summary>
        /// <para>异步调用 [POST] /channels/ec/basics/img/upload 接口。</para>
        /// <para>REF: https://developers.weixin.qq.com/doc/channels/API/basics/img_upload.html </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ChannelsECBasicsImageUploadResponse> ExecuteChannelsECBasicsImageUploadAsync(this WechatApiClient client, Models.ChannelsECBasicsImageUploadRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "channels", "ec", "basics", "img", "upload")
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("resp_type", request.ResponseType);

            if (request.ImageUrl != null)
            {
                flurlReq.SetQueryParam("upload_type", 1)
                        .SetQueryParam("img_url", request.ImageUrl);

                return await client.SendRequestWithJsonAsync<Models.ChannelsECBasicsImageUploadResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
            }
            else
            {
                flurlReq.SetQueryParam("upload_type", 0)
                        .SetQueryParam("height", request.Height)
                        .SetQueryParam("width", request.Width);

                string boundary = "--BOUNDARY--" + DateTimeOffset.Now.Ticks.ToString("x");
                using var httpContent = new MultipartFormDataContent(boundary);
                using var fileContent = new ByteArrayContent(request.ImageFileBytes ?? Array.Empty<byte>());
                httpContent.Add(fileContent, "\"media\"", "\"image.png\"");
                httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data; boundary=" + boundary);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");
                fileContent.Headers.ContentLength = request.ImageFileBytes?.Length;

                return await client.SendRequestAsync<Models.ChannelsECBasicsImageUploadResponse>(flurlReq, httpContent: httpContent, cancellationToken: cancellationToken);
            }
        }
        #endregion

        #region ECCategory
        /// <summary>
        /// <para>异步调用 [POST] /channels/ec/category/availablesoncategories/get 接口。</para>
        /// <para>REF: https://developers.weixin.qq.com/doc/channels/API/category/getavailablesoncategories.html </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ChannelsECCategoryAvailableSonCategoriesGetResponse> ExecuteChannelsECCategoryAvailableSonCategoriesGetAsync(this WechatApiClient client, Models.ChannelsECCategoryAvailableSonCategoriesGetRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "channels", "ec", "category", "availablesoncategories", "get")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ChannelsECCategoryAvailableSonCategoriesGetResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /channels/ec/category/add 接口。</para>
        /// <para>REF: https://developers.weixin.qq.com/doc/channels/API/category/add.html </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ChannelsECCategoryAddResponse> ExecuteChannelsECCategoryAddAsync(this WechatApiClient client, Models.ChannelsECCategoryAddRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "channels", "ec", "category", "add")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ChannelsECCategoryAddResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /channels/ec/category/audit/get 接口。</para>
        /// <para>REF: https://developers.weixin.qq.com/doc/channels/API/category/audit_get.html </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ChannelsECCategoryAuditGetResponse> ExecuteChannelsECCategoryAuditGetAsync(this WechatApiClient client, Models.ChannelsECCategoryAuditGetRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "channels", "ec", "category", "audit", "get")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ChannelsECCategoryAuditGetResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }
        #endregion

        #region Merchant
        #region Merchant/FreightTemplate
        /// <summary>
        /// <para>异步调用 [POST] /channels/ec/merchant/getfreighttemplatelist 接口。</para>
        /// <para>REF: https://developers.weixin.qq.com/doc/channels/API/order/deliverycompanylist_get.html </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ChannelsECMerchantGetFreightTemplateListResponse> ExecuteChannelsECMerchantGetFreightTemplateListAsync(this WechatApiClient client, Models.ChannelsECMerchantGetFreightTemplateListRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "channels", "ec", "merchant", "getfreighttemplatelist")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ChannelsECMerchantGetFreightTemplateListResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /channels/ec/merchant/getfreighttemplatedetail 接口。</para>
        /// <para>REF: https://developers.weixin.qq.com/doc/channels/API/merchant/getfreighttemplatedetail.html </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ChannelsECMerchantGetFreightTemplateDetailResponse> ExecuteChannelsECMerchantGetFreightTemplateDetailAsync(this WechatApiClient client, Models.ChannelsECMerchantGetFreightTemplateDetailRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "channels", "ec", "merchant", "getfreighttemplatedetail")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ChannelsECMerchantGetFreightTemplateDetailResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /channels/ec/merchant/addfreighttemplate 接口。</para>
        /// <para>REF: https://developers.weixin.qq.com/doc/channels/API/merchant/addfreighttemplate.html </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ChannelsECMerchantAddFreightTemplateResponse> ExecuteChannelsECMerchantAddFreightTemplateAsync(this WechatApiClient client, Models.ChannelsECMerchantAddFreightTemplateRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "channels", "ec", "merchant", "addfreighttemplate")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ChannelsECMerchantAddFreightTemplateResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /channels/ec/merchant/updatefreighttemplate 接口。</para>
        /// <para>REF: https://developers.weixin.qq.com/doc/channels/API/merchant/updatefreighttemplate.html </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ChannelsECMerchantUpdateFreightTemplateResponse> ExecuteChannelsECMerchantUpdateFreightTemplateAsync(this WechatApiClient client, Models.ChannelsECMerchantUpdateFreightTemplateRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "channels", "ec", "merchant", "updatefreighttemplate")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ChannelsECMerchantUpdateFreightTemplateResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }
        #endregion
        #endregion

        #region Order
        #region Order/Delivery
        /// <summary>
        /// <para>异步调用 [POST] /channels/ec/order/deliverycompanylist/get 接口。</para>
        /// <para>REF: https://developers.weixin.qq.com/doc/channels/API/order/deliverycompanylist_get.html </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ChannelsECOrderDeliveryCompanyListGetResponse> ExecuteChannelsECOrderDeliveryCompanyListGetAsync(this WechatApiClient client, Models.ChannelsECOrderDeliveryCompanyListGetRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "channels", "ec", "order", "deliverycompanylist", "get")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ChannelsECOrderDeliveryCompanyListGetResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /channels/ec/order/delivery/send 接口。</para>
        /// <para>REF: https://developers.weixin.qq.com/doc/channels/API/order/delivery_send.html </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ChannelsECOrderDeliverySendResponse> ExecuteChannelsECOrderDeliverySendAsync(this WechatApiClient client, Models.ChannelsECOrderDeliverySendRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "channels", "ec", "order", "delivery", "send")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ChannelsECOrderDeliverySendResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }
        #endregion
        #endregion

        #region ECWindow
        /// <summary>
        /// <para>异步调用 [POST] /channels/ec/window/product/add 接口。</para>
        /// <para>REF: https://developers.weixin.qq.com/doc/channels/API/windowproduct/add.html </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ChannelsECWindowProductAddResponse> ExecuteChannelsECWindowProductAddAsync(this WechatApiClient client, Models.ChannelsECWindowProductAddRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "channels", "ec", "window", "product", "add")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ChannelsECWindowProductAddResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /channels/ec/window/product/off 接口。</para>
        /// <para>REF: https://developers.weixin.qq.com/doc/channels/API/windowproduct/off.html </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ChannelsECWindowProductOffResponse> ExecuteChannelsECWindowProductOffAsync(this WechatApiClient client, Models.ChannelsECWindowProductOffRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "channels", "ec", "window", "product", "off")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ChannelsECWindowProductOffResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }
        #endregion
    }
}
