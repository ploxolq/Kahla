﻿using Aiursoft.XelNaga.Exceptions;
using Aiursoft.XelNaga.Interfaces;
using Aiursoft.XelNaga.Models;
using Kahla.SDK.Models.ApiViewModels;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Kahla.SDK.Services
{
    public class GroupsService : IScopedDependency
    {
        private readonly SingletonHTTP _http;
        private readonly KahlaLocation _kahlaLocation;

        public GroupsService(
            SingletonHTTP http,
            KahlaLocation kahlaLocation)
        {
            _http = http;
            _kahlaLocation = kahlaLocation;
        }

        public async Task<AiurProtocol> JoinGroupAsync(string groupName, string joinPassword)
        {
            var url = new AiurUrl(_kahlaLocation.ToString(), "Groups", "JoinGroup", new
            {
                groupName,
                joinPassword
            });
            var form = new AiurUrl(string.Empty, new { });
            var result = await _http.Post(url, form);
            var JResult = JsonConvert.DeserializeObject<AiurValue<AiurProtocol>>(result);

            if (JResult.Code != ErrorType.Success)
                throw new AiurUnexceptedResponse(JResult);
            return JResult;
        }

        public async Task<AiurValue<SearchedGroup>> GroupSummaryAsync(int groupId)
        {
            var url = new AiurUrl(_kahlaLocation.ToString(), "Groups", "GroupSummary", new
            {
                id = groupId
            });
            var result = await _http.Get(url);
            var JResult = JsonConvert.DeserializeObject<AiurValue<SearchedGroup>>(result);
            if (JResult.Code != ErrorType.Success)
                throw new AiurUnexceptedResponse(JResult);
            return JResult;
        }
    }
}